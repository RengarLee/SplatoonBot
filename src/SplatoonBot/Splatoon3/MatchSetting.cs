using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon3;

public class MatchSetting
{
    [JsonPropertyName("__isVsSetting")] public string IsVsSetting { get; set; }
    [JsonPropertyName("__typeName")] public string TypeName { get; set; }

    public List<VsStage> VsStages { get; set; }

    public VsRule VsRule { get; set; }

    public string Mode { get; set; }
}

public class VsRule
{
    public string Name { get; set; }

    public string Rule { get; set; }

    public string Id { get; set; }
}

public class VsStage
{
    public string Id { get; set; }

    public int VsStageId { get; set; }

    public string Name { get; set; }

    public StageImage Image { get; set; }
}

