using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancAccountLogic;
using ExchangeRateNBRB.Model;

namespace BankAccountProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAcc = new BankAccount("Anton","Drachylouski",new DateTime(1999,12,8));
            bankAcc.CreateNewBankScore(120,TypeOfBankScore.Gold);
            Console.WriteLine(bankAcc.CurrentScoreBalance());
            bankAcc.Deposit(1400.3M);
            Console.WriteLine(bankAcc.CurrentScoreBalance());
            bankAcc.Withdraw(20.6M);
            Console.WriteLine(bankAcc.CurrentScoreBalance());
            Console.WriteLine(bankAcc.ConvertTo(CurrencyCode.USD));
            bankAcc.CreateNewBankScore(120444);
            bankAcc.SelectCurrentBankScore(2);
            Console.WriteLine(bankAcc.CurrentScoreBalance());
            bankAcc.DeleteScore(1);
            bankAcc.CreateNewBankScore(293919931,TypeOfBankScore.Gold);
            int id = bankAcc.CurrentScoreId();
            Console.WriteLine(bankAcc.CountOfScores);
            Console.WriteLine(bankAcc.CurrentScoreId());
            Console.WriteLine(bankAcc.CurrentScoreId());
            bankAcc.SelectCurrentBankScore(id);
            Console.WriteLine(bankAcc.CurrentScoreId());
            Console.WriteLine(bankAcc.CurrentScoreBalance());
            Console.WriteLine(bankAcc.CountOfScores);
            bankAcc.DeleteScore(new BankScore(293919931, TypeOfBankScore.Gold));
            Console.WriteLine(bankAcc.CountOfScores);
            Console.WriteLine(bankAcc.CurrentScoreBalance());

        }
    }
}
