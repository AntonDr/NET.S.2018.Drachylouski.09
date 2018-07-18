using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BancAccountLogic
{
    public class BankServiceExxceprion : Exception
    {
        public BankServiceExxceprion()
        {
        }

        public BankServiceExxceprion(string message) : base(message)
        {
        }

        public BankServiceExxceprion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BankServiceExxceprion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
