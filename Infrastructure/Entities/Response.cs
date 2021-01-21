using Infrastructure.Enums;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public T Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public List<string> Errors { get; set; }
    }
}