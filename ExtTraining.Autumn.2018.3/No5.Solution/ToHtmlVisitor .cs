using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public class ToHtmlVisitor : DocumentPartVisitor
    {
        protected override string Visit(BoldText boldText) 
            => "<b>" + boldText.Text + "</b>";

        protected override string Visit(Hyperlink hyperLink) 
            => "<a href=\"" + hyperLink.Url + "\">" + hyperLink.Text + "</a>";

        protected override string Visit(PlainText plainText) 
            => plainText.Text;
    }
}
