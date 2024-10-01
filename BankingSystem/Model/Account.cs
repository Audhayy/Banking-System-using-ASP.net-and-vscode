using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankingSystem.Model
{


    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        public double balance { get; set; }

        public override string ToString()
        {
            return $"BankAccount{{" +
                   $"Id={Id}," +
                   $"Name='{Name}'," +
                   $"Address='{Address}" +
                   $"AccountNumber='{AccountNumber}'," +
                   $"IFSCCode='{IFSCCode}'" +
                   $"balance = '{balance}'"+
                   "}}";
        }

    }

}
