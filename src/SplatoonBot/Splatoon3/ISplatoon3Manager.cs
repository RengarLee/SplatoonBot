namespace SplatoonBot.Splatoon3;

public interface ISplatoon3Manager
{
    Task<SchedulesData?> GetSchedulesAsync();
    Task<List<RegularSchedule>> GetRegularSchedules(DateTime startTime, DateTime endTime);
    Task<List<BankaraSchedule>> GetBankaraSchedules(DateTime startTime, DateTime endTime);
    Task<List<CoopGroupingRegularSchedule>> GetCoopGroupingRegularSchedules(DateTime startTime, DateTime endTime);

    List<string> GetBankaraSchedulesMessages(List<BankaraSchedule> schedules);
}