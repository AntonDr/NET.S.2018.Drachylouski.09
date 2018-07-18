using System;

namespace AccountNS
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Account" />
    public abstract class Account:IEquatable<Account>
    {
        /// <summary>
        /// The balance
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Gets the holder.
        /// </summary>
        /// <value>
        /// The holder.
        /// </value>
        public AccountHolder Holder { get; private set; }

        /// <summary>
        /// The bonus points
        /// </summary>
        private int bonusPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        public Account(string id,AccountHolder accountHolder)
        {
            this.Holder = accountHolder;
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get;private set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; } = Status.Closed;

        /// <summary>
        /// Gets the bonus points.
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints
        {
            get => bonusPoints;
            private set
            {
                if (value<=0)
                {
                    bonusPoints = 0;
                }
                bonusPoints = value;
            }
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        /// <exception cref="System.ArgumentException">Invalid data</exception>
        public decimal Balance
        {
            get => balance;

            set
            {
                if (IsValidValue(value))
                {
                    balance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid data");
                }
               

            }
        }

        /// <summary>
        /// Deposites the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">value</exception>
        public void Deposite(decimal value)
        {
            if (value<=0)
            {
                throw new ArgumentException($"{nameof(value)} can't be not-positive");
            }

            Balance += value;
            BonusPoints+=BonusСalculation(value);
        }

        /// <summary>
        /// Withdraws the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">value</exception>
        public void Withdraw(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} can't be not-positive");
            }

            Balance -= value;
            BonusPoints -= BonusСalculation(value);
        }


        /// <summary>
        /// Equalses the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public bool Equals(Account account)
        {
            if (account==null) return false;
            if (account==this) return true;
            if (account.GetType() != this.GetType()) return false;

            return Balance == account.Balance && Status == account.Status && Id == account.Id &&
                   BonusPoints == account.BonusPoints;
        }

        /// <summary>
        /// Bonuses the сalculation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected abstract int BonusСalculation(decimal value);
        /// <summary>
        /// Determines whether [is valid value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid value] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool IsValidValue(decimal value);
    }
}
