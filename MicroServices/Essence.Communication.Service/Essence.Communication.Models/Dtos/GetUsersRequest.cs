using System;
using System.Collections.Generic;
using System.Text;

namespace Essence.Communication.Models.Dtos
{

    public class GetUsersRequest
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string identificationNumber { get; set; }
        public string phoneNumber { get; set; }
        public string mobileNumber { get; set; }
        public string accountNumber { get; set; }
        public string serviceProviderAccountNumber { get; set; }
        public int serviceType { get; set; }
        public string[] servicePackagesFilter { get; set; }
        public string[] userTypesFilter { get; set; }
        public Order[] order { get; set; }
        public Itemsfilter itemsFilter { get; set; }
    }

    public class Itemsfilter
    {
        public string take { get; set; }
        public string skip { get; set; }
    }

    public class Order
    {
        public string orderBy { get; set; }
        public string direction { get; set; }
    }

}
