using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon3;

public class MatchSetting
{
    [JsonPropertyName("__isVsSetting")] public string IsVsSetting { get; set; }
    [JsonPropertyName("__typeName")] public string TypeName { get; set; }

    public List<VsStage> VsStages { get; set; }

    public VsRule VsRule { get; set; }

    public string Mode { get; set; }

    [JsonIgnore]
    public bool IsOpen => Mode.Equals("OPEN");
}

public class FestMatchSetting
{
    [JsonPropertyName("__typeName")] public string TypeName { get; set; }
}

public class VsRule
{
    public string Name { get; set; }

    public string Rule { get; set; }

    public string Id { get; set; }

    public string ChineseName
    {
        get
        {
            return Name switch
            {
                "Splat Zones" => "区域",
                "Tower Control" => "推塔",
                "Rainmaker" => "运鱼",
                "Clam Blitz" => "蛤蜊",
                _ => null
            } ?? string.Empty;
        }
    }

}

public class VsStage
{
    public string Id { get; set; }

    public int VsStageId { get; set; }

    public string Name { get; set; }

    public StageImage Image { get; set; }
}

