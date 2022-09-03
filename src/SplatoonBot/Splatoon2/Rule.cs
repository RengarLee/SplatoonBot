using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon2
{
    public class Rule
    {
        public string Name { get; set; }

        [JsonPropertyName("multiline_name")]
        public string MultilineName { get; set; }

        public string Key { get; set; }

        public string ChineseName
        {
            get
            {
                return Key switch
                {
                    "splat_zones" => "区域",
                    "tower_control" => "推塔",
                    "rainmaker" => "运鱼",
                    "clam_blitz" => "区域",
                    _ => null
                } ?? string.Empty;
            }
        }
    }
}
