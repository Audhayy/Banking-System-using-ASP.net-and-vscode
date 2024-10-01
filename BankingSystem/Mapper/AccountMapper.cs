//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;
//using BankingSystem.Dto;
//using BankingSystem.Model;

//namespace BankingSystem.Mapper
//{
//    internal class AccountMapper
//    {
//        public static AccountDto ConvertToAccountDto(Account account)
//        {
//            AccountDto dto = new AccountDto();
//            dto.Name(account.Name());
//            dto.Address(account.Address);
//            return dto;
//        }

//        public static AccountDto ConvertAccountDtoToEntity(AccountDto accountDto)
//        {
//            Account account = new Account();
//            account.Name(accountDto.Name);
//            account.Address(accountDto.Address);
//            return account;
//        }
//    }
//}
