using SplatoonBot.Splatoon2;

namespace SplatoonBot.Text
{
    public interface ITextManager
    {
        /// <summary>
        ///     检查是否为Splatoon有关的命令
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsSplatoonText(string text);

        /// <summary>
        ///     IsSplatoonText
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public (DateTime startTime, DateTime endTime) GetSplatoonScheduleTime(string text);

        List<string> GetCqSplatoonScheduleMessages(List<Schedule> schedules);
    }
}
