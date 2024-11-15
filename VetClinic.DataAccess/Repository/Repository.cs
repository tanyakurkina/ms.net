﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VetClinic.DataAccess.Entities;

namespace VetClinic.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<DbContext> _contextFactory;

    public Repository(IDbContextFactory<DbContext> contextFactory) 
        => _contextFactory = contextFactory;
    

    public IQueryable<T> GetAll()
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().Where(predicate);
    }

    public T? GetById(int id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public T? GetById(Guid id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().FirstOrDefault(x => x.ExternalId == id);
    }

    public T Save(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        if (dbContext.Set<T>().Any(x => x.Id == entity.Id))
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = DateTime.UtcNow;
            entity.ModificationTime = entity.CreationTime;
            var result = dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        dbContext.Set<T>().Remove(entity);
        dbContext.SaveChanges();
    }
}