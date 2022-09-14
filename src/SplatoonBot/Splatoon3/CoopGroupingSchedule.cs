using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon3;

public class CoopGroupingSchedule
{
    public CoopGroupingRegularSchedules RegularSchedules { get; set; }
}

public class CoopGroupingRegularSchedules
{
    public List<CoopGroupingRegularSchedule> Nodes { get; set; }
}

public class CoopGroupingRegularSchedule:BaseSchedule
{
    public CoopGroupingSetting Setting { get; set; }
}

public class CoopGroupingSetting
{
    [JsonPropertyName("__typename")] public string TypeName { get; set; }

    public CoopStage CoopStage { get; set; }
    public List<Weapon> Weapons { get; set; }
}

public class CoopStage
{
    public string Name { get; set; }

    public int CoopStageId { get; set; }
    public string Id { get; set; }
    public StageImage ThumbnailImage { get; set; }
}

public class Weapon
{
    public string Name { get; set; }
    public WeaponImage Image { get; set; }
}

public class WeaponImage
{
    public string Url { get; set; }
}