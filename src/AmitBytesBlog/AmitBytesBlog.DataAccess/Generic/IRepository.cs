using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AmitBytesBlog.DataAccess
{
    public interface IRepository<TEntity> where TEntity: class
    {
        string CurrentUserId { get; set; }
        TEntity FindById(Expression<Func<TEntity,bool>> expression);
        TEntity FindOne(FilterDefinition<TEntity> filterDefinition);
        List<TEntity> FindAll();

        List<TEntity> FindAllByQuery(FilterDefinition<TEntity> filter);

        bool DeleteById(Expression<Func<TEntity, bool>> expression);
        bool DeleteOne(FilterDefinition<TEntity> filterDefinition);
        bool DeleteMany(List<string> ids);

        bool UpdateById(string id, TEntity entity);
        bool UpdateOne(Expression<Func<TEntity, bool>> expression, TEntity entity);
        bool UpdateOne(FilterDefinition<TEntity> filterDefinition, TEntity entity);

        string InsertOne(TEntity entity);

    }
}
