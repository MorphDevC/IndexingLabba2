using System;

namespace IndexingLabba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account
                ("Alexander",
                "Alexandrovich",
                "Pie",
                "1234 5678 9586 9333",
                0,
                DateTime.Now,
                DateTime.Now.AddYears(4),
                DateTime.Now.AddYears(4),
                "Ruble");
            
            Account account2 = new Account
            ("Ivan",
                "Ivanovich",
                "Ivanov",
                "3333 3333 3333 3333",
                0,
                DateTime.Now,
                DateTime.Now.AddYears(4),
                DateTime.Now.AddYears(4),
                "Ruble");
            Console.WriteLine(account.GetInfoAcc()+"\n\n");
            Console.WriteLine(account2.GetInfoAcc()+"\n\n");
            var k = account + account2;
            Console.WriteLine(k[0].GetInfoAcc()+"\n");
            
            Console.WriteLine(account.TopUpBalance(5000));
            
            Console.WriteLine(account.WithdrawBalamce(6000));

            Bank bank = new Bank(account);
            Console.WriteLine("Bank acc: \n"+bank["1234 5678 9586 9333"].GetInfoAcc());

        }
    }
}