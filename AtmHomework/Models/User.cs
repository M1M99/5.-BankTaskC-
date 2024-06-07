using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmHomework.Models
{
    internal class User
    {
        public string Name;
        public string Surname;
        public Card CreditCard;

        public User(string name, string surname, int amount, int year)
        {
            Name = name;
            Surname = surname;
            CreditCard = new Card(amount, year);
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {CreditCard}";
        }
    }
}
