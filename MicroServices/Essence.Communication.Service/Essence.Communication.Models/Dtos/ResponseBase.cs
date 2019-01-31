using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public abstract class ResponseBase
    {
        public bool Value { get; set; }
        public int Response { get; set; }
        public string ResponseDescription { get; set; }
        public string Message { get; set; }
    }
}
