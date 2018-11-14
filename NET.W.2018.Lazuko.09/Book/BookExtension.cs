//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookLogic
//{
//    class BookExtension : IFormatProvider, ICustomFormatter
//    {
//        public object GetFormat(Type formatType)
//        {
//            if (formatType == typeof(ICustomFormatter))
//                return this;
//            else
//                return null;
//        }

//        public string Format(string format, object argument, IFormatProvider formatProvider)
//        {
//            if(argument.GetType() != typeof(Book))
//            {
//                try
//                {
//                    return HandleOtherFormat(format, argument);
//                }
//                catch
//                {
//                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
//                }
//            }
//        }

//        private string HandleOtherFormat(string format, object argument)
//        {

//        }
//    }
//}
