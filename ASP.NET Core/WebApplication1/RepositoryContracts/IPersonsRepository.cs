using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Person entity
    /// </summary>
    public interface IPersonsRepository
    {
        /// <summary>
        /// Adds a person object to the dataa store
        /// </summary>
        /// <param name="person">Person object to add</param>
        /// <returns>Returns the person object after adding it to the data store</returns>
        Task<Person> AddPerson(Person person);

        /// <summary>
        /// Returns all persons in the data store
        /// </summary>
        /// <returns></returns>
        Task<List<Person>> GetAllPersons();

        /// <summary>
        /// Returns a person object based on the given personID
        /// </summary>
        /// <param name="personID">PersonID (Guid) to search</param>
        /// <returns>Matching person object or null</returns>
        Task<Person?> GetPersonByPersonID(Guid personID);

        /// <summary>
        /// Returns all the person objects based on the given expression
        /// </summary>
        /// <param name="predicate">LINQ expression to check</param>
        /// <returns>All matching persons with given condition</returns>
        Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate);

        /// <summary>
        /// Deletes a person object based on the personID
        /// </summary>
        /// <param name="personID">personID (Guid) to search</param>
        /// <returns>Returns true, if the deletion is successful; otherwise false</returns>
        Task<bool> DeletePersonByPersonID(Guid personID);

        /// <summary>
        /// Updates a person object (person name and other details) based on the given person
        /// </summary>
        /// <param name="person">Person object to update</param>
        /// <returns>Returns the updated person object</returns>
        Task<Person> UpdatePerson(Person person);
    }
}
