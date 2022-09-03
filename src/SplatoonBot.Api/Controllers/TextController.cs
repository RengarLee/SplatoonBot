using Microsoft.AspNetCore.Mvc;
using SplatoonBot.Text;

namespace SplatoonBot.Api.Controllers;
[ApiController]
public class TextController : Controller
{
    private readonly ITextManager _textManager;

    public TextController(ITextManager textManager)
    {
        _textManager = textManager;
    }

    [HttpGet("IsSplatoonText")]
    public bool IsSplatoonText(string text)
    {
        return _textManager.IsSplatoonText(text);
    }

    [HttpGet("SplatoonScheduleTime")]
    public string GetSplatoonScheduleTime(string text)
    {
        var tuple = _textManager.GetSplatoonScheduleTime(text);
        return $"{tuple.startTime}  {tuple.endTime}";
    }
}