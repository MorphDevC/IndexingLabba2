using System.Collections.Generic;
using System.Linq;

namespace IndexingLabba2
{
    
    public class Bank
    {
        private List<Account> _clientAccount = new List<Account>();

        public Bank() : this(new Account()){}

        public Bank(Account someAcc)
        {
            this._clientAccount.Add(someAcc);
        }

        public Account this[int index]
        {
            get => _clientAccount[index];
        }
        public Account this[string indexCard]
        {
            //var car = _cars.FirstOrDefault(c => c.Name == number);
            get
            {
                var acc = _clientAccount.SingleOrDefault(cc => cc.AccNumber == indexCard);
                return acc;
            }
        }
    }
}