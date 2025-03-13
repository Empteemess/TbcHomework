using Application.Dtos.PreSignedUrl;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation
    (
        Summary = "Get PreSignedUrl",
        Description = "A PreSigned URL will be created using FolderName and FileExtension, allowing the image to be uploaded to S3 storage.",
        OperationId = "GetPreSignedUrl"
    )]
    public async Task<IActionResult> GetPreSignedUrl(PreSignedUrlRequestDto preSignedUrlRequestDto)
    {
        var preSignedUrl = await _storageService.GetPreSignedUrlAsync(preSignedUrlRequestDto);
        return Ok(preSignedUrl);
    }
}