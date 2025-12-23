namespace _28._09_hw
{

    class Passport
    {
        private string nationality;
        public string Nationality
        {
            get { return nationality; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nationality cannot be empty.");
                nationality = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First Name cannot be empty.");
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last Name cannot be empty.");
                lastName = value;
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Date of Birth cannot be in the future.");
                dateOfBirth = value;
            }
        }

        private string passportNumber;
        public string PassportNumber
        {
            get { return passportNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Passport Number cannot be empty.");
                passportNumber = value;
            }
        }

        public Passport(string nationality, string firstName, string lastName, DateTime dateOfBirth, string passportNumber)
        {
            Nationality = nationality;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PassportNumber = passportNumber;
        }

        public Passport() { }

        
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Passport Info: Nationality: {Nationality}, First name || Last name: {FirstName} {LastName}, Date of Birthday: {DateOfBirth.ToShortDateString()}, Number: {PassportNumber}");
        }
    }

    class ForeignPassport : Passport
    {
        private string foreignPassportNumber;
        public string ForeignPassportNumber
        {
            get { return foreignPassportNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Foreign Passport Number cannot be empty.");
                foreignPassportNumber = value;
            }
        }

        private string[] visas;
        public string[] Visas
        {
            get { return visas; }
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Visas cannot be empty.");
                visas = value;
            }
        }

        public ForeignPassport(string nationality, string firstName, string lastName, DateTime dateOfBirth, string passportNumber, string foreignPassportNumber, string[] visas)
            : base(nationality, firstName, lastName, dateOfBirth, passportNumber)
        {
            ForeignPassportNumber = foreignPassportNumber;
            Visas = visas;
        }

        public ForeignPassport() { Visas = new string[0]; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Foreign Passport Number: {ForeignPassportNumber}");
            string result = string.Join(", ", Visas);
            Console.WriteLine("Visas: " + result);
        }
    }

    class DiplomaticPassport : Passport
    {
        private string diplomaticRank;
        public string DiplomaticRank
        {
            get { return diplomaticRank; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Diplomatic Rank cannot be empty.");
                diplomaticRank = value;
            }
        }

        public DiplomaticPassport(string nationality, string firstName, string lastName, DateTime dateOfBirth, string passportNumber, string diplomaticRank)
            : base(nationality, firstName, lastName, dateOfBirth, passportNumber)
        {
            DiplomaticRank = diplomaticRank;
        }

        public DiplomaticPassport() { }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Diplomatic Rank: {DiplomaticRank}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Passport[] passports = new Passport[]
                {
                new Passport("Ukraine", "Ivan", "Ivanov", new DateTime(1985, 4, 23), "A1234567"),
                new ForeignPassport("Ukraine", "Petro", "Petrov", new DateTime(1990, 1, 15), "B7654321", "FP123456", new string[] { "USA", "Canada" }),
                new DiplomaticPassport("Ukraine", "Anna", "Shevchenko", new DateTime(1982, 7, 10), "C9876543", "Ambassador")
                };

                foreach (var passport in passports)
                {
                    passport.ShowInfo();
                    Console.WriteLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
