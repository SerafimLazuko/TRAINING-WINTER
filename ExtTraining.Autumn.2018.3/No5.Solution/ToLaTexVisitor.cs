using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToLaTexVisitor : DocumentPartVisitor
    {
        protected override string Visit(BoldText boldText) 
            => "\\textbf{" + boldText.Text + "}";

        protected override string Visit(Hyperlink hyperLink) 
            => "\\href{" + hyperLink.Url + "}{" + hyperLink.Text + "}";

        protected override string Visit(PlainText plainText) 
            => plainText.Text;
    }
}
