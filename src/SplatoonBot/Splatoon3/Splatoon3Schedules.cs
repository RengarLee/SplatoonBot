namespace SplatoonBot.Splatoon3;

public class SchedulesData
{
    public Splatoon3Schedules Data { get; set; }

    public List<RegularSchedule> GetRegularSchedules(DateTime startTime, DateTime endTime)
    {
        return Data.RegularSchedules.Nodes.GetSchedules(startTime, endTime);
    }

    public List<BankaraSchedule> GetBankaraSchedules(DateTime startTime, DateTime endTime)
    {
        return Data.BankaraSchedules.Nodes.GetSchedules(startTime, endTime);
    }

    public List<CoopGroupingRegularSchedule> GetCoopGroupingSchedules(DateTime startTime, DateTime endTime)
    {
        return  Data.CoopGroupingSchedule.RegularSchedules.Nodes.GetSchedules(startTime, endTime);
    }

    //public bool IsValid()
    //{
    //   return !Data.RegularSchedules.Nodes[0].RegularMatchSetting.IsVsSetting.Equals("string");
    //}
}

public class Splatoon3Schedules
{
    public RegularSchedules RegularSchedules { get; set; }

    public BankaraSchedules BankaraSchedules { get; set; }

    public XSchedules XSchedules { get; set; }

    public LeagueSchedules LeagueSchedules { get; set; }

    public CoopGroupingSchedule CoopGroupingSchedule { get; set; }
}