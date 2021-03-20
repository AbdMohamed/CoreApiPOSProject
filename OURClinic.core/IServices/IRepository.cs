using OurCart.DataModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OURClinic.Core.IServices
{
    public interface IRepository<T>
    {
        Task<OperationResponse<T>> Add(T oEntity);

        OperationResponse<T> Update(T oEntity);

        OperationResponse<bool> Delete(object ID);

        OperationResponse<IEnumerable<T>> GetAll();

        OperationResponse<IEnumerable<T>> Search(Expression<Func<T, bool>> Filter);
    }
}
