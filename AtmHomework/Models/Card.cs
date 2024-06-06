using AtmHomework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmHomework.Models
{
    internal class Card
    {
        public string Pan { get; set; }
        public string Pin { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public decimal Balance { get; set; }

        public Card(decimal amount, int year)
        {
            Pan = RNDNumbers.GenerateString(16, StringType.Numeric);
            Pin = RNDNumbers.GenerateString(4, StringType.Numeric);
            CVC = RNDNumbers.GenerateString(3, StringType.Numeric);
            Balance = amount;
            ExpireDate = DateTime.Now.AddYears(year).ToString($"MM/yy");
        }

        public decimal getBalance() {
            return Balance;
        }

        public override string ToString()
        {
            return $"{Pan}  {Pin}  {CVC}  {ExpireDate}  {Balance}";
        }
    }
}
