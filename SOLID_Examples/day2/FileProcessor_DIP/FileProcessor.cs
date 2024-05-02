using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Examples.day2.FileProcessor_DIP
{
    public class FileProcessor
    {
        private IFileReader _fileReader;
        private IFileWriter _fileWriter;
        public FileProcessor(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }
        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            //Process the file content
             _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }
    public class FileReader :IFileReader
    {
        public string ReadFile(string filePath)
        {
            //Code to read file content
        return "File content";
        }
    }
    public class FileWriter:IFileWriter
    {
        public void WriteFile(string filePath, string content)
        {
            //Code to write file content
        }
    }

    public interface IFileReader
    {
        string ReadFile(string filePath);
    }
    public interface IFileWriter
    {
        public void WriteFile(string filePath, string content);
    }




}
