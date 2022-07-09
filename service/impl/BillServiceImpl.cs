using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BillManagement.common;

namespace BillManagement.service.impl
{
    public class BillServiceImpl : IBillService
    {
        List<Bill> _billList = new List<Bill>();
        //{
        //    new Bill(1, 1, 1, 120, 10000, 120)
        //};
        public Bill CreateForInternationalCustomer(int id, InternationalCustomer internationalCustomer, int month, long consumptionVolume, long comsumptionStandard, long unitPrice)
        {
            Bill bill = new Bill();
            bill.Month = month;
            bill.CustomerId = internationalCustomer.Id;
            bill.UnitPrice = unitPrice;
            bill.Id = id;
            bill.ConsumptionVolume = consumptionVolume;
            bill.ConsumptionStandard = comsumptionStandard;
            bill.CustomerType = "International";

            double totalPrice;
            totalPrice = consumptionVolume * unitPrice;
            bill.TotalPrice = totalPrice;
            _billList.Add(bill);
            return bill;
        }

        public Bill GetBillsByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public Bill CreateForNationalCustomer(int id, NationalCustomer nationalCustomer, int month, long consumptionVolume, long comsumptionStandard, long unitPrice)
        {
            Bill bill = new Bill();
            bill.Month = month;
            bill.CustomerId = nationalCustomer.Id;
            bill.UnitPrice = unitPrice;
            bill.Id = id;
            bill.ConsumptionVolume = consumptionVolume;
            bill.ConsumptionStandard = comsumptionStandard;
            bill.CustomerType = "National";

            double totalPrice;
            if (consumptionVolume <= comsumptionStandard)
            {
                totalPrice = consumptionVolume * unitPrice;
            } else
            {
                totalPrice = consumptionVolume * unitPrice * comsumptionStandard + (consumptionVolume - comsumptionStandard) * unitPrice * 2.5;
            }
            bill.TotalPrice = totalPrice;
            _billList.Add(bill);
            return bill;
        }

        public Bill? GetById(int id)
        {
            foreach(Bill bill in _billList)
            {
                if(bill.Id == id)
                {
                    return bill;
                }
            }

            return null;
        }

        public List<Bill> GetAll()
        {
            return _billList;
        }

        public double GetTotalPriceForNationalCustomer()
        {
            double totalPrice = 0;
            foreach(Bill bill in _billList)
            {
                if (Constant.NATIONAL_CUSTOMER.Equals(bill.CustomerType))
                {
                    totalPrice = totalPrice + bill.TotalPrice;
                }
            }
            return totalPrice;
        }

        public double GetTotalPriceForInternationalCustomer()
        {
            double totalPrice = 0;
            foreach (Bill bill in _billList)
            {
                if (Constant.INTERNATIONAL_CUSTOMER.Equals(bill.CustomerType))
                {
                    totalPrice = totalPrice + bill.TotalPrice;
                }
            }
            return totalPrice;
        }

        public double GetAverageTotalPriceInternationalCustomer()
        {
            double totalPrice = 0;
            int numberOfBills = 0;
            foreach (Bill bill in _billList)
            {
                if (Constant.INTERNATIONAL_CUSTOMER.Equals(bill.CustomerType))
                {
                    totalPrice = totalPrice + bill.TotalPrice;
                    numberOfBills++;
                }
            }
            return totalPrice/numberOfBills;
        }

        public List<Bill> GetByCustomerType(string customerType)
        {
            List<Bill> bills = new List<Bill>();
            foreach (Bill bill in _billList)
            {
                if (customerType.Equals(bill.CustomerType))
                {
                    bills.Add(bill);
                }
            }
            return bills;
        }
    }
}
