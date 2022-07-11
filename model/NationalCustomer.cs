using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement
{
    public class NationalCustomer : Customer
    {
        public String Type { get; set; }

        public NationalCustomer(string type, int id, string name, string address) : base(id, name, address)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Type: {Type}";
        }

    }
}
