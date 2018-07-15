using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancAccountLogic
{
    interface IBankAccountOperation
    {
        void CreateNewBankScore(BankScore bankScore);
        void CreateNewBankScore(decimal money, TypeOfBankScore typeOfBankScore = TypeOfBankScore.Base);
        void DeleteScore(int id);
        void DeleteScore(BankScore bankScore);
    }
}
