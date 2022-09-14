using System.Text.Json.Serialization;

namespace SplatoonBot.Splatoon3;

public class BaseSchedule
{
    [JsonPropertyName("StartTime")]
    public DateTime UTCStartTime { get; set; }
    [JsonPropertyName("EndTime")]

    public DateTime UTCEndTime { get; set; }

    public DateTime LocalStartTime => UTCStartTime.ToLocalTime();

    public DateTime LocalEndTime => UTCEndTime.ToLocalTime();

    public bool AllowSchedule(DateTime startTime, DateTime endTime)
    {
        return !(LocalEndTime <= startTime || LocalStartTime > endTime);
    }
}

public static class BaseScheduleExpand
{
    public static List<T> GetSchedules<T>(this List<T> list, DateTime startTime, DateTime endTime)
        where T : BaseSchedule
    {
        return list.Where(l => l.AllowSchedule(startTime, endTime)).ToList();
    }
}