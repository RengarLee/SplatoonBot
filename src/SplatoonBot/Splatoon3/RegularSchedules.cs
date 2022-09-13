using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon3;

public class RegularSchedules
{
    public List<RegularSchedule> Nodes { get; set; }
}

public class RegularSchedule
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public MatchSetting RegularMatchSetting { get; set; }

    public MatchSetting FestMatchSetting { get; set; }
}

