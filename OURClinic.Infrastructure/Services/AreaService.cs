using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Infrastructure.Services
{
    public class AreaService : IAreaService
    {
        OurCartDBContext _dbContext;

        public AreaService(OurCartDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResponse<IEnumerable<Area>>> getAllAreas()
        {
            OperationResponse<IEnumerable<Area>> result = new OperationResponse<IEnumerable<Area>>();
            try
            {
                var areas = await _dbContext.Area.ToListAsync();
                result.Data = areas;
            }
            catch (Exception ex)
            {
                result.HasErrors = true;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
