using Microsoft.AspNetCore.Mvc;
using SplatoonBot.Splatoon3;

namespace SplatoonBot.Api.Controllers;

[ApiController]
public class Splatoon3Controller : Controller
{
    private readonly ISplatoon3Manager _splatoon3Manager;

    public Splatoon3Controller(ISplatoon3Manager splatoon3Manager)
    {
        _splatoon3Manager = splatoon3Manager;
    }

    [HttpGet("Schedules1")]
    public Task<SchedulesData?> GetSchedulesAsync()
    {
        return _splatoon3Manager.GetSchedulesAsync();
    }
}