namespace _06._09_сw
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string CardNumber { get; private set; }
        public string MMGG { get; private set; }
        public string CVC { get; private set; }
        public decimal Balance { get; set; }

        public CreditCard(string _name, string _cardNumber, string _expiryDate, string _cvc, decimal _Balance)
        {
            Name = _name;
            CardNumber = _cardNumber;
            MMGG = _expiryDate;
            CVC = _cvc;
            Balance = _Balance;
        }

        public static CreditCard operator +(CreditCard card, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The amount to add must be positive.");
            }

            card.Balance += amount;
            return card;
        }

        public static CreditCard operator -(CreditCard card, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The amount to withdraw must be positive.");
            }

            if (card.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds to complete the operation.");
            }

            card.Balance -= amount;
            return card;
        }


        public static bool operator ==(CreditCard card1, CreditCard card2) => card1.CVC == card2.CVC;

        public static bool operator !=(CreditCard card1, CreditCard card2) => card1.CVC != card2.CVC;

        public static bool operator <(CreditCard card1, CreditCard card2) => card1.Balance < card2.Balance;

        public static bool operator >(CreditCard card1, CreditCard card2) => card1.Balance > card2.Balance;

        public override bool Equals(object obj) => obj is CreditCard card && this.CVC == card.CVC;
        public override int GetHashCode() => CVC.GetHashCode();

        public static bool operator true(CreditCard card) => card.Balance > 0;

        public static bool operator false(CreditCard card) => card.Balance <= 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreditCard card1 = new CreditCard("Niga", "1234 5678 9101 1121", "12/25", "123", 500.00m);
            CreditCard card2 = new CreditCard("Migel", "9876 5432 1098 7654", "11/26", "456", 300.00m);

            card1 += 200.00m;
            card2 -= 50.00m;

            Console.WriteLine($"Balance on {card1.Name}'s card: {card1.Balance}");
            Console.WriteLine($"Balance on {card2.Name}'s card: {card2.Balance}");

            Console.WriteLine(card1 == card2);
            Console.WriteLine(card1 != card2);

            Console.WriteLine(card1 > card2);
            Console.WriteLine(card1 < card2);

            if (card1)
            {
                Console.WriteLine($"There is money on {card1.Name}'s card.");
            }
            else
            {
                Console.WriteLine($"There is no money on {card1.Name}'s card.");
            }

            if (card2)
            {
                Console.WriteLine($"There is no money on {card2.Name}'s card.");
            }
            else
            {
                Console.WriteLine($"There is money on {card2.Name}'s card.");
            }
        }
    }
}

