using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    class PremiumAccountTests
    {
        [TestFixture]
        public class BasicAccountTests
        {
            [TestCase("33333", "Premium Account", 100, AccountType.Free, 250, 100, false)]
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, -100, 100, false)]
            [TestCase("33333", "Premium Account", 100, AccountType.Premium, 250, 350, true)]
            public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                IDeposit deposit = new NoLimitDepositRule();
                Account account = new Account();
                account.AccountNumber = accountNumber;
                account.Balance = balance;
                account.Name = name;
                account.Type = accountType;

                AccountDepositResponse response = deposit.Deposit(account, amount);

                Assert.AreEqual(expectedResult, response.Success);
                Assert.AreEqual(account.Balance, newBalance);//testing expected balance accuracy
            }

            [TestCase("55555", "Premium Account", 1500, AccountType.Premium, -2500, 1500, false)]//exceeded -500 overdraft threshold
            [TestCase("55555", "Premium Account", 100, AccountType.Free, -100, 100, false)]//invalid account type
            [TestCase("55555", "Premium Account", 100, AccountType.Premium, 100, 100, false)]//positive number withrdrawn
            [TestCase("55555", "Premium Account", 150, AccountType.Premium, -50, 100, true)]//valid withdrawal
            [TestCase("55555", "Premium Account", 100, AccountType.Premium, -150, -50, true)]//valid overdraft withdrawal
            public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
            {
                IWithdraw withdraw = new PremiumAccountWithdrawRules();
                Account account = new Account();
                account.AccountNumber = accountNumber;
                account.Balance = balance;
                account.Name = name;
                account.Type = accountType;

                AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
                Assert.AreEqual(expectedResult, response.Success);
                Assert.AreEqual(account.Balance, newBalance);//testing expected balance accuracy
            }
        }
    }
}
