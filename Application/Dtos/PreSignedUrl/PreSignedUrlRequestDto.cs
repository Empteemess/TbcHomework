namespace Application.Dtos.PreSignedUrl;

public class PreSignedUrlRequestDto
{
    public required string FolderName { get; set; }
    public required string FileExtension { get; set; }
}