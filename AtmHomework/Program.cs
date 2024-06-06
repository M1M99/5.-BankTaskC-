using AtmHomework.Helpers;
using AtmHomework.Models;

Bank bank = new();
bank.ShowAllUsers();

while (true)
{
    if (bank.currentUser is null)
    {
    login:
        try
        {
            Console.Write("Enter Pin: ");
            var pin = Console.ReadLine();
            bank.Login(pin);
            Console.Clear();
            Console.WriteLine($"Welcome {bank.currentUser.Name} {bank.currentUser.Surname}\b  \n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            goto login;
        }
    userss:
        Console.WriteLine("1. Balance");
        Console.WriteLine("2. Cash");
        Console.WriteLine("3. Cart To Cart");
        Console.WriteLine("4. LogOut");
        Console.Write("Choise : ");
        string choise = string.Empty;
        try
        {
            choise = (Console.ReadLine());
            if (string.IsNullOrWhiteSpace(choise))
                throw new Exception("Your Choise Is Not True !");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (choise == "1")
        {
            Console.Clear();
            Console.WriteLine($"Balance : {bank.GetBalance()}");
            goto userss;
        }
        else if (choise == "4")
        {
            Console.Clear();
            bank.ShowAllUsers();
            bank.Logout();
            goto login;
        }
        else if (choise == "3")
        {
            u:
            decimal amountforctc = 0;
            string otherpan = string.Empty;
            try
            {
                Console.WriteLine($"Your Balance : {bank.currentUser.CreditCard.Balance}");
                Console.Write("Enter Amount For Cart To Cart : ");
                amountforctc = decimal.Parse(Console.ReadLine());
                if (amountforctc > bank.currentUser.CreditCard.Balance)
                {
                    throw new Exception("Have Not Enough Money !");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto u;
            }
        u1:
            try
            {
                bank.ShowAllUsers();
                Console.Write("Enter Pan : ");
                otherpan = Console.ReadLine();
                bank.CardToCard(otherpan, amountforctc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto u;
            }
        }
        else if (choise == "2")
        {
        checkyourbalace:
            Console.Clear();
            decimal amount;
            try
            {
                Console.WriteLine($"1. 10Azn\n2. 20Azn\n3. 50Azn\n4. 100Azn\n5. Write Yourself\n6. LogOut");
                Console.Write("Choise : ");
                int choiser = int.Parse(Console.ReadLine());
                if (choiser == 1 && bank.currentUser.CreditCard.Balance >= 10)
                {
                    Console.Clear();
                    bank.Cash1(10);
                }
                else if (choiser == 2 && bank.currentUser.CreditCard.Balance >= 20)
                {
                    Console.Clear();
                    bank.Cash1(20);
                }
                else if (choiser == 3 && bank.currentUser.CreditCard.Balance >= 50)
                {
                    Console.Clear();    
                    bank.Cash1(50);
                }
                else if (choiser == 4 && bank.currentUser.CreditCard.Balance >= 100)
                {
                    Console.Clear();
                    bank.Cash1(100);
                }
                else if (choiser == 5)
                {
                    Console.Clear();
                    amount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("How Much Money :");
                    if (bank.currentUser.CreditCard.Balance >= amount && bank.currentUser.CreditCard is not null)
                    {
                        bank.Cash1(amount);
                    }
                }
                else if (choiser == 6)
                {
                    Console.Clear();
                    bank.Logout();
                    goto login;
                }
                else
                {
                    throw new Exception("Secim Yanlisdir ! ");
                    goto checkyourbalace;
                }
                goto userss;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto checkyourbalace;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Select Correct Choise ! ");
            goto userss;
        }
        goto login;
    }
}