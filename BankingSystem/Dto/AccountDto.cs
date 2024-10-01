using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Dto
{
    internal class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

    }
}
