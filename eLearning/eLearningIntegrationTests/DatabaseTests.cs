using eLearning.Business_Logic;
using eLearning.BusinessLogic;
using eLearning.DAL;
using eLearning.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace eLearningIntegrationTests
{
    [TestClass()]
    public class DatabaseTests
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=VendingMachine;Integrated Security=true";
        private TransactionScope _tran = null;
        private IUserDAL _userdb = null;

        private int _userId1 = BaseItem.InvalidId;
        private int _userId2 = BaseItem.InvalidId;

        /// <summary>
        /// Set up the database before each test  
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _userdb = new UserDAL(_connectionString);

            _tran = new TransactionScope();

            PasswordManager passHelper = new PasswordManager("Abcd!234");
            if (_userId1 == BaseItem.InvalidId)
            {
                var temp = new UserItem() { Id = BaseItem.InvalidId };
                temp.FirstName = "Mark";
                temp.LastName = "Jones";
                temp.Username = "mjones";
                temp.Hash = passHelper.Hash;
                temp.Salt = passHelper.Salt;
                temp.Email = "mjones@gmail.com";
                temp.RoleId = (int)RoleManager.eRole.Student;

                _userId1 = _userdb.AddUserItem(temp);
                Assert.AreNotEqual(0, _userId1);
            }
            if (_userId2 == BaseItem.InvalidId)
            {
                var temp = new UserItem() { Id = BaseItem.InvalidId };
                temp.FirstName = "Chloe";
                temp.LastName = "Rupp";
                temp.Username = "ccr";
                temp.Hash = passHelper.Hash;
                temp.Salt = passHelper.Salt;
                temp.Email = "chloe@tech.com";
                temp.RoleId = (int)RoleManager.eRole.Student;

                _userId2 = _userdb.AddUserItem(temp);
                Assert.AreNotEqual(0, _userId2);
            }
        }

        /// <summary>
        /// Cleanup runs after every single test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back

        }

        /// <summary>
        /// Tests the user methods
        /// </summary>
        [TestMethod()]
        public void TestUser()
        {
            PasswordManager passHelper = new PasswordManager("Abcd!234");

            // Test add user
            UserItem item = new UserItem();
            item.FirstName = "George";
            item.LastName = "Smith";
            item.Username = "gsmith";
            item.Hash = passHelper.Hash;
            item.Salt = passHelper.Salt;
            item.Email = "george@gmail.com";
            item.RoleId = (int)RoleManager.eRole.Student;
            int id = _userdb.AddUserItem(item);
            Assert.AreNotEqual(0, id);

            UserItem itemGet = _userdb.GetUserItem(id);
            Assert.AreEqual(item.Id, itemGet.Id);
            Assert.AreEqual(item.FirstName, itemGet.FirstName);
            Assert.AreEqual(item.LastName, itemGet.LastName);
            Assert.AreEqual(item.Username, itemGet.Username);
            Assert.AreEqual(item.Hash, itemGet.Hash);
            Assert.AreEqual(item.Salt, itemGet.Salt);
            Assert.AreEqual(item.Email, itemGet.Email);
        }
    }
}
