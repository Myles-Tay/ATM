using System;

namespace ATM
{
    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getCardNum()
        {
            return cardNum;
        }

        public int getPin()
        {
            return pin;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }

        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from on of the below options..");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3 .Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much £ would you like to deposit: ");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit);
                Console.WriteLine("Thank you for your £. Your new balance is: " + currentUser.getBalance());
            }

            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much £ would you like to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());
                //Check if the user has enough money
                if (currentUser.getBalance() > withdrawal)
                {
                    currentUser.setBalance(currentUser.getBalance() - withdrawal);
                    Console.WriteLine("You are good to go. Thank you.");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance : ");
                }

                void balance(cardHolder currentUser)
                {
                    Console.WriteLine("Current balance: " + currentUser.getBalance());
                }

                List<cardHolder> cardHolders = new List<cardHolder>();
                cardHolders.Add(new cardHolder("5466743228218956", 5673, "Myles", "Taylor", 654.43));
                cardHolders.Add(new cardHolder("3463788637569901", 5563, "Amelia", "Taylor", 326.97));
                cardHolders.Add(new cardHolder("6784997313575490", 4367, "Ashley", "Taylor", 1255.54));
                cardHolders.Add(new cardHolder("1364601076321148", 1904, "Maureen", "Taylor", 33.87));
                cardHolders.Add(new cardHolder("4383232198374729", 3432, "Jasmine", "Taylor", 231.66));

                //prompt user
                Console.WriteLine("Welcome To MylesATM");
                Console.WriteLine("Please insert a debit card: ");
                string debitCardNum = "";
                cardHolder currentUser;

                while (true)
                {
                    try
                    {
                        debitCardNum = Console.ReadLine();
                        //check against DB
                        currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                        if (currentUser != null) { break; }
                        else { Console.WriteLine("Card not recognised. Try again"); }
                    }
                    catch { Console.WriteLine("Card not recognised. Try again"); }

                }
                Console.WriteLine("Please enter a pin: ");
                int userPin = 0;
                while (true)
                {
                    try
                    {
                        userPin = int.Parse(Console.ReadLine());
                        //check against DB
                        if (currentUser.getPin() != userPin) { break; }
                        else { Console.WriteLine("Incorrect Pin. Try again"); }
                    }
                    catch { Console.WriteLine("Card not recognised. Try again"); }
                }

                Console.WriteLine("Welcome " + currentUser.getFirstName());
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (option == 1) { deposit(currentUser); }
                    else if (option == 2) { withdraw(currentUser); }
                    else if (option == 3) { balance(currentUser); }
                    else if (option == 4) { break; }
                    else { option = 0; }
                }
                while (option != 4);
                Console.WriteLine("Thank you. Enjoy the rest of your day");
            }

        }
    }
}
