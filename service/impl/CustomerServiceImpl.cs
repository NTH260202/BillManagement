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
            new InternationalCustomer("Viet Nam", 1, "Thanh Ha", "Binh Dinh")
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
    }
}
