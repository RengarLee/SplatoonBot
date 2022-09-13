namespace SplatoonBot.Splatoon3;

public class BankaraSchedules
{
    public List<BankaraSchedule> Nodes { get; set; }
}

public class BankaraSchedule
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public MatchSetting BankaraMatchSettings { get; set; }
    public MatchSetting FestMatchSetting { get; set; }
}