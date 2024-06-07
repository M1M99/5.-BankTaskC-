using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AtmHomework.Models
{
    internal class Bank
    {
            readonly User[] users = [
            new User(name: "Arif", surname: "Rustamov -", amount: 500, year: 3),
            new User(name: "Tahir", surname: "Muslumov -", amount: 710, year: 2),
            new User(name: "Akif", surname: "Kamilli -", amount: 680, year: 1),
            new User(name: "Behram", surname: "Veliyev -", amount: 300, year: 3),
            new User(name: "Israfil", surname: "Poladov -", amount: 250, year: 7),
            new User(name: "Bayram", surname: "Hemidli -", amount: 200, year: 8),
            new User(name: "Ruslan", surname: "Memmedov -", amount: 450, year: 4),
            ];
        public User? currentUser = null;

        public void ShowUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        public void Login(string pin)
        {
            foreach (var user in users)
            {
                if ( user.CreditCard.Pin == pin)
                {
                    currentUser = user;
                    return;
                }
            }
            throw new Exception("Wrong pin");
        }

        public void Logout() 
        {
            currentUser = null;
        }


        public void Cash1(decimal amount)
        {
            try
            {
                if (currentUser.CreditCard.Balance < amount)
                    throw new Exception("Not enough money");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            currentUser.CreditCard.Balance -= amount;
            if (currentUser.CreditCard.Balance > 0)
            {
                Console.Write("Your Balance : ");
                Console.WriteLine(currentUser.CreditCard.Balance);
            }
        
        }
        public decimal GetBalance()
        {
            try
            {
                if (currentUser is null)
                    throw new Exception();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(currentUser.CreditCard.Balance < 0)
                currentUser.CreditCard.Balance = 0;
            return currentUser.CreditCard.Balance;
        }
        public void CardToCard(string? PanForCTC, decimal amount)
        {
            for (var i = 0; i < users.Length; i++)
            {
                try
                {
                    if (users[i].CreditCard.Pan == PanForCTC)
                    {
                        users[i].CreditCard.Balance += amount;
                        currentUser.CreditCard.Balance -= amount;
                        Console.WriteLine("Successful Cart To Cart");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        ShowUsers();
                        continue;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
                
        }
        public static void showMenu()
        {
            Console.WriteLine("1. Balance");
            Console.WriteLine("2. Cash");
            string? choise = (Console.ReadLine());
            if (choise is not null || choise == "1")
            {
               //
            }
            Console.WriteLine("Balans : ");
        }
    }
}
