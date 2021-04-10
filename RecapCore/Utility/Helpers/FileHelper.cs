using Microsoft.AspNetCore.Http;
using RecapCore.Utility.Results.Abstract;
using RecapCore.Utility.Results.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecapCore.Utility.Helpers
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _imagesFolderName = "\\images\\";
        private static string _logoFolderName = "\\defaultImage\\";
        private static string defaultImagePath = "logo.png";
        public static IResult Add(IFormFile file)
        {
            string filePath = _currentDirectory + _logoFolderName + defaultImagePath;
            CheckDirectory();

            if (file != null)
            {
                var fileType = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid().ToString();
                filePath = _currentDirectory + _imagesFolderName + imageName + fileType;
                using (FileStream fs = File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    return new SuccessResult(filePath);
                }
            }
            return new SuccessResult(filePath);
            
        }

        public static IResult Update(IFormFile file, string oldImagePath)
        {
            CheckDirectory();
            DeleteOldFile(oldImagePath);
            return Add(file);
            
        }
        public static IResult Delete(string path)
        {
            if (!File.Exists(path))
            {
                return new ErrorResult();
            }
            File.Delete(path);
            return new SuccessResult();
        }
        private static void DeleteOldFile(string path)
        {
            File.Delete(path);
        }

        private static void CheckDirectory()
        {
            if (!Directory.Exists(_currentDirectory + _imagesFolderName))
            {
                Directory.CreateDirectory(_currentDirectory + _imagesFolderName);
            }
        }
    }
}
