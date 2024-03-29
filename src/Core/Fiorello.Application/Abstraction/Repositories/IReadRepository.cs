﻿using Fiorello.Domain.Entities;
using System.Linq.Expressions;

namespace Fiorello.Application.Abstraction.Repositories;

public interface IReadRepository<T>: IRepositoryBase<T> where T: BaseEntity, new() 
{
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool isNotTracking = true, params string[] includes);
    IQueryable<T> GetAllFiltered(Expression<Func<T, bool>> expression, int skip, int take, bool isNotTracking = true, params string[] includes);
    IQueryable<T> GetAllFilteredOrderBy(Expression<Func<T, bool>> expression, Expression<Func<T, object>> expressionOrderBy, int skip, int take,bool OrderByDesc=true, bool isNotTracking = true, params string[] includes);
    Task<T?> FindAsync(Guid id);
    Task<T?> GetFiltered(Expression<Func<T, bool>> expression, bool isNotTracking = true);

}
