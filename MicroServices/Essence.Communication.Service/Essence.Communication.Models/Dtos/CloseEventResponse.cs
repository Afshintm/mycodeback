﻿using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    public class CloseEventsResponse
    {
        public ResponseCode Response { get; set; }
        public string ResponseDescription { get; set; }
        public bool Value { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }

    public class ValidationResult
    {
        public List<ValidationCategoryObj> CloseEventsFilterValidatorResult { get; set; }
    }

    public class ValidationCategoryObj
    {
        public string ValidationCategory { get; set; }
        public List<CategoryParameter> Parameters { get; set; }
    }

    public class CategoryParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public enum ResponseCode
    {
        OK = 0,
        Unknown = 1,
        PanelNotExist = 105,
        InvalidToken = 123
    }

}
