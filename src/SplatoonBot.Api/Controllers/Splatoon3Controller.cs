using Microsoft.AspNetCore.Mvc;
using SplatoonBot.Splatoon3;

namespace SplatoonBot.Api.Controllers;

[Route("Splatoon3")]
[ApiController]
public class Splatoon3Controller : Controller
{
    private readonly ISplatoon3Manager _splatoon3Manager;

    public Splatoon3Controller(ISplatoon3Manager splatoon3Manager)
    {
        _splatoon3Manager = splatoon3Manager;
    }

    [HttpGet("Schedules")]
    public Task<SchedulesData?> GetSchedulesAsync()
    {
        return _splatoon3Manager.GetSchedulesAsync();
    }

    [HttpGet("Schedules/Regular")]
    public Task<List<RegularSchedule>> GetRegularSchedules(DateTime startTime, DateTime endTime)
    {
        return _splatoon3Manager.GetRegularSchedules(startTime, endTime);
    }

    [HttpGet("Schedules/Bankara")]
    public Task<List<BankaraSchedule>> GetBankaraSchedules(DateTime startTime, DateTime endTime)
    {
        return _splatoon3Manager.GetBankaraSchedules(startTime, endTime);
    }

    [HttpGet("Schedules/CoopGrouping/Regular")]
    public Task<List<CoopGroupingRegularSchedule>> GetCoopGroupingRegularSchedules(DateTime startTime, DateTime endTime)
    {
        return _splatoon3Manager.GetCoopGroupingRegularSchedules(startTime, endTime);
    }
}