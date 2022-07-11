using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.service
{
    interface ICustomerService
    {
        List<InternationalCustomer> GetAllInternationalCustomer();
        List<Customer> GetAll();
        Customer? GetById(int id);
        InternationalCustomer? GetInternationalCustomer(int id);
        NationalCustomer? GetNationalCustomer(int id);
        void CreateInternationalCustomer(int id, string name, string address, string nationality);
        void CreateNationalCustomer(int id, string name, string address, string business);
    }
}
