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
            Pan = RNDNumbers.Make_RND_Number(16, 0);
            Pin = RNDNumbers.Make_RND_Number(4, 0);
            CVC = RNDNumbers.Make_RND_Number(3, StringType.Numeric);
            Balance = amount;
            ExpireDate = DateTime.Now.AddYears(year).ToString($"MM/yy");
            if (Balance < 0) {
                Balance = 0;
            }
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
