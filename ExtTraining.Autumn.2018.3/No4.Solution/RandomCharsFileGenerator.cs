using System;
using System.IO;
using System.Linq;
using System.Text;

namespace No4.Solution
{
    public class RandomCharsFileGenerator : FileGenerator
    {
        public override string WorkingDirectory => "Files with random chars";
        public override string FileExtension => ".txt";

        protected override byte[] GenerateFileContent(int contentLength) 
            => Encoding.Unicode.GetBytes(this.RandomString(contentLength));

        private string RandomString(int Size)
        {
            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            
            return new string(Enumerable.Range(0, Size).Select(x => input[new Random().Next(0, input.Length)]).ToArray());
        }
    }
}
