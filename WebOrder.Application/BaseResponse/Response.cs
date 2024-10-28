using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrder.Application.Contacts;

using WebOrder.Domain.Enum;

namespace WebOrder.Application.BaseResponse
{
    public class Response<T>
    {
        public string? Errors { get; set; }
        public StatusCode StatusCode { get; set; }
        public T? Data { get; set; }

    }
}
