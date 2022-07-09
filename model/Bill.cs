using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagement
{
    public class Bill
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public int Month { get; set; }
        public long ConsumptionVolume { get; set; }
        public long UnitPrice { get; set; }
        public long ConsumptionStandard { get; set; }
        public double TotalPrice { get; set; }

        public Bill(int id, int customerId, int month, long consumptionVolume, long unitPrice, long consumptionStandard)
        {
            Id = id;
            CustomerId = customerId;
            Month = month;
            ConsumptionVolume = consumptionVolume;
            UnitPrice = unitPrice;
            ConsumptionStandard = consumptionStandard;
        }

        public Bill()
        {
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Customer ID: {CustomerId}, Month: {Month}, Total Price: {TotalPrice}, Consumption Volumne: {ConsumptionVolume}";
        }
    }
}
