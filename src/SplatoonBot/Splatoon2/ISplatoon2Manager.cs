namespace SplatoonBot.Splatoon2
{
    public interface ISplatoon2Manager
    {
        Task<Splatoon2Schedules?> GetSchedulesAsync();
        Task<List<Schedule>> GetScheduleListAsync(DateTime startTime, DateTime endTime);
    }
}
