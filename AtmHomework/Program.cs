using AtmHomework.Helpers;
using AtmHomework.Models;

Bank bank = new();
bank.ShowUsers();

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
            bank.ShowUsers();
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
                bank.ShowUsers();
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
            decimal amount1;
            Console.Write($"Your Balance : ");
            if(bank.currentUser.CreditCard.Balance < 0)
            {
                bank.currentUser.CreditCard.Balance = 0;
            }
            Console.WriteLine(bank.currentUser.CreditCard.Balance);

            try
            {
                Console.WriteLine($"1. 10Azn\n2. 20Azn\n3. 50Azn\n4. 100Azn\n5. Write Yourself\n6. LogOut");
                Console.Write("Choise : ");
                int choiser = int.Parse(Console.ReadLine());
                if (choiser == 1 )
                {
                    Console.Clear();
                    bank.Cash1(10);
                    try
                    {
                        if (bank.currentUser.CreditCard.Balance < 10)
                        {
                            throw new Exception("Have Not Enough Money For Cash");
                        }
                    }
                    catch (Exception ex ) {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choiser == 2 )
                {
                    try
                    {
                        if (bank.currentUser.CreditCard.Balance < 20)
                        {
                            throw new Exception("Have Not Enough Money For Cash");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Clear();
                    bank.Cash1(20);
                }
                else if (choiser == 3 )
                {
                    try
                    {
                        if (bank.currentUser.CreditCard.Balance < 50)
                        {
                            throw new Exception("Have Not Enough Money For Cash");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.Clear();    
                    bank.Cash1(50);
                }
                else if (choiser == 4)
                {
                    try
                    {
                        if (bank.currentUser.CreditCard.Balance < 100 || bank.currentUser.CreditCard.Balance == 0)
                        {
                            throw new Exception("Have Not Enough Money For Cash");
                        }
                    }
                    catch (Exception ex1)
                    {
                        Console.WriteLine(ex1.Message);
                    }
                    Console.Clear();
                    bank.Cash1(100);
                }
                else if (choiser == 5)
                {
                    Console.Clear();
                    try
                    {
                        Console.Write("How Much Money :");
                        amount1 = decimal.Parse(Console.ReadLine());
                        if (amount1 > bank.currentUser.CreditCard.Balance)
                        {
                            throw new Exception("Have Not Enough Money");
                        }
                        else
                        {
                            bank.Cash1(amount1);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choiser == 6)
                {
                    Console.Clear();
                    bank.Logout();
                    bank.ShowUsers();
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