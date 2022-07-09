using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement
{
	public class InternationalCustomer : Customer
	{
		public String Nationality { get; set; }

        public InternationalCustomer(string nationality, int id, string name, string address) :base(id, name, address)
        {
			Nationality = nationality;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Address: {Address}, Nationality: {Nationality}";
        }
    }
}
