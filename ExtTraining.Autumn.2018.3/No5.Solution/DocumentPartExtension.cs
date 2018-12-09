using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    public static class DocumentPartExtension
    {
        public static string ToLaTexOutput(this Document document) 
            => Output(document, new ToLaTexVisitor());

        public static string ToHtmlOutlut(this Document document)
            => Output(document, new ToHtmlVisitor());

        public static string ToPlainTextOutput(this Document document)
            => Output(document, new ToPlainTextVisitor());
            
        private static string Output(Document document, DocumentPartVisitor visitor)
        {
            string output = string.Empty;
            
            foreach (DocumentPart part in document.parts)
            {
                output += $"{visitor.DynamicVisit(part)}\n";
            }

            return output;
        }
    }
}