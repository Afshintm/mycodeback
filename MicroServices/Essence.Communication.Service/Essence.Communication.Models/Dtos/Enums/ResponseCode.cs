using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos.Enums
{
    public enum ResponseCode
    {
        Unknown = 1,
        PanelNotExist = 105,
        InvalidToken = 123,
        WrongPassword = 2,
        AccessDenied = 30,
        Ok = 0
    }
}
