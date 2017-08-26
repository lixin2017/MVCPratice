using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Code
{
    class FileHelper
    {
        //检测目录是否存在
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        //检测指定文件是否存在
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }
        //获取指定目录下的文件列表
        public static string[] GetFileNames(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }
            return Directory.GetFiles(directoryPath);
        }
        //获取指定目录下的子目录列表
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        public static string[] GetFileNames(string directoryPath,string searchPattern)
    }
}
