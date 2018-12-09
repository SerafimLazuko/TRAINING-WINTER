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
        {
            string output = string.Empty;

            var visitor = new ToLaTexVisitor();

            foreach (DocumentPart part in document.parts)
            {
                visitor.DynamicVisit(part);
                output += $"{visitor.output}\n";
            }

            return output;
        }

        public static string ToHtmlOutlut(this Document document)
        {
            string output = string.Empty;

            var visitor = new ToHtmlVisitor();

            foreach (DocumentPart part in document.parts)
            {
                visitor.DynamicVisit(part);
                output += $"{visitor.output}\n";
            }

            return output;
        }

        public static string ToPlainTextOutput(this Document document)
        {
            string output = string.Empty;

            var visitor = new ToPlainTextVisitor();

            foreach (DocumentPart part in document.parts)
            {
                visitor.DynamicVisit(part);
                output += $"{visitor.output}\n";
            }

            return output;
        }
    }
}
