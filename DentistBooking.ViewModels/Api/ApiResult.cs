using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.Api
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }
        public ApiResult(string Message)
        {
            this.Message = Message;
        }
        public ApiResult(T ResultObj)
        {
            ResultObj = ResultObj;
        }
        public ApiResult(string Message,bool isSuccessed)
        {
            IsSuccessed = isSuccessed;
            Message = Message;
        }
    }
}
