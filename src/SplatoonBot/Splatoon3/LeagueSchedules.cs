namespace SplatoonBot.Splatoon3;

public class LeagueSchedules
{
    public List<LeagueSchedule> Nodes { get; set; }
}

public class LeagueSchedule
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public MatchSetting LeagueSettings { get; set; }
    public MatchSetting FestMatchSetting { get; set; }
}