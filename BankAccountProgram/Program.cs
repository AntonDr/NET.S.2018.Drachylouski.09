using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountNS;
using AccountNumberGeneratorLogic;
using BancAccountLogic;
using DAL;
using ExchangeRateNBRB.Model;

namespace BankAccountProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            Service bankService = new Service(new FakeRepository());

            AccountHolder accountHolder = new AccountHolder("Anton","Drachylouski","anton.drachylouski@gmail.com");

            bankService.OpenAccount(new NumberGeneratorByHashCode(), accountHolder,TypeOfBankScore.Gold);

            string id = accountHolder.ListOfAccounts.First();

            bankService.Deposite(id,12882);

            bankService.Withdraw(id,999m);

            bankService.OpenAccount(new NumberGeneratorByHashCode(),accountHolder,TypeOfBankScore.Platinum);

            id = accountHolder.ListOfAccounts.Last();

            bankService.Withdraw(id,1200m);

            bankService.CloseAccount(id);

            AccountHolder accountHolder1 = new AccountHolder("Vova", "Sidorov", "vova.sidorov@mail.ru");

            bankService.OpenAccount(new NumberGeneratorByHashCode(),accountHolder1,TypeOfBankScore.Base );

            id = accountHolder1.ListOfAccounts.Last();

            bankService.Deposite(id,11111111m);

            bankService.CloseAccount(id);
        }
    }
}
