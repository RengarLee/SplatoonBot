using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.ObjectPool;
using RestSharp;

namespace SplatoonBot.Splatoon3;

public class Splatoon3Manager : ISplatoon3Manager
{
    private readonly StringBuilderPooledObjectPolicy _stringBuilder = new();
    private readonly IMemoryCache _memoryCache;

    public Splatoon3Manager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<SchedulesData?> GetSchedulesAsync()
    {
        return _memoryCache.GetOrCreateAsync("splatoon3schedules", key =>
        {
            var client = new RestClient("https://splatoon3.ink/data");
            key.SetAbsoluteExpiration(new TimeSpan(1, 0, 0));
            return client.GetAsync<SchedulesData>(new RestRequest("schedules.json"));
        });
    }

    public async Task<List<RegularSchedule>> GetRegularSchedules(DateTime startTime, DateTime endTime)
    {
        var schedules = await GetSchedulesAsync();
        return schedules?.GetRegularSchedules(startTime, endTime) ?? new List<RegularSchedule>(0);
    }

    public async Task<List<BankaraSchedule>> GetBankaraSchedules(DateTime startTime, DateTime endTime)
    {
        var schedules = await GetSchedulesAsync();
        return schedules?.GetBankaraSchedules(startTime, endTime) ?? new List<BankaraSchedule>(0);
    }

    public async Task<List<CoopGroupingRegularSchedule>> GetCoopGroupingRegularSchedules(DateTime startTime,
        DateTime endTime)
    {
        var schedules = await GetSchedulesAsync();
        return schedules?.GetCoopGroupingSchedules(startTime, endTime) ?? new List<CoopGroupingRegularSchedule>(0);
    }

    public List<string> GetBankaraSchedulesMessages(List<BankaraSchedule> schedules)
    {
        var list = new List<string>();
        var sb = _stringBuilder.Create();
        foreach (var group in schedules.GroupBy(s => (s.LocalStartTime, s.LocalEndTime)).OrderBy(s => s.Key))
        {
            var schedule = group.FirstOrDefault();
            if (schedule != null)
            {
                var challenge = schedule.BankaraMatchSettings.FirstOrDefault(s => !s.IsOpen);
                if (challenge != null)
                {
                    sb.AppendLine(
                        $"挑战 {challenge.VsRule.ChineseName} 开始时间：{group.Key.LocalStartTime:t} 结束时间：{group.Key.LocalEndTime:t}");
                    sb.Append(
                        $"[CQ:image,file={challenge.VsStages[0].Name},url={challenge.VsStages[0].Image.Url}]");
                    sb.Append(
                        $"[CQ:image,file={challenge.VsStages[1].Name},url={challenge.VsStages[1].Image.Url}]");
                }

                var open = schedule.BankaraMatchSettings.FirstOrDefault(s => s.IsOpen);
                if (open != null)
                {
                    sb.AppendLine(
                        $"开放 {open.VsRule.ChineseName}  开始时间：{group.Key.LocalStartTime:t} 结束时间：{group.Key.LocalEndTime:t}");
                    sb.Append(
                        $"[CQ:image,file={open.VsStages[0].Name},url={open.VsStages[0].Image.Url}]");
                    sb.Append(
                        $"[CQ:image,file={open.VsStages[1].Name},url={open.VsStages[1].Image.Url}]");
                }
            }

            list.Add(sb.ToString());
            sb.Clear();
        }

        _stringBuilder.Return(sb);
        return list;
    }

    public List<string> GetCoopGroupingRegularSchedulesMessages(List<CoopGroupingRegularSchedule> schedules)
    {
        var list = new List<string>();
        var sb = _stringBuilder.Create();
        foreach (var group in schedules.GroupBy(s => (s.LocalStartTime, s.LocalEndTime)).OrderBy(s => s.Key))
        {
            var schedule = group.FirstOrDefault();
            if (schedule != null)
            {
                var setting = schedule.Setting;
                sb.AppendLine(
                    $"打工 开始时间：{@group.Key.LocalStartTime:MM/dd HH:mm} 结束时间：{@group.Key.LocalEndTime:MM/dd HH:mm}");
                sb.AppendLine("地图");
                sb.Append(
                    $"[CQ:image,file={setting.CoopStage.Name},url={setting.CoopStage.ThumbnailImage.Url}]");
                sb.AppendLine("武器");
                foreach (var weapon in setting.Weapons)
                {
                    sb.Append(
                        $"[CQ:image,file={weapon.Name},url={weapon.Image.Url}]");
                }
            }
            list.Add(sb.ToString());
            sb.Clear();
        }

        _stringBuilder.Return(sb);
        return list;
    }
}