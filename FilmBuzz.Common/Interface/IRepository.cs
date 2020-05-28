using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilmBuzz.Common.Interface
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Inserts new record into data source for entity type T 
        /// </summary>
        bool Create(T entity);

        /// <summary>
        /// Updates existing record into data source for entity type T 
        /// </summary>
        bool Update(T entity);

        /// <summary>
        /// Deletes existing record into data source for entity type T 
        /// </summary>
        bool Delete(T entity);

        /// <summary>
        /// Get all the Records
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get all records filtered by params
        /// </summary>
        IEnumerable<T> GetAllWith(object param);

        /// <summary>
        /// Get all records filtered by Expression for the given entity T
        /// </summary>
        IEnumerable<T> GetAllWith(Expression<Func<T, bool>> Expression);
    }
}
