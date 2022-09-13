namespace SplatoonBot.Splatoon3;

public interface ISplatoon3Manager
{
    Task<SchedulesData?> GetSchedulesAsync();
}