using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fbs_webApi_v2.Data
{
    public class serviceResponce<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}
