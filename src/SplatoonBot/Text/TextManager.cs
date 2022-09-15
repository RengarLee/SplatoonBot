using Microsoft.Extensions.ObjectPool;
using SplatoonBot.Splatoon2;

namespace SplatoonBot.Text;

public class TextManager : ITextManager
{
    private readonly StringBuilderPooledObjectPolicy _stringBuilder = new();

    /// <summary>
    ///     检查是否为Splatoon有关的命令
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public bool IsSplatoonText(string text)
    {
        return IsBankara(text) || IsCoopGrouping(text);
    }

    public bool IsBankara(string text)
    {
        return text.All(c => c == '图');
    }

    public bool IsCoopGrouping(string text)
    {
        return text.All(c => c == '工');
    }

    public (DateTime startTime, DateTime endTime) GetSplatoonScheduleTime(string text)
    {
        var wordKey = IsBankara(text) ? '图' : IsCoopGrouping(text) ? '工' : default;
        var hour = 0;
        if (IsBankara(text))
        {
            wordKey = '图';
            hour = 2;
        }
        else if (IsCoopGrouping(text))
        {
            wordKey = '工';
            hour = 40;
        }

        var count = text.Count(s => s.Equals(wordKey));
        var startTime = DateTime.Now;
        var endTime = startTime.AddHours((count - 1) * hour);
        return (startTime, endTime);
    }

    public List<string> GetCqSplatoonScheduleMessages(List<Schedule> schedules)
    {
        var list = new List<string>();
        var sb = _stringBuilder.Create();
        foreach (var group in schedules.GroupBy(s => (s.StartTime, s.EndTime)).OrderBy(s => s.Key))
        {
            var gachi = group.FirstOrDefault(g => g.GameMode.Key == "gachi");
            if (gachi != null)
            {
                sb.AppendLine($"单排 {gachi.Rule.ChineseName}  开始时间：{group.Key.StartTime:t} 结束时间：{group.Key.EndTime:t}");
                sb.Append(
                    $"[CQ:image,file={gachi.StageA.Name},url=https://splatoon2.ink/assets/splatnet{gachi.StageA.Image}]");
                sb.Append(
                    $"[CQ:image,file={gachi.StageB.Name},url=https://splatoon2.ink/assets/splatnet{gachi.StageB.Image}]");
            }

            var league = group.FirstOrDefault(g => g.GameMode.Key == "league");
            if (league != null)
            {
                sb.AppendLine($"组排 {league.Rule.ChineseName} 开始时间：{group.Key.StartTime:t} 结束时间：{group.Key.EndTime:t}");
                sb.Append(
                    $"[CQ:image,file={league.StageA.Name},url=https://splatoon2.ink/assets/splatnet{league.StageA.Image}]");
                sb.Append(
                    $"[CQ:image,file={league.StageB.Name},url=https://splatoon2.ink/assets/splatnet{league.StageB.Image}]");
            }

            list.Add(sb.ToString());
            sb.Clear();
        }

        _stringBuilder.Return(sb);
        return list;
    }
}