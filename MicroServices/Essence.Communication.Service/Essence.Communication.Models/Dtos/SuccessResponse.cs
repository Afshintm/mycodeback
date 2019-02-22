﻿using Essence.Communication.Models.Dtos.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{
    public class SuccessResponse : ResponseBase
    {
        public SuccessResponse()
        {
            Response = (int)ResponseCode.Ok;
            ResponseDescription = ResponseCode.Ok.ToString();
            Value = true;
        }
    }
}
