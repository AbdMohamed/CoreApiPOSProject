using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Infrastructure.Services
{
    public class OfferService : IOfferService
    {
        OurCartDBContext _dbContext;
        public OfferService(OurCartDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResponse<IEnumerable<CategoryItem>>> getOffers(int pageNum, int itemsPerPage)
        {
            OperationResponse<IEnumerable<CategoryItem>> or = new OperationResponse<IEnumerable<CategoryItem>>();
            try
            {
                //  parameters --> category id to filter with, all items count to skip , all items that will return
                var allOffersProducts = await _dbContext.CategorItem.FromSql($"GetOffersProducts {(pageNum * itemsPerPage)}, {itemsPerPage}").ToListAsync();

                if (allOffersProducts != null)
                    or.Data = allOffersProducts;
                // old data
                //var result = await _dbContext.Items.Where(i => i.FkCategoryId == catID).ToListAsync();
                //if (result != null)
                //    or.Data = result;
            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
            }
            return or;
        }
    }
}
