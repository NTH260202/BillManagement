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
        InternationalCustomer? GetInternationalCustomer(int id);
        NationalCustomer? GetNationalCustomer(int id);
    }
}
