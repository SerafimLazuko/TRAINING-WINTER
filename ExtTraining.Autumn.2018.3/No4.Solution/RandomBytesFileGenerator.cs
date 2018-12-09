using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace No4.Solution
{
    public class RandomBytesFileGenerator : FileGenerator
    {
        public override string WorkingDirectory => "Files with random bytes";

        public override string FileExtension => ".bytes";
        
        protected override byte[] GenerateFileContent(int contentLength)
        {
            new Random().NextBytes(new byte[contentLength]);

            return new byte[contentLength];
        }
    }
}
