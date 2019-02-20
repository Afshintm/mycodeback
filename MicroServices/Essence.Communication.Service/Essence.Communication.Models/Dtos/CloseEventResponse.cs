using System.Collections.Generic;

namespace Essence.Communication.Models.Dtos
{
    public class CloseEventsResponse : ResponseBase
    {
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
        public string Message { get; set; }
    }

    public class CategoryParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


}
