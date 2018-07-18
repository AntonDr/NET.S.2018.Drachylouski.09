using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AccountNS;
using DAL.Interface;

namespace DAL
{
    public class FakeRepository : IRepository<Account>
    {
        private List<Account> firstData = new List<Account>();
        private List<AccountHolder> lastData = new List<AccountHolder>();


        public void Create(Account item)
        {
            firstData.Add(item);
            if (!lastData.Contains(item.Holder))
            {
                lastData.Add(item.Holder);
            }
        }

        public void Update(Account item)
        {
            Account account = firstData.Find(x => x.Id == item.Id);
            int index = firstData.IndexOf(account);
            firstData[index] = item;
        }

        public Account GetById(string id)
        {
            Account account = firstData.Find(x => x.Id == id);

            if (!firstData.Contains(account))
            {
                throw new ArgumentException($"Invalid {nameof(id)}");
            }

            return account;
        }
    }
}
