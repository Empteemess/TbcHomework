namespace Application.Dtos.PreSignedUrl;

public class PreSignedUrlResponseDto
{
    public required string SignedUrl { get; set; }
    public required string FilePath { get; set; }
}