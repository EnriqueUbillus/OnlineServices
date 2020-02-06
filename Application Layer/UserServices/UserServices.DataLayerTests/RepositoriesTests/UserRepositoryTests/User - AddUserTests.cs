﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.UserRepositoryTests
{
    [TestClass]
    public class User_AddUserTests
    {
        [TestMethod]
        public void UserRepositoryInsertInDB_WhenValid()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var RSCxt = new RegistrationContext(options))
            {
                //Arrange
                var userToUse = new UserTO()
                {
                    Id = 0,
                    Name = "Thomas Lion",
                    Role = UserRole.Assistant,
                    Email = "MaxFuel@Power.com",
                    Company = "Business Formation",
                    IsActivated = true,
                };

                var userRepository = new UserRepository(RSCxt);
                //Act
                userRepository.Add(userToUse);
                RSCxt.SaveChanges();
                //Assert
                Assert.AreEqual(1, userRepository.GetAll().Count());
                //var userToAssert = userRepository.GetById(1);
            }
        }
        [Ignore]
        [TestMethod()]
        public void UserRepositoryNotInsertInDB_WhenInvalid()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var RSCxt = new RegistrationContext(options))
            {
                //Arrange
                var userToUseValid1 = new UserTO()
                {
                    Id = 5,
                    Name = "Thomas Lion",
                    Role = UserRole.Assistant,
                    Email = "MaxFuel@Power.com",
                    Company = "Business Formation",
                    IsActivated = true,
                };
                var userToUseValid2 = new UserTO()
                {
                    Id = 6,
                    Name = "Sylvain LELELEDEPE",
                    Role = UserRole.Teacher,
                    Email = "LELELE@Power.com",
                    Company = "Brussels Training",
                    IsActivated = true,
                };
                var userToUseInvalid = new UserTO()
                {
                    Id = 7,
                    Name = null,
                    Role = UserRole.Attendee,
                    Email = "",
                    Company = null,
                    IsActivated = false,
                };

                var userRepository = new UserRepository(RSCxt);
                //Act
                userRepository.Add(userToUseValid1);
                userRepository.Add(userToUseValid2);
                userRepository.Add(userToUseInvalid);
                RSCxt.SaveChanges();
                //Assert

                Assert.AreEqual(3, userRepository.GetAll().Count());
            }
        }
    }
}
