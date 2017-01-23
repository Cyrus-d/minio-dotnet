﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minio;
using System.Net;

namespace Minio.Examples
{
    class Program
    {
        public static void Main(string[] args)
        {
           /* 
            var minioClient = new Minio.MinioRestClient("play.minio.io:9000",
              "Q3AM3UQ867SPQQA43P2F",
              "zuf+tfteSlswRu7BJ86wekitnifILbZam1KYY3TG"
              ).WithSSL();
              */
            //ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;
            
            var endPoint = Environment.GetEnvironmentVariable("AWS_ENDPOINT");
            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
         

            var minioClient = new MinioRestClient(endPoint,
                                    accessKey: accessKey, 
                                    secretKey: secretKey).WithSSL();
                                    
           // Cases.MakeBucket.Run(minioClient).Wait();
           // Cases.ListBuckets.Run(minioClient).Wait();

            // Cases.BucketExists.Run(minioClient).Wait();
            // Cases.RemoveBucket.Run(minioClient).Wait();
            //Cases.GetObject.Run(minioClient).Wait();
            //Cases.StatObject.Run(minioClient).Wait();
            Cases.PutObject.Run(minioClient).Wait();
           // Cases.ListIncompleteUploads.Run(minioClient);

            Console.ReadLine();
         
        }

    }
}
