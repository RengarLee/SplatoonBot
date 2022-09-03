using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace SplatoonBot.Splatoon2;

public class Splatoon2Manager : ISplatoon2Manager
{
    private readonly IMemoryCache _memoryCache;

    public Splatoon2Manager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<Schedules?> GetSchedulesAsync()
    {
        return _memoryCache.GetOrCreateAsync("schedules", (key) =>
        {
            key.SetAbsoluteExpiration(new TimeSpan(0,0,30,0));
            var client = new RestClient("https://splatoon2.ink/data");
            return client.GetAsync<Schedules>(new RestRequest("schedules.json"));
        });
    }

    public async Task<List<Schedule>> GetScheduleListAsync(DateTime startTime, DateTime endTime)
    {
        var schedules = await GetSchedulesAsync();
        return schedules == null ? new List<Schedule>(0) : schedules.GetSchedules(startTime, endTime);
    }
}