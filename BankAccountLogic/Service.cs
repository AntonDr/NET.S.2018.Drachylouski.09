using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountNS;
using AccountNumberGeneratorLogic;
using DAL;
using DAL.Interface;

namespace BancAccountLogic
{
    /// <summary>
    /// Service for work with Bank account
    /// </summary>
    public class Service
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepository<Account> repository;

        /// <summary>
        /// The fabric
        /// </summary>
        private AccountFabric fabric = new AccountFabric();

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Service(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Deposites the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Deposite(string id, decimal value)
        {
            var account = repository.GetById(id);
            if (account.Status!=Status.Open)
            {
               throw new ArgumentException($"{nameof(account)} is not-open account");
            }
            account.Deposite(value);
            repository.Update(account);
            
        }

        /// <summary>
        /// Withdraws the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void Withdraw(string id, decimal value)
        {
            var account = repository.GetById(id);
            if (account.Status != Status.Open)
            {
                throw new ArgumentException($"{nameof(account)} is not-open account");
            }
            account.Withdraw(value);
            repository.Update(account);
        }

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        public void OpenAccount(IAccountNumberGenerator id, AccountHolder accountHolder,TypeOfBankScore typeOfBankScore)
        {
            var account = fabric.Create(accountHolder, id.GenerateAccountNumbers(), typeOfBankScore);
            account.Status = Status.Open;
            repository.Create(account);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.ArgumentException">account</exception>
        public void CloseAccount(string id)
        {
            var account = repository.GetById(id);
            if (account.Status == Status.Closed)
            {
                throw new ArgumentException($"{nameof(account)} already closed");
            }

            account.Status = Status.Closed;
            repository.Update(account);

        }
    }

}
