using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon2;

public class Schedules
{
    public List<Schedule> Regular { get; set; }

    public List<Schedule> Gachi { get; set; }

    public List<Schedule> League { get; set; }

    public List<Schedule> GetSchedules(DateTime startTime, DateTime endTime)
    {
        var gameInfos = new List<Schedule>();
        gameInfos.AddRange(Regular.Where(c => c.AllowSchedule(startTime, endTime)));
        gameInfos.AddRange(Gachi.Where(c => c.AllowSchedule(startTime, endTime)));
        gameInfos.AddRange(League.Where(c => c.AllowSchedule(startTime, endTime)));
        return gameInfos;
    }
}

public class Schedule
{
    public long Id { get; set; }

    [JsonPropertyName("start_time")] public double StartTimeStamp { get; set; }

    [JsonPropertyName("end_time")] public double EndTimeStamp { get; set; }

    [JsonPropertyName("game_mode")] public GameMode GameMode { get; set; }

    [JsonPropertyName("stage_b")] public Stage StageB { get; set; }

    [JsonPropertyName("stage_a")] public Stage StageA { get; set; }

    public Rule Rule { get; set; }

    public DateTime StartTime => TimeExtension.UnixTimeStampToDateTime(StartTimeStamp);
    public DateTime EndTime => TimeExtension.UnixTimeStampToDateTime(EndTimeStamp);

    public bool AllowSchedule(DateTime startTime, DateTime endTime)
    {
        return !(EndTime <= startTime || StartTime > endTime);
    }
}