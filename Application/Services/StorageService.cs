using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Application.Dtos.PreSignedUrl;
using Application.IServices;
using Domain.CustomExceptions;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class StorageService : IStorageService
{
    private readonly AmazonS3Client _s3Client;
    private readonly string _bucketName;
    
    public StorageService(IConfiguration configuration)
    {
        _bucketName = configuration["AWS_STORAGE_BUCKET_NAME"]!;
        var awsAccessKey = configuration["AWS_ACCESS_KEY_ID"]!;
        var awsSecretKey = configuration["AWS_SECRET_ACCESS_KEY"]!;
        
        var awsConfig = new AmazonS3Config{RegionEndpoint = RegionEndpoint.EUCentral1};
        
        var awsCredentials = new BasicAWSCredentials(awsAccessKey, awsSecretKey);

        _s3Client = new AmazonS3Client(awsCredentials,awsConfig);
    } 
    
    public async Task<PreSignedUrlResponseDto> GetPreSignedUrlAsync(PreSignedUrlRequestDto preSignedUrlRequestDto)
    {
        GetPreSignedUrlInputChecker(preSignedUrlRequestDto);

        var filePath = $"{preSignedUrlRequestDto.FolderName}/{Guid.NewGuid()}{preSignedUrlRequestDto.FileExtension}";

        var preSignedUrlObj = new GetPreSignedUrlRequest()
        {
            BucketName = _bucketName,
            Key = filePath,
            Expires = DateTime.UtcNow.AddSeconds(30),
            Verb = HttpVerb.PUT,
        };

        var preSignedUrl = await _s3Client.GetPreSignedURLAsync(preSignedUrlObj);

        return new PreSignedUrlResponseDto
        {
            SignedUrl = preSignedUrl,
            FilePath = filePath
        };
    }

    private void GetPreSignedUrlInputChecker(PreSignedUrlRequestDto preSignedUrlRequestDto)
    {
        if (string.IsNullOrWhiteSpace(preSignedUrlRequestDto.FileExtension)
            | string.IsNullOrWhiteSpace(preSignedUrlRequestDto.FolderName))
            throw new NotFoundException("Value Cannot be null or empty.", (int)HttpStatusCode.Forbidden);
    }
}