using Microsoft.AspNetCore.Mvc;
using Series.DataBase;
using Series.Models;

namespace Series.Controllers;

[ApiController]
[Route("[controller]")]
public class SeriesController : ControllerBase
{
    private readonly ILogger<SeriesController> _logger;
    private readonly SeriesContext _context;

    public SeriesController(ILogger<SeriesController> logger, SeriesContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("all")]
    public List<Serie> GetAllNotes()
    {
        return _context.Series.ToList();
    }
}
