using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using BE = AmitBytesBlog.Entity;
namespace AmitBytesBlog.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BE.EntityBase
    {
        #region Fields

        string _connectionString { get; set; }
        string _collectionName { get; set; }
        string _databaseName { get; set; }

        static IMongoClient _mongoClient;
        #endregion

        #region Constructor
        public Repository()
        {
            _connectionString = BE.Global.MongoDb.ConnectionString;
            _databaseName = BE.Global.MongoDb.Database;
            _collectionName = typeof(TEntity).Name;
        }
        public Repository(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _collectionName = typeof(TEntity).Name;
            _databaseName = databaseName;
        }
        #endregion

        public string CurrentUserId { get; set; }

        protected IMongoCollection<TEntity> Collection
        {
            get
            {
                _mongoClient = new MongoClient(_connectionString);
                var _database = _mongoClient.GetDatabase(_databaseName);
                return _database.GetCollection<TEntity>(_collectionName);
            }
        }


        public TEntity FindById(Expression<Func<TEntity, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefault();
        }

        public TEntity FindOne(FilterDefinition<TEntity> filterDefinition)
        {
            return Collection.Find(filterDefinition).FirstOrDefault();
        }

        public List<TEntity> FindAll()
        {
            return Collection.Find(Builders<TEntity>.Filter.Empty).ToList();
        }

        public bool DeleteById(Expression<Func<TEntity, bool>> expression)
        {
            var result = Collection.DeleteOne<TEntity>(expression);
            return result.DeletedCount == 1;
        }

        public bool DeleteOne(FilterDefinition<TEntity> filterDefinition)
        {
            var result = Collection.FindOneAndDelete<TEntity>(filterDefinition);
            return result != null;
        }

        public bool DeleteMany(List<string> Ids)
        {
            //var fields = Ids.Select(i => new ObjectId(i)).ToList();
            var filters  = Builders<TEntity>.Filter.In(p => p.Id, Ids);
            var result = Collection.DeleteMany(filters);
            return result.DeletedCount == Ids.Count();
        }


        public bool UpdateById(string Id, TEntity entity)
        {

            var result  = Collection.UpdateOne<TEntity>(p => p.Id == Id, GetUpdateQuery(entity));
            return result.ModifiedCount == 1;
        }

        public bool UpdateOne(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            UpdateOptions updateOptions = new UpdateOptions() { IsUpsert = true };
            var result  = Collection.UpdateOne<TEntity>(expression, GetUpdateQuery(entity),updateOptions);
            return result.ModifiedCount == 1;
        }

        public bool UpdateOne(FilterDefinition<TEntity> filterDefinition, TEntity entity)
        {
            UpdateOptions updateOptions = new UpdateOptions() { IsUpsert = true };
            var result  = Collection.UpdateOne(filterDefinition, GetUpdateQuery(entity),updateOptions);
            return result.ModifiedCount == 1;
        }

        public string InsertOne(TEntity entity)
        {
            entity.CreatedBy = CurrentUserId;
            entity.CreatedOn = DateTime.Now;
            entity.VersionNo = 1;
            entity.IsActive = true;
            entity.Id = entity.NewObjectId;
            Collection.InsertOne(entity);
            return entity.Id.ToString();
        }




        #region Helper Method
        protected UpdateDefinition<TEntity> GetUpdateQuery(TEntity entity)
        {
            var updateDefinition = Builders<TEntity>.Update
            .Set(p => p.UpdatedOn, DateTime.Now)
            .Set(p => p.UpdatedBy,CurrentUserId)
            .Inc(p => p.VersionNo, 1);
            var updateDefinitionList = new List<UpdateDefinition<TEntity>>();
            updateDefinitionList.Add(updateDefinition);
            foreach (var prop in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var value = prop.GetGetMethod().Invoke(entity, null);
                updateDefinitionList.Add(Builders<TEntity>.Update.Set(prop.Name, value));
            }
            return Builders<TEntity>.Update.Combine(updateDefinitionList);
        }

        public List<TEntity> FindAllByQuery(FilterDefinition<TEntity> filterDefinition)
        {
            return Collection.Find(filterDefinition).ToList();
        }











        #endregion
    }
}
