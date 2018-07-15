using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRateNBRB.Model;

namespace BancAccountLogic
{
    /// <summary>
    /// Bank account abstraction
    /// </summary>
    /// <seealso cref="BancAccountLogic.IBankAccountOperation" />
    /// <seealso cref="BancAccountLogic.IScoreOreration" />
    public sealed class BankAccount : IBankAccountOperation, IScoreOreration
    {
        #region Private fields
        /// <summary>
        /// The identifier
        /// </summary>
        private static int id = 0;

        /// <summary>
        /// The account scores
        /// </summary>
        private Dictionary<int, BankScore> accountScores;

        /// <summary>
        /// The birth day
        /// </summary>
        private readonly DateTime birthDay;

        /// <summary>
        /// The current bank score
        /// </summary>
        private BankScore currentBankScore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="birthDay">The birth day.</param>
        public BankAccount(string firstName, string lastName, DateTime birthDay)
        {
            accountScores = new Dictionary<int, BankScore>();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.birthDay = birthDay;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int Id
        {
            get => id;

            private set
            {
                if (id < 0 || id > accountScores.Count + 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                id = value;
            }
        }

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the count of scores.
        /// </summary>
        /// <value>
        /// The count of scores.
        /// </value>
        public int CountOfScores => accountScores.Count;
        #endregion

        #region Public methods
        /// <summary>
        /// Selects the current bank score.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="ArgumentException"></exception>
        public void SelectCurrentBankScore(int id)
        {
            if (!accountScores.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            currentBankScore = accountScores[id];
        }

        /// <summary>
        /// Currents the score identifier.
        /// </summary>
        /// <returns></returns>
        public int CurrentScoreId() => accountScores.FirstOrDefault(x => x.Value == currentBankScore).Key;

        /// <summary>
        /// Currents the score balance.
        /// </summary>
        /// <returns></returns>
        public decimal CurrentScoreBalance() => currentBankScore.Money;

        /// <summary>
        /// Currents the score bonus point.
        /// </summary>
        /// <returns></returns>
        public int CurrentScoreBonusPoint() => currentBankScore.BonusPoint;

        /// <summary>
        /// Currents the type of the score.
        /// </summary>
        /// <returns></returns>
        public TypeOfBankScore CurrentScoreType() => currentBankScore.TypeOfBankScore;

        /// <summary>
        /// Converts to given currency.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public decimal ConvertTo(CurrencyCode currencyCode) => currentBankScore.ConvertTo(currencyCode);
        #endregion

        #region Interface methods
        /// <summary>
        /// Creates the new bank score.
        /// </summary>
        /// <param name="bankScore">The bank score.</param>
        public void CreateNewBankScore(BankScore bankScore)
        {
            Validate(bankScore);

            accountScores.Add(++Id, bankScore);

            if (accountScores.Count == 1)
            {
                currentBankScore = accountScores[1];
            }
        }

        /// <summary>
        /// Creates the new bank score.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        public void CreateNewBankScore(decimal money, TypeOfBankScore typeOfBankScore = TypeOfBankScore.Base)
        {
            CreateNewBankScore(new BankScore(money, typeOfBankScore));
        }

        /// <summary>
        /// Deletes the score.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="ArgumentException"></exception>
        public void DeleteScore(int id)
        {
            if (!accountScores.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            accountScores.Remove(id);

            currentBankScore = accountScores.First().Value;
        }

        /// <summary>
        /// Deletes the score.
        /// </summary>
        /// <param name="bankScore">The bank score.</param>
        public void DeleteScore(BankScore bankScore)
        {
            DeleteScore(accountScores.FirstOrDefault(x => x.Value == currentBankScore).Key);
        }

        /// <summary>
        /// Deposits the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        public void Deposit(decimal money)
        {
            currentBankScore.Deposit(money);
        }

        /// <summary>
        /// Withdraws the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        public void Withdraw(decimal money)
        {
            currentBankScore.Withdraw(money);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Validates the specified string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void Validate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Validates the specified bank score.
        /// </summary>
        /// <param name="bankScore">The bank score.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void Validate(BankScore bankScore)
        {
            if (bankScore == null)
            {
                throw new ArgumentNullException();
            }
        } 
        #endregion
    }
}