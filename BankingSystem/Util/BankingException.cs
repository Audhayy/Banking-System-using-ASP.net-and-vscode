using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Util
{
    public class BankingException:Exception
    {
        public BankingException(string message): base(message){}
        public BankingException(string message, Exception innerException): base(message, innerException){}

    }
}
