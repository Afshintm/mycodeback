using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Extensions
{
    public static class VendorEventExtensions
    {
        public static string GetVendorEventCode( this VendorEvent vEvent, string code)
        {
            return $"{vEvent.Vender.ToString()}_{code}";
        }
    }

    public abstract class tt1
    {

    }
    public class ttt:tt1
    {

    }
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string WordCount(this tt1 str)
        {
            return str.ToString();
        }

       
        private static string aaa()
        {
            var ss = new ttt(); 
            ss.WordCount();
            return "sss";
        }
    }

   
    

}
