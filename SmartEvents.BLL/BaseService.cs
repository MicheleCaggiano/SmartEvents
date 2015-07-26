using System;
using System.Linq;
using System.Linq.Expressions;
using SmartEvents.DAL.Interfaces;

namespace SmartEvents.BLL
{
  public abstract class BaseService<T> where T : class
  {
    protected IRepository<T> BaseRepository;

    protected BaseService(IRepository<T> baseRepository)
    {
      BaseRepository = baseRepository;
    }

    ~BaseService()
    {
      BaseRepository.Dispose();
    }
    /// <summary>
    /// Save new entity
    /// </summary>
    /// <param name="entity">Entity to save</param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Save(T entity)
    {
      if (!Validate(entity)) return false;
      BaseRepository.Create(entity);
      return BaseRepository.SaveChanges();
    }
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Update(T entity)
    {
      if (!Validate(entity)) return false;
      BaseRepository.Create(entity);
      return BaseRepository.SaveChanges();
    }
    /// <summary>
    /// DeleteById entity by primary key
    /// </summary>
    /// <param name="id">Entity id</param>
    /// <returns>True entity deleted, false otherwise</returns>
    public bool DeleteById(object id)
    {
      BaseRepository.DeleteById(id);
      return BaseRepository.SaveChanges();
    }
    /// <summary>
    /// DeleteById entity
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <returns>True entity deleted, false otherwise</returns>
    public bool Delete(T entity)
    {
      BaseRepository.Delete(entity);
      return BaseRepository.SaveChanges();
    }
    /// <summary>
    /// DeleteById entity by specified expression
    /// </summary>
    /// <param name="where">Where clause expression</param>
    /// <returns>True entity deleted, false otherwise</returns>
    public bool Delete(Expression<Func<T, bool>> @where)
    {
      BaseRepository.Delete(@where);
      return BaseRepository.SaveChanges();
    }
    /// <summary>
    /// Find first entity by specified expression
    /// </summary>
    /// <param name="where">Where clause expression</param>
    /// <returns>First entity that verified expression, null otherwise</returns>
    public T FindOne(Expression<Func<T, bool>> @where = null)
    {
      return BaseRepository.FindOne(@where);
    }
    /// <summary>
    /// Find entity by id
    /// </summary>
    /// <param name="id">Entity id to search</param>
    /// <returns>Entity with specified id, null otherwise</returns>
    public T FindById(object id)
    {
      return BaseRepository.FindById(id);
    }
    /// <summary>
    /// Find all entities
    /// </summary>
    /// <param name="where">Where clause expression</param>
    /// <returns>Returns all entities that verified where clause. If clause is null, return all entities</returns>
    public IQueryable<T> FindAll(Expression<Func<T, bool>> @where = null)
    {
      return BaseRepository.FindAll(where);
    }

    /// <summary>
    /// Entity validation
    /// </summary>
    /// <param name="entity">Entity to validate</param>
    /// <returns>True if there are no validation errors, false otherwise</returns>
    protected virtual bool Validate(T entity)
    {
      return true;
    }
  }
}
