using Application.Dtos.PreSignedUrl;

namespace Application.IServices;

public interface IStorageService
{
    Task<PreSignedUrlResponseDto> GetPreSignedUrlAsync(PreSignedUrlRequestDto preSignedUrlRequestDto);
}