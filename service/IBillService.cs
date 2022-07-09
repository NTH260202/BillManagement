using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement.service
{
    public interface IBillService    
    {
        double GetTotalPriceForNationalCustomer();
        double GetTotalPriceForInternationalCustomer();

        double GetAverageTotalPriceInternationalCustomer();
        List<Bill> GetAll();
        List<Bill> GetByCustomerType(string customerType);
        Bill? GetById(int id);

        Bill GetBillsByCustomerId(int id);

        Bill CreateForNationalCustomer(int id, NationalCustomer nationalCustomer, int month, long consumptionVolume, long comsumptionStandard, long unitPrice);
        Bill CreateForInternationalCustomer(int id, InternationalCustomer internationalCustomer, int month, long consumptionVolume, long comsumptionStandard, long unitPrice);
    }
}
