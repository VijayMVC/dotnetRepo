using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        List<Account> _allAccounts = new List<Account>();
        private string _filepath;
        public FileAccountRepository(string filepath)
        {
                _filepath = filepath;
                List();
        }

        public void List()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filepath))
                {
                    decimal balance = 0;
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Account newAccount = new Account();

                        string[] columns = line.Split(',');
                        newAccount.AccountNumber = columns[0];
                        newAccount.Name = columns[1];
                        decimal.TryParse(columns[2], out balance);
                        newAccount.Balance = balance;
                        newAccount.Type = ConvertToAccountType(columns[3]);

                        _allAccounts.Add(newAccount);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file: {_filepath} was not found.\nVerify file path is correct.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private AccountType ConvertToAccountType(string v)
        {
            switch(v)
            {
                case "F":
                    return AccountType.Free;
                case "B":
                    return AccountType.Basic;
                default:
                    return AccountType.Premium;
            }
        }

        public Account LoadAccount(string AccountNumber)
        {
            var Accounts = _allAccounts.SingleOrDefault(a => a.AccountNumber == AccountNumber);
            return Accounts;
        }

        public void SaveAccount(Account account)
        {
            CreateAccountFile(_allAccounts);
        }
        private string CreatCsvForAccount(Account account)
        {
            return string.Format("{0},{1},{2},{3}", account.AccountNumber,
                    account.Name, account.Balance, ConvertToString(account.Type));
        }

        public string ConvertToString(AccountType accountType)
        {
            string toString;

            switch(accountType)
            {
                case AccountType.Free:
                    toString = "F";
                    break;
                case AccountType.Basic:
                    toString = "B";
                    break;
                default:
                    toString = "P";
                    break;
            }
            return toString;
        }

        private void CreateAccountFile(List<Account> accounts)
        {
            if (File.Exists(_filepath))
                File.Delete(_filepath);
            using (StreamWriter sr = new StreamWriter(_filepath))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var row in _allAccounts)
                {
                    sr.WriteLine(CreatCsvForAccount(row));
                }
            }
        }
    }
}
