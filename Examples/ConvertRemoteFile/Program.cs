﻿using System;
using System.IO;
using ConvertApi;

namespace ConvertRemoteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get your secret at https://www.convertapi.com/a
            var convertApiClient = new ConvertApiClient("your api secret");

            const string sourceFile = "https://cdn.convertapi.com/cara/testfiles/presentation.pptx";

            var fileParam = new ConvertApiParam("File", sourceFile);

            var convertToPdf = convertApiClient.ConvertAsync("pptx", "pdf", new[]
            {
                fileParam
            });

            var outputFileName = convertToPdf.Result.Files[0];
            var fileInfo = outputFileName.AsFileAsync(Path.Combine(Path.GetTempPath(), outputFileName.FileName)).Result;

            Console.WriteLine("The PDF saved to " + fileInfo);
        }
    }
}
