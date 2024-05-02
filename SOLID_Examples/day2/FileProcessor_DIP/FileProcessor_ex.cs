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
    public class FileProcessor_ex
    {
        private FileReader_ex _fileReader;
        private FileWriter_ex _fileWriter;
        public FileProcessor_ex()
        {
            _fileReader = new FileReader_ex();
            _fileWriter = new FileWriter_ex();
        }
        public void ProcessFile(string inputFilePath, string outputFilePath)
        {
            string fileContent = _fileReader.ReadFile(inputFilePath);
            //Process the file content
        _fileWriter.WriteFile(outputFilePath, fileContent);
        }
    }
    public class FileReader_ex
    {
        public string ReadFile(string filePath)
        {
            //Code to read file content
        return "File content";
        }
    }
    public class FileWriter_ex
    {
        public void WriteFile(string filePath, string content)
        {
            //Code to write file content
        }
    }






}
