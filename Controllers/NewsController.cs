using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using News.API.DTO;
using News.API.Mongodb.Data;
using News.API.Mongodb.Entities;

namespace News.API.Controllers;

[ApiController]
[Route("[controller]")]

public class NewsController : ControllerBase
{
    private readonly IMongoNewsContext _context;
    private readonly IMapper _mapper;

    public NewsController(IMongoNewsContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EditorNews>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
    {
        var news = await _context.EditNews.Find(x => true).ToListAsync();
        var mapEditorNews = _mapper.Map<IList<NewsDto>>(news);
      
        return Ok(mapEditorNews);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<EditorNews>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<EditorNews>> GetId(string id)
    {
        var newsId = await _context.EditNews.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (newsId == null) return NotFound();
        
        return Ok(newsId);
    }
}