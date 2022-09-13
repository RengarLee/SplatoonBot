namespace SplatoonBot.Splatoon3;

public class XSchedules
{
    public List<XSchedule> Nodes { get; set; }
}

public class XSchedule
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public MatchSetting XMatchSettings { get; set; }
    public MatchSetting FestMatchSetting { get; set; }
}