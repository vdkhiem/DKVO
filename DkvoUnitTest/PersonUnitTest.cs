using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BOL;
using Framework.Shared;

namespace DkvoUnitTest
{
    [TestClass]
    public class PersonUnitTest
    {
        protected PersonBs objBs;
        public PersonUnitTest()
        {
            objBs = new PersonBs();
        }
            

        [TestMethod]
        public void TestInsertPersonPositive()
        {   
            Person person = new Person()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Age = 150
            };

            objBs.Insert(person);
            Person expectedPerson = objBs.GetByID(person.Id);
            if (person.FirstName == expectedPerson.FirstName && person.LastName == expectedPerson.LastName && person.Age == expectedPerson.Age)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
            objBs.Delete(person.Id);

        }

        [TestMethod]
        public void TestInsertPersonNegative()
        {
            Person person = new Person()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Age = 150
            };

            objBs.Insert(person);

            Person anotherPerson = new Person()
            {
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Age = 151
            };

            objBs.Insert(anotherPerson);
            
            if (person.FirstName != anotherPerson.FirstName || person.LastName != anotherPerson.LastName || person.Age != anotherPerson.Age)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
            objBs.Delete(person.Id);
            objBs.Delete(anotherPerson.Id);
        }

        [TestMethod]
        public void TestInsertPersonDestructive()
        {
            Person person = null;
            objBs.Insert(person);
            Assert.IsTrue(true);
        }
    }
}
