using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExchangeRateNBRB;
using ExchangeRateNBRB.Model;

namespace BancAccountLogic
{

    /// <summary>
    /// Bank score abstraction    
    /// </summary>
    /// <seealso cref="BancAccountLogic.IScoreOreration" />
    /// <seealso cref="BankScore" />
    public sealed class BankScore:IScoreOreration, IEquatable<BankScore>
    {
        #region Private filds

        /// <summary>
        /// The money
        /// </summary>
        private decimal money;

        /// <summary>
        /// The type of bank score
        /// </summary>
        private TypeOfBankScore typeOfBankScore;

        /// <summary>
        /// The bonus point
        /// </summary>
        private int bonusPoint;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BankScore"/> class.
        /// </summary>
        /// <param name="bankScore">The bank score.</param>
        public BankScore(BankScore bankScore)
        {
            this.Money = bankScore.Money;
            this.BonusPoint = bankScore.BonusPoint;
            this.TypeOfBankScore = bankScore.TypeOfBankScore;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankScore"/> class.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="typeOfBankScore">The type of bank score.</param>
        public BankScore(decimal money, TypeOfBankScore typeOfBankScore = TypeOfBankScore.Base)
        {
            this.Money = money;
            this.TypeOfBankScore = typeOfBankScore;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the bonus point.
        /// </summary>
        /// <value>
        /// The bonus point.
        /// </value>
        public int BonusPoint
        {
            get => bonusPoint;
            set
            {
                bonusPoint = value;
                if (value < 0)
                {
                    BonusPoint = 0;
                }
            }
        }

        /// <summary>
        /// Gets the type of bank score.
        /// </summary>
        /// <value>
        /// The type of bank score.
        /// </value>
        public TypeOfBankScore TypeOfBankScore { get => typeOfBankScore; private set => typeOfBankScore = value; }

        /// <summary>
        /// Gets or sets the money.
        /// </summary>
        /// <value>
        /// The money.
        /// </value>
        /// <exception cref="ArgumentException"></exception>
        public decimal Money
        {
            get => money;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                money = value;
            }
        } 
        #endregion

        #region Object methods
        public bool Equals(BankScore other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return money == other.money && typeOfBankScore == other.typeOfBankScore && bonusPoint == other.bonusPoint;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals((BankScore)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = money.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)typeOfBankScore;
                hashCode = (hashCode * 397) ^ bonusPoint;
                return hashCode;
            }
        }

        public static bool operator ==(BankScore left, BankScore right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BankScore left, BankScore right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Converts to given currency.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public decimal ConvertTo(CurrencyCode code)
        {
            decimal currentRate = new ExchangeRateService().GetCurrencyRateAsync(code).Result.CurrentRate;
            return Money / currentRate;
        }
        #endregion

        #region Interface methods
        /// <summary>
        /// Deposits the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        public void Deposit(decimal money)
        {
            Validate(money);

            Money += money;

            BonusPoint += (int)TypeOfBankScore + (int)money / 100;

        }

        /// <summary>
        /// Withdraws the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        public void Withdraw(decimal money)
        {
            Validate(money);

            Money -= money;

            BonusPoint -= (int)TypeOfBankScore - (int)money / 100;
        }
        #endregion

        #region Private members
        /// <summary>
        /// Validates the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <exception cref="ArgumentException"></exception>
        private static void Validate(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException();
            }
        } 
        #endregion
    }
}
