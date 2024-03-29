﻿/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System
  --*                   System.Collection.Generic ...
  --* Description     : IRepository
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Nfs.Common
{
    /// <summary>
    /// Represents an entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="includeDeleted">Whether to incldue deleted items (applies only to <see cref=""/> entities)</param>
        /// <returns>Entity entries</returns>
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="filter">A function to test each element for a condition</param>
        /// <returns>The task result contains the number of deleted records</returns>
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref=""/> entities)</param>
        /// <returns>Entity entries</returns>
        IReadOnlyCollection<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true);

        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="includeDeleted">Whether to incldue deleted items (applies only to <see cref=""/> entities)</param>
        /// <returns>Entity entry</returns>
        Task<TEntity> GetByIdAsync(Guid? id, bool includeDeleted = true);

        /// <summary>
        /// Get entity entry
        /// </summary>
        /// <param name="filter">A function to test each element for a condition</param>
        /// <returns>The entity entry</returns>
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get entity entries by identifiers 
        /// </summary>
        /// <param name="ids">Entity entry identifiers</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref=""/> entities)</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<TEntity>> GetByIdsAsync(IList<int> ids, bool includeDeleted = true);

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task InsertAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        void Insert(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task InsertAsync(IReadOnlyCollection<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        void Insert(IReadOnlyCollection<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish veent notification</param>
        /// <returns>A async task</returns>
        Task UpdateAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        void Update(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task UpdateAsync(IReadOnlyCollection<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        void Update(IReadOnlyCollection<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task DeleteAsync(Guid id, bool publishEvent = true);

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task DeleteAsync(TEntity entity, bool publishEvent = true);

        /// <summary>
        /// Delete entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A async task</returns>
        Task DeleteAsync(IList<TEntity> entities, bool publishEvent = true);

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The task result contains the number of deleted records</returns>
        Task<DeleteResult> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// A number of deleted records
        /// </returns>
        DeleteResult Delete(Expression<Func<TEntity, bool>> predicate);
    }
}