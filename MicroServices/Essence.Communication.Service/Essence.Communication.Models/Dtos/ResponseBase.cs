using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public abstract class ResponseBase
    {
        public ResponseBase()
        {

        }

        public ResponseBase(ResponseBase response)
        {
            this.Value = response.Value;
            this.Response = response.Response;
            this.ResponseDescription = response.ResponseDescription;
            this.Message = response.Message;
        }
        public bool Value { get; set; }
        public int Response { get; set; }
        public string ResponseDescription { get; set; }
        public string Message { get; set; }
    }
}
