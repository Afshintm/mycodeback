using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class SuccessResponse : ResponseBase
    {
        public SuccessResponse()
        {
            Response = (int)ResponseCode.OK;
            ResponseDescription = ResponseCode.OK.ToString();
            Value = true;
        }
    }
}
