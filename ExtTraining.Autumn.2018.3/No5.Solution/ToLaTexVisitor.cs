using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToLaTexVisitor : DocumentPartVisitor
    {
        public string output;

        protected override void Visit(BoldText boldText) 
            => output = "\\textbf{" + boldText.Text + "}";

        protected override void Visit(Hyperlink hyperLink) 
            => output = "\\href{" + hyperLink.Url + "}{" + hyperLink.Text + "}";

        protected override void Visit(PlainText plainText) 
            => output = plainText.Text;
    }
}
