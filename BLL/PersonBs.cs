using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using Framework.Shared;


namespace BLL
{

    public class PersonBs
    {
        private GenericRepository<Person> objDb;
        private GenericRepository<AgeGroup> objDbAgeGroup;
        public PersonBs()
        {
            objDb = new GenericRepository<Person>();
            objDbAgeGroup = new GenericRepository<AgeGroup>();
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAll()
        {
            try
            {
                // Build custom Person with AgeGroup property
                var result = (from p in objDb.GetAll().ToList()
                              select new Person
                              {
                                  Id = p.Id,
                                  Age = p.Age,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  AgeGroup = GetAnAgeGroup(p.Age.Value)
                              });
                return result;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Get an age group by age
        /// </summary>
        /// <returns></returns>
        public string GetAnAgeGroup(int age)
        {
            try
            {
                string ageGroup =  objDbAgeGroup.GetAll().Where(p => age >= p.MinAge && age < (p.MaxAge != null? p.MaxAge:int.MaxValue)).FirstOrDefault().Description;
                return ageGroup;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetByID(int id)
        {
            return objDb.GetByID(id);
        }

        /// <summary>
        /// Insert a person
        /// </summary>
        /// <param name="person"></param>
        public void Insert(Person person)
        {
            try
            {
                objDb.Insert(person);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Delete a person
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                objDb.Delete(id);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Update a person
        /// </summary>
        /// <param name="person"></param>
        public void Update(Person person)
        {
            try
            {
                objDb.Update(person);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
            
        }
    }
}
