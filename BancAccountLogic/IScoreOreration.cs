using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancAccountLogic
{
    interface IScoreOreration
    {
        void Deposit(decimal money);
        void Withdraw(decimal money);
    }
}
