namespace SplatoonBot.Splatoon3;

public class RegularSchedules
{
    public List<RegularSchedule> Nodes { get; set; }
}

public class RegularSchedule : BaseSchedule
{
    public MatchSetting RegularMatchSetting { get; set; }

    public MatchSetting FestMatchSetting { get; set; }
}