using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public abstract class DocumentPartVisitor
    {
        public string DynamicVisit(DocumentPart part) =>
            Visit((dynamic)part);

        protected abstract string Visit(BoldText boldText);
        protected abstract string Visit(Hyperlink hyperLink);
        protected abstract string Visit(PlainText plainText);
    }
}
