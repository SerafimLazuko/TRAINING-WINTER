using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution
{
    public abstract class FileGenerator
    {
        public abstract string WorkingDirectory { get; }
        public abstract string FileExtension { get; }
        
        public string FileName { get; private set; }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            FileName = fileName;

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        public string ReadBytesFromFile(string fileName)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                throw new Exception($"{fileName} is not exist!");
            }

            byte[] bytes = File.ReadAllBytes($"{WorkingDirectory}//{fileName}");

            return Encoding.Default.GetString(bytes);
        }
    }
}
