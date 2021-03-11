using System;
using System.Collections.Generic;
using System.Linq;

namespace IndexingLabba2
{
    // private List<Person> _personNames = new List<Person>();
    // private List<string> _accNumber;
    // private List<float> _accMoney;
    // private List<DateTime> _accCreated;
    // private List<DateTime> _accFired;
    // private List<DateTime> _accClosed;
    // private List<string> _accType;
    // private static int _id=10000;
    
    // private Person _personNames = new Person();
    // private string _accNumber;
    // private float _accMoney;
    // private DateTime _accCreated;
    // private DateTime _accFired;
    // private DateTime _accClosed;
    // private string _accType;
    // private static int _id=10000;

    
    public class Account
    {
        private Person _personNames = new Person();
        private string _accNumber; // List
        private float _accMoney;
        private DateTime _accCreated;
        private DateTime _accFired;
        private DateTime _accClosed;
        private string _accType;
        private static int _idCounts=0; //List
        private int _id = 0;

        public Account():this("Name is not set"){}
        public Account(string name)
                :this(name,"Secondname is not set"){}
        public Account(string name, string secondName)
                :this(name, secondName,"Surname is not set"){}
        public Account(string name, string secondName, string surname)
                :this (name,secondName,surname, default){ }
        public Account(string name, string secondName, string surname, string accNumber)
                :this (name,secondName,surname, accNumber,0){ }
        public Account(string name, string secondName, string surname, string accNumber, float accMoney)
                :this (name,secondName,surname, accNumber,accMoney,new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,00,00,00)){ }

        public Account(string name, string secondName, string surname, string accNumber, float accMoney, DateTime accCreated)
                :this (name,secondName,surname, accNumber,accMoney,accCreated,new DateTime(0001,01,1,00,00,0)){ }
        public Account(string name, string secondName, string surname, string accNumber, float accMoney, DateTime accCreated, DateTime accFired)
                :this (name,secondName,surname, accNumber,accMoney,accCreated,accFired, new DateTime(DateTime.Now.Year,DateTime.Now.Month,(DateTime.Now.Day+1),00,00,00)){ }
        public Account(string name, string secondName, string surname, string accNumber, float accMoney, DateTime accCreated, DateTime accFired, DateTime accClosed)
                :this (name,secondName,surname, accNumber,accMoney,accCreated,accFired,accClosed,"Type is not set"){ }
        public Account(string name, string secondName, string surname, string accNumber, float accMoney, DateTime accCreated, DateTime accFired, DateTime accClosed, string accType)
            :this (name,secondName,surname, accNumber,accMoney,accCreated,accFired,accClosed,accType, "Passport is not set"){ }

        public Account
        (
            string name,
            string secondName,
            string surname,
            string accNumber,
            float accMoney,
            DateTime accCreated,
            DateTime accFired,
            DateTime accClosed,
            string accType,
            string passport
        )
        {
            PersonNames.FirstName = name;
            PersonNames.SecondName = secondName;
            PersonNames.SurName = surname;
            if (!string.IsNullOrEmpty(accNumber))
            {
                decimal k = Convert.ToDecimal(accNumber);
                AccNumber = k.ToString("#### #### #### ####");
            }
            else
                AccNumber = accNumber;
            AccMoney = accMoney;
            AccCreated = accCreated;
            AccFired = accFired;
            AccClosed = accClosed;
            AccType = accType;
            _idCounts++;
            _id = _idCounts;
        }

        public string TopUpBalance(float sum)
        {
            AccMoney += sum;
            return $"You top upped your balance for {sum}$\nYour balance is:{AccMoney}";
        }

        public string WithdrawBalamce(float sum)
        {
            if(AccMoney>sum)
            {
                AccMoney -= sum;
                return $"You withdrawed {sum}$\nYour balance is:{AccMoney}";
            }
            else
            {
                return "Not enought money on balance\nPlease top up balance and try it again";
            }
        }

        public string GetInfoAcc()
        {
            
            return $"Name: {PersonNames.FirstName}\n" +
                   $"Name: {PersonNames.SecondName}\n" +
                   $"Name: {PersonNames.SurName}\n" +
                   $"Account number: {AccNumber}\n" +
                   $"Money contains: {AccMoney}\n" +
                   $"Date creation: {AccCreated}\n" +
                   $"Date firing: {AccFired}\n" +
                   $"Date closing: {AccClosed}\n" +
                   $"Account type: {AccType}\n" +
                   $"ID: {Id}";
        }

        public string GetBalance
        {
            get => $"Money contains: {AccMoney}\n";
        }
        
        public Person PersonNames
        {
            get => _personNames;
            set => _personNames = value;
        }
        
        public string AccNumber
        {
            get => _accNumber;
            set => _accNumber = value;
        }
        
        private float AccMoney
        {
            get => _accMoney;
            set => _accMoney = value;
        }
        
        public DateTime AccCreated
        {
            get => _accCreated;
            set => _accCreated = value;
        }
        
        public DateTime AccFired
        {
            get => _accFired;
            set => _accFired = value;
        }
        
        public DateTime AccClosed
        {
            get => _accClosed;
            set => _accClosed = value;
        }
        
        public string AccType
        {
            get => _accType;
            set => _accType = value;
        }

        public int Id => _id;

        // public Account this[int index]
        // {
        //     get => 
        // }
        //
        public static Account operator +(Account one, Account two)
        {
            Account newAcc = new Account();
            newAcc.PersonNames = one.PersonNames;
            newAcc.AccNumber = one.AccNumber.RandNumber() + two.AccNumber.RandNumber();
            newAcc.AccMoney = one.AccMoney + two.AccMoney;
            newAcc.AccCreated = DateTime.Today;
            newAcc.AccFired = newAcc.AccCreated.AddYears(4);
            newAcc.AccClosed = newAcc.AccFired;
            newAcc.AccType = one.AccType;
            newAcc._id = (_idCounts - 1);
            
            _idCounts--;
            return newAcc;
        }
    }

    public class Person
    {
        private string _firstName;
        private string _secondName;
        private string _surName;
        private string _passport;

        
        public string FirstName
        {
            get => _firstName;
            set=> _firstName = value;
        }

        public string SecondName
        {
            get => _secondName;
            set => _secondName = value;
        }

        public string SurName
        {
            get => _surName;
            set => _surName = value;
        }
        
        

        public string GetNames
        {
            get => $"{FirstName} {SecondName} {SurName}";
        }

        public string Passport
        {
            get => _passport;
            set => _passport = value;
        }
    }

    public static class SomeExt
    {
        public static string Mask(this string value, string mask, char substituteChar = '#')
        {
            int valueIndex = 0;
            try
            {
                return new string(mask.Select(maskChar => maskChar == substituteChar ? value[valueIndex++] : maskChar).ToArray());
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception("Value too short to substitute all substitute characters in the mask", e);
            }
        }

        public static string RandNumber(this string value)
        {
            Random rnd = new Random();
            string retString = default;
            string[] celss = value.Trim().Split(new char[] {' '});
            for (int i = 0; i < 2; i++)
            {
                int someInt = Convert.ToInt32(celss[i]);
                someInt = rnd.Next(1000, someInt);
                retString += (Convert.ToString(someInt) + " ");
            }

            return retString;
        }
    }

}