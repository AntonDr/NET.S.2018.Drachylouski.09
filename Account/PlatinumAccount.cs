namespace AccountNS
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Account" />
    public class PlatinumAccount:Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="accountHolder">The account holder.</param>
        public PlatinumAccount(string id,AccountHolder accountHolder) : base(id,accountHolder)
        {
        }

        /// <summary>
        /// Bonuses the сalculation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected override int BonusСalculation(decimal value)
        {
            return (int)(value * 0.07M + value * 0.7M ); 
        }

        /// <summary>
        /// Determines whether [is valid value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid value] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValidValue(decimal value)
        {
            return value>=-100000M;
        }
    }
}
