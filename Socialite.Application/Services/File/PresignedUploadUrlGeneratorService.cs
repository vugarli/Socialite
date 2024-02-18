using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Minio;
using Minio.DataModel.Args;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.File
{
    public class PresignedUploadUrlGeneratorService : IPresignedUploadUrlGeneratorService
    {
        private IMinioClient _minioClient { get; }
        public PresignedUploadUrlGeneratorService(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public async Task<string> GenerateUrlAsync(string objectName, string bucketName)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            PresignedPutObjectArgs args = new PresignedPutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithExpiry(60 * 60 * 24);

            var url = await _minioClient.PresignedPutObjectAsync(args);

            return url;
        }
    }
}
