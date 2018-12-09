using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToPlainTextVisitor : DocumentPartVisitor
    {
        public string output;

        protected override void Visit(BoldText boldText) 
            => output = "**" + boldText.Text + "**";

        protected override void Visit(Hyperlink hyperLink) 
            => output = hyperLink.Text + " [" + hyperLink.Url + "]";

        protected override void Visit(PlainText plainText) 
            => output = plainText.Text;
    }
}
