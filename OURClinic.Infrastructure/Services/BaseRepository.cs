using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OURCart.Infrastructure.Util;
using OURClinic.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OurCart.Infrastructure.Services
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly OurCartDBContext _dbContext;
        public BaseRepository(OurCartDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationResponse<T>> Add(T oEntity)
        {
            OperationResponse<T> Op = new OperationResponse<T>();
            try
            {
                if (oEntity == null)
                {
                    throw new ArgumentNullException("oEntity");
                }

                await _dbContext.Set<T>().AddAsync(oEntity);
                int rowsEffected = _dbContext.SaveChanges();
                Op.Data = rowsEffected > 0 ? oEntity : default(T);
                Op.HasErrors = rowsEffected <= 0;
                Op.Message = rowsEffected > 0 ? null : "error InInsert in DB";
            }
            catch (Exception ex)
            {
                Op.HasErrors = true;
                Op.Message = string.Format("{0} InnerException {1}", ex.Message, ex.InnerException.Message);
            }
            return Op;
        }

        public OperationResponse<bool> Delete(object ID)
        {
            OperationResponse<bool> Op = new OperationResponse<bool>();

            try
            {

                DbSet<T> dbSet = _dbContext.Set<T>();
                T entity = dbSet.Find(ID);
                dbSet.Attach(entity);
                if (entity == null)
                {
                    throw new ArgumentNullException("oEntity");
                }
                dbSet.Remove(entity);
                int rowsEffected = _dbContext.SaveChanges();
                Op.Data = rowsEffected > 0 ? true : false;
                Op.HasErrors = rowsEffected > 0;
                Op.Message = rowsEffected > 0 ? null : "error InInsert in DB";
            }
            catch (Exception ex)
            {
                Op.Message = ex.Message;
            }
            return Op;

        }

        public OperationResponse<IEnumerable<T>> GetAll()
        {
            OperationResponse<IEnumerable<T>> Op = new OperationResponse<IEnumerable<T>>();
            try
            {
                IQueryable<T> qry = _dbContext.Set<T>();
                Op.Data = qry.AsEnumerable();
            }
            catch (Exception ex)
            {
                Op.Message = ex.Message;
            }
            return Op;
        }

        public OperationResponse<IEnumerable<T>> Search(Expression<Func<T, bool>> Filter = null)
        {
            OperationResponse<IEnumerable<T>> Op = new OperationResponse<IEnumerable<T>>();
            try
            {
                IQueryable<T> qry = _dbContext.Set<T>();
                if (Filter != null)
                {
                    qry = qry.Where(Filter);
                    Op.Data = qry.AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                Op.Message = ex.Message;
            }
            return Op;
        }

        public OperationResponse<T> Update(T oEntity)
        {
            OperationResponse<T> Op = new OperationResponse<T>();

            try
            {
                if (oEntity == null)
                {
                    throw new ArgumentNullException("oEntity");
                }
                DbSet<T> dbSet = _dbContext.Set<T>();
                dbSet.Attach(oEntity);
                _dbContext.Entry(oEntity).State = EntityState.Modified;
                int returnValue = _dbContext.SaveChanges();
                Op.Data = returnValue > 0 ? oEntity : default(T);
            }
            catch (Exception ex)
            {
                Op.Message = ex.Message;
            }
            return Op;
        }
    }
}