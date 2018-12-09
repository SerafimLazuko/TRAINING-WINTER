using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToPlainTextVisitor : DocumentPartVisitor
    {
        protected override string Visit(BoldText boldText) 
            => "**" + boldText.Text + "**";

        protected override string Visit(Hyperlink hyperLink) 
            => hyperLink.Text + " [" + hyperLink.Url + "]";

        protected override string Visit(PlainText plainText) 
            => plainText.Text;
    }
}
