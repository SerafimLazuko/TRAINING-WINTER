using System;
using System.Collections;
using System.Collections.Generic;
using static No5.Solution.DocumentPartExtension;

namespace No5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BoldText boldText = new BoldText();
            boldText.Text = "Bold Text";

            PlainText plainText = new PlainText();
            plainText.Text = "Plain Text";

            Hyperlink hyperlink = new Hyperlink();
            hyperlink.Text = "Hyper Link";
            
            List<DocumentPart> list = new List<DocumentPart>
            {
                boldText,
                plainText,
                hyperlink
            };

            Document document = new Document(list);

            System.Console.WriteLine(document.ToLaTexOutput());
            System.Console.ReadKey();

            System.Console.WriteLine(document.ToHtmlOutlut());
            System.Console.ReadKey();

            System.Console.WriteLine(document.ToPlainTextOutput());
            System.Console.ReadKey();
        }
    }
}
 