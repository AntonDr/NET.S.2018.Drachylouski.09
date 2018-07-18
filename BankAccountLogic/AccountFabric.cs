using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AccountNS;

namespace BancAccountLogic
{
    /// <summary>
    /// Fabric method pattern
    /// </summary>
    public class AccountFabric
    {
        /// <summary>
        /// Creates the specified account holder.
        /// </summary>
        /// <param name="accountHolder">The account holder.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">typeOfBankScore</exception>
        public Account Create(AccountHolder accountHolder,string id,TypeOfBankScore typeOfBankScore)
        {
            switch (typeOfBankScore)
            {
                case TypeOfBankScore.Base:
                    accountHolder.ListOfAccounts.Add(id);
                    return new BaseAccount(id,accountHolder);
                case TypeOfBankScore.Silver:
                    accountHolder.ListOfAccounts.Add(id);
                    return new SilverAccount(id,accountHolder);
                case TypeOfBankScore.Gold:
                    accountHolder.ListOfAccounts.Add(id);
                    return new GoldAccount(id,accountHolder);
                case TypeOfBankScore.Platinum:
                    accountHolder.ListOfAccounts.Add(id);
                    return new PlatinumAccount(id,accountHolder);
                    default:
                        throw new ArgumentException($"Invalid {nameof(typeOfBankScore)}");
            }
        }
    }
}
