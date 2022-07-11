using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.service.impl
{
    internal class CustomerServiceImpl : ICustomerService
    {
        List<InternationalCustomer> _internationalCustomers = new List<InternationalCustomer>
        {
            new InternationalCustomer("Viet Nam", 4, "Thanh Ha", "Binh Dinh")
        };
        List<NationalCustomer> _nationalCustomers = new List<NationalCustomer>
        {
            new NationalCustomer("Common", 1, "Tran Linh", "Quang Binh"),
            new NationalCustomer("Business", 2, "Trong Nhan", "Binh Dinh"),
            new NationalCustomer("Manufacture", 3, "Tien Khai", "Long An")
        };
        public InternationalCustomer? GetInternationalCustomer(int id)
        {
            foreach (InternationalCustomer internationalCustomer in _internationalCustomers)
            {
                if (internationalCustomer.Id == id) { return internationalCustomer; }
            }
            return null;
        }

        public List<InternationalCustomer> GetAllInternationalCustomer()
        {
            return _internationalCustomers;
        }

        NationalCustomer? ICustomerService.GetNationalCustomer(int id)
        {
            foreach (NationalCustomer nationalCustomer in _nationalCustomers)
            {
                if (nationalCustomer.Id == id) { return nationalCustomer; }
            }
            return null;
        }

        public void CreateInternationalCustomer(int id, string name, string address, string nationality)
        {
            InternationalCustomer customer = new InternationalCustomer(nationality, id, name, address);
            _internationalCustomers.Add(customer);
        }

        public void CreateNationalCustomer(int id, string name, string address, string business)
        {
            NationalCustomer customer = new NationalCustomer(business, id, name, address);
            _nationalCustomers.Add(customer);
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            customers.AddRange(_nationalCustomers);
            customers.AddRange(_internationalCustomers);
            return customers;
        }

        public Customer? GetById(int id)
        {
            List<Customer> customers = GetAll();
            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
