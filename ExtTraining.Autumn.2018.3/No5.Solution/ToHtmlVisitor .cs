using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToHtmlVisitor : DocumentPartVisitor
    {
        public string output;

        protected override void Visit(BoldText boldText) 
            => output = "<b>" + boldText.Text + "</b>";

        protected override void Visit(Hyperlink hyperLink) 
            => output = "<a href=\"" + hyperLink.Url + "\">" + hyperLink.Text + "</a>";

        protected override void Visit(PlainText plainText) 
            => output = plainText.Text;
    }
}
