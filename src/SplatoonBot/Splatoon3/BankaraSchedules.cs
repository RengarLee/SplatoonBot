namespace SplatoonBot.Splatoon3;

public class BankaraSchedules
{
    public List<BankaraSchedule> Nodes { get; set; }
}

public class BankaraSchedule : BaseSchedule
{
    public List<MatchSetting> BankaraMatchSettings { get; set; }
    public List<MatchSetting> FestMatchSetting { get; set; }
}