using System.Net;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
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
    /*private IValidator<EditorNews> _validator;*/

    public NewsController(IMongoNewsContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        /*_validator = validator;*/
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

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<EditorNews>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<EditorNews>> CreateNews([FromBody] EditorNews news)
    {
        /*ValidationResult res = await _validator.ValidateAsync(news);
        if (!res.IsValid)
        {
            res.AddToModelState(this.ModelState);
        }*/
        
        news.CreatedAt = DateTime.Now;
        await _context.EditNews.InsertOneAsync(news);
        var result = _mapper.Map<EditorNews>(news);
        return Ok(result);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(EditorNews), (int)HttpStatusCode.OK)]
    [Route("{id}")]
    public async Task<bool> UpdateNews(string id, [FromBody] EditorNews news)
    {
        var updateNews = await _context.EditNews.
            ReplaceOneAsync(filter: g => g.Id == news.Id, replacement: news);

       return updateNews.IsAcknowledged && updateNews.ModifiedCount > 0;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(EditorNews), (int)HttpStatusCode.OK)]
    public async Task<bool> DeleteNews(string id)
    {
        FilterDefinition<EditorNews> filter = Builders<EditorNews>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .EditNews
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}