using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO
{
    public class APIResponse<T> where T : class
    {
        public bool HasErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Data { get; set; }

    }
}
