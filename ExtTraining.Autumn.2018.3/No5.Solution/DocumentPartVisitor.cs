using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5
{
    public abstract class DocumentPartVisitor
    {
        public void DynamicVisit(DocumentPart part) =>
            Visit((dynamic)part);

        protected abstract void Visit(BoldText boldText);
        protected abstract void Visit(Hyperlink hyperLink);
        protected abstract void Visit(PlainText plainText);
    }
}
