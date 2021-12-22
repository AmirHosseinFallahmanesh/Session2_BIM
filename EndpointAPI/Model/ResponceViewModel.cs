using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointAPI.Model
{
    public class ResponceViewModel<T>
    {
        public ResponceViewModel()
        {
            Time = DateTime.Now;
            IsSuccess = true;
            Errors = new List<string>();
        }
        public T Data { get; set; }

        public DateTime Time { get;private set; }

        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }





    }
}
