using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNumberGeneratorLogic
{
    /// <summary>
    /// Number generator
    /// </summary>
    /// <seealso cref="AccountNumberGeneratorLogic.IAccountNumberGenerator" />
    public class NumberGeneratorByHashCode:IAccountNumberGenerator
    {
        /// <summary>
        /// Generates the account numbers.
        /// </summary>
        /// <returns></returns>
        public string GenerateAccountNumbers() => Guid.NewGuid().GetHashCode().ToString();
    }
}
