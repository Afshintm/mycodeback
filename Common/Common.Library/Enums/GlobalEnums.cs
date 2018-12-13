using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Library.Enums
{
    public static class GlobalEnums
    {
        public enum Operations { Create = 1, Update, Delete };

        public enum UserType {
            [StringValue("Administrator")]
            Administrator = 1,
            [StringValue("CareGiver")]
            CareGiver,
            [StringValue("Resident")]
            Resident
        };

        public enum LanguageIds { English =1 };

        public enum Gender
        {
            [StringValue("Male")]
            Male =1,
            [StringValue("Female")]
            Female
        }

        public enum ServiceType {  Pro = 1, Family}

        public enum PhoneNumberType
        {
            [StringValue("Default")]
            Default = 1,
            [StringValue("Custom")]
            Custom
        }
    }

    public class StringValue : System.Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }

    public static class StringEnum
    {
        public static string StringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            //Check first in our cached results...

            //Look for our 'StringValueAttribute' 

            //in the field's custom attributes

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
