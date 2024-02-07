using Microsoft.AspNetCore.Mvc;
using Middleware.Managers;
using Middleware.Models;

namespace Middleware.Controllers;

[ApiController]
[Route("[controller]")]
public class DictionaryController : Controller
{
    [HttpGet("retrieve")]
    public IActionResult GetDefinition(string word)
    {
        DictionaryManager dictionaryManager = new DictionaryManager();
        try
        {
            Task<List<DictionaryResponse>> task =
                Task.Run<List<DictionaryResponse>>(async () => await dictionaryManager.GetDefinition(word));
            if (task.Result != null)
            {
                return Ok(task.Result);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, "No value returned");
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, "Manager Error occurred");
        }
    }
    
}