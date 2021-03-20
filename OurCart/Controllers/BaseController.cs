using Microsoft.AspNetCore.Mvc;
using OurCart.DataModel;
using OurCart.Infrastructure.Services;
using OURCart.Infrastructure.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurCart.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        BaseRepository<T> _db;
        protected OurCartDBContext dbContext;
        public BaseController(OurCartDBContext _dbContext)
        {
            dbContext = _dbContext;
            _db = new BaseRepository<T>(_dbContext);
        }

        [HttpGet]
        public OperationResponse<IEnumerable<T>> Get()
        {
            return _db.GetAll();
        }

        //update
        [HttpPut]
        public OperationResponse<T> Put([FromBody]T item)
        {
            return _db.Update(item);
        }

        // Insert / Add
        [HttpPost]
        public async Task<OperationResponse<T>> Post([FromBody]T item)
        {
            return await _db.Add(item);
        }

        // DELETE 
        [HttpDelete]
        public OperationResponse<bool> Delete([FromQuery]object id)
        {
            return _db.Delete(id);
        }

        protected IActionResult resultWithStatus(dynamic result)
        {
            if (!result.HasErrors)
                return Ok(result);
            return BadRequest(result);
        }
    }
}