using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    public class FileRepoTests
    {
        private const string _seedpath = @"C:\Repos\dotnet-jake-ganser\SGBankAssignment\SGBank.Data\AccountsSeedData.txt";
        private const string _testpath = @"C:\Repos\dotnet-jake-ganser\SGBankAssignment\SGBank.Data\AccountsTestData.txt";

        [SetUp]
        public void setup()
        {
            if (File.Exists(_testpath))
            {
                File.Delete(_testpath);
            }
            File.Copy(_seedpath, _testpath);
        }

        [Test]
        public void CanReadDataFromFile()
        {
            FileAccountRepository repo = new FileAccountRepository(_testpath);
            Account account = repo.LoadAccount("33333");

            Assert.AreEqual("33333", account.AccountNumber);
            Assert.AreEqual("Premium Customer", account.Name);
            Assert.AreEqual(1000, account.Balance);
            Assert.AreEqual(AccountType.Premium, account.Type);
        }     
    }
}
