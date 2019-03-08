using System;
using System.Collections.Generic;

namespace TheBank_NetCore
{
    public class TheBank: IBank
    {
        Dictionary<string, Balance> listOfAccounts = new Dictionary<string, Balance>();

        public bool AccountExists(string accountHolder)
        {
            return listOfAccounts.ContainsKey(accountHolder);
        }

        public void CreateAccount(string accountHolder)
        {
            Balance newAccount = new Balance(accountHolder);
            listOfAccounts.Add(accountHolder, newAccount);
        }

        public void Deposit(string accountHolder, decimal amount)
        {
            if (AccountExists(accountHolder) == true)
            {
                listOfAccounts[accountHolder].Deposit(amount);
            }
        }

        public decimal GetBalance(string accountHolder)
        {
            AccountExists(accountHolder);
            return listOfAccounts[accountHolder].GetBalance;
           
        }

        public bool Transfer(string fromAccount, string toAccount, decimal amount)
        {
            try
            {
                if (AccountExists(fromAccount) && AccountExists(toAccount) == true)
                {
                    listOfAccounts[fromAccount].Withdraw(amount);
                    listOfAccounts[toAccount].Deposit(amount);
                    return true;
                }
          
            }
            catch (TransferNotPossibleException)
            {
                return false;
            }
            return false;

        }

        public bool Withdraw(string accountHolder, decimal amount)
        {
            if (AccountExists(accountHolder))
            {
                listOfAccounts[accountHolder].Withdraw(amount);
                return true;
            }
            return false;
        }
    }
}
