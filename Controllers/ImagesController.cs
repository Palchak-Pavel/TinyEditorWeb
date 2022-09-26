using Microsoft.AspNetCore.Mvc;

namespace News.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController: ControllerBase
{
    IWebHostEnvironment _appEnvironment;

    public ImageController(IWebHostEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }

    [HttpGet]
    public async Task<IActionResult> GetFile(string name) // уникальное название картинки
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddFile(IFormFile uploadedFile)
    {
        if (uploadedFile != null)
        {
            // путь к папке Files
            string path = "C:/Files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            return Ok(uploadedFile.FileName);
        }
        return BadRequest();
    }

}