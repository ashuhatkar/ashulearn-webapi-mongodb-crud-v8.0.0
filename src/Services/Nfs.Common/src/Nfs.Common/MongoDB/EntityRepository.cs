/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System
  --*                   System.Collection.Generic ...
  --* Description     : Represents a entity repository
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using MongoDB.Driver;

namespace Nfs.Common.MongoDB
{
    /// <summary>
    /// Represents the entity repository implementation
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IMongoCollection<TEntity> _dbCollection;
        private readonly FilterDefinitionBuilder<TEntity> filterDefinitionBuilder = Builders<TEntity>.Filter;

        #endregion

        #region Ctor

        public EntityRepository(IMongoDatabase database, string collectionName)
        {
            _dbCollection = database.GetCollection<TEntity>(collectionName);
        }

        #endregion

        #region Methods

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true)
        {
            return await _dbCollection.Find(filterDefinitionBuilder.Empty).ToListAsync();
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbCollection.Find(filter).ToListAsync();
        }

        public IReadOnlyCollection<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            bool includeDeleted = true)
        {
            return _dbCollection.Find(filterDefinitionBuilder.Empty).ToList();
        }

        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref="" /> entities)</param>
        /// <returns>
        /// A task that represents the asychronous operation
        /// The task result contains the entity entry
        /// </returns>
        public virtual async Task<TEntity> GetByIdAsync(Guid? id, bool includeDeleted = true)
        {
            if (!id.HasValue)
                return null;

            FilterDefinition<TEntity> filter = filterDefinitionBuilder.Eq(entity => entity.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get entity entries by identifiers
        /// </summary>
        /// <param name="ids">Entity entry identifier</param>
        /// <param name="includeDeleted">Whether to include deleted items (applies only to <see cref=""/> entities)</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the entity entries
        /// </returns>
        public virtual async Task<IReadOnlyCollection<TEntity>> GetByIdsAsync(IList<int> ids,
            bool includeDeleted = true)
        {
            if (!ids?.Any() ?? true)
                return new List<TEntity>();

            return null;
        }

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbCollection.InsertOneAsync(entity);

            //event notification
            //if (publishEvent) //logic
        }

        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //_dbCollection.Insert(entity);

            //event notification
            //if (publishEvent) //logic
        }

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertAsync(IReadOnlyCollection<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (!publishEvent)
                return;

            //event notfication
            foreach (var entity in entities)
            {
            }
        }

        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(IReadOnlyCollection<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (!publishEvent)
                return;

            //event notification
            foreach (var entity in entities)
            {
            }
        }

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            FilterDefinition<TEntity> filter = filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _dbCollection.ReplaceOneAsync(filter, entity);

            //event notification
            //if (publishEvent) //logic
        }

        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //event notification
            //if (publishEvent) //logic
        }

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateAsync(IReadOnlyCollection<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (entities.Count == 0)
                return;

            //data logic

            //event notification
            if (!publishEvent)
                return;

            foreach (var entity in entities)
            {
            }
        }

        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(IReadOnlyCollection<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (entities.Count == 0)
                return;

            //data logic

            //event notification
            if (!publishEvent)
                return;

            foreach (var entity in entities)
            {
            }
        }

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual async Task DeleteAsync(Guid id, bool publishEvent = true)
        {
            FilterDefinition<TEntity> filter = filterDefinitionBuilder.Eq(entity => entity.Id, id);
            await _dbCollection.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteAsync(TEntity entity, bool publishEvent = true)
        {
            switch (entity)
            {
                case null:
                    throw new ArgumentNullException(nameof(entity));

                default:
                    //await dbCollection.DeleteOneAsync(entity);
                    break;
            }

            //event notfication
            //if (publishEvent) //logic
        }

        /// <summary>
        /// Delete entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        /// <returns>A task that represents the asycnhr</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteAsync(IList<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                FilterDefinition<TEntity> filter = filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
                await _dbCollection.DeleteOneAsync(filter);
            }
        }

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the number of deleted records
        /// </returns>
        public virtual async Task<DeleteResult> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var countDeletedRecords = await _dbCollection.DeleteManyAsync(predicate);
            transaction.Complete();

            return countDeletedRecords;
        }

        /// <summary>
        /// Delete entity entries by the passed predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>
        /// A number of deleted records
        /// </returns>
        public virtual DeleteResult Delete(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var countDeletedRecords = _dbCollection.DeleteMany(predicate);
            transaction.Complete();

            return countDeletedRecords;
        }

        #endregion
    }
}