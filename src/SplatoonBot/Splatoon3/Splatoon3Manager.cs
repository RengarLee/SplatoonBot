using RestSharp;

namespace SplatoonBot.Splatoon3;

public class Splatoon3Manager : ISplatoon3Manager
{
    public async Task<SchedulesData?> GetSchedulesAsync()
    {
        var client = new RestClient("https://splatoon3.ink/data");
        return await client.GetAsync<SchedulesData>(new RestRequest("schedules.json"));
    }
}