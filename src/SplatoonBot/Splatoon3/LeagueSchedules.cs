namespace SplatoonBot.Splatoon3;

public class LeagueSchedules
{
    public List<LeagueSchedule> Nodes { get; set; }
}

public class LeagueSchedule : BaseSchedule
{
    public MatchSetting LeagueMatchSetting { get; set; }
    public MatchSetting FestMatchSetting { get; set; }
}