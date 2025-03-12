using Application.Dtos.PreSignedUrl;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class StorageController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPut]
    public async Task<IActionResult> GetPreSignedUrl(PreSignedUrlRequestDto preSignedUrlRequestDto)
    {
        var preSignedUrl = await _storageService.GetPreSignedUrlAsync(preSignedUrlRequestDto);
        return Ok(preSignedUrl);
    }
}