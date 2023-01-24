using Microsoft.AspNetCore.Mvc;

namespace Apito.Controllers;

[ApiController]
[Route("[controller]")]
public class RamController : Controller
{
    // GET
    [HttpGet(Name = "GetRAMUsage")]
    public IActionResult Get()
    {
        var res = $"{GC.GetTotalMemory(false) / 1024 / 1024} MB (managed)"
                  + Environment.NewLine +
                  $"System: {Environment.WorkingSet / 1024 / 1024} MB (total)";

        return Ok(res);
    }
}