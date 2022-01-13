using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem
{
    internal class FileManager
    {
        public static string GetProjectDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            return projectDirectory;
        }

     

        public static JObject GetData(string fileName)
        {
            string filePath = "";
            string jsonString = "";
            filePath = getValidatedFilePath(fileName);

            Console.WriteLine("file full path is : {0}", filePath);
            if (filePath == null) { throw new Exception("File not exist"); }
            return fileToJsonObject(filePath);

        }

        private static JObject fileToJsonObject(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JObject.Parse(jsonString);
            }catch (Exception e)
            {
                throw new Exception($"Could not parse and read from Json file, {e.Message}");
            }
        }

        private static string getValidatedFilePath(string fileName)
        {
            string filePath;
            if (fileName == null || fileName.Length == 0)
            {
                throw new ArgumentNullException("FileName of file");

            }
            try
            {
                filePath = Path.Combine(GetProjectDirectory(), fileName);
            }catch (Exception)
            {
                throw new Exception($"Cannot get full path of file name {fileName} does not exist.");
            }
            
            return filePath;
        }
    }
}
