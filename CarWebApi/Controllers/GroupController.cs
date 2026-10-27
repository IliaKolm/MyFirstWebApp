using Microsoft.AspNetCore.Mvc;
using CarWebApi.Data;

namespace CarWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly MyAplicationContext _context;

    public GroupController(ILogger<CarController> logger, MyAplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Group> Get()
    {
        return _context.Groups
            .ToList();
    }
}