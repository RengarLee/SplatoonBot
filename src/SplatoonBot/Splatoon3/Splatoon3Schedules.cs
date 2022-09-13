namespace SplatoonBot.Splatoon3;

public class SchedulesData
{
    public Splatoon3Schedules Data { get; set; }
}

public class Splatoon3Schedules
{
    public RegularSchedules RegularSchedules { get; set; }

    public BankaraSchedules BankaraSchedules { get; set; }

    public XSchedules XSchedules { get; set; }

    public LeagueSchedules LeagueSchedules { get; set; }

    public CoopGroupingSchedule CoopGroupingSchedule { get; set; }
}