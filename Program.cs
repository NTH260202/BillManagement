// See https://aka.ms/new-console-template for more information


using BillManagement;
using BillManagement.service;
using BillManagement.service.impl;
using BillManagement.common;

class Program
{
    public static void Main(String[] args)
    {
        IBillService billService = new BillServiceImpl();
        ICustomerService customerService = new CustomerServiceImpl();
        //InternationalCustomer internationalCustomer = new InternationalCustomer("Viet Nam", 1, "Thanh Ha", "Binh Dinh");
        //Bill bill = billService.CreateForInternationalCustomer(1, internationalCustomer, 1, 120, 120, 10000);

        //List<InternationalCustomer> result = customerService.GetAllInternationalCustomer();
        //result.ForEach(x => Console.WriteLine(x));
        //Console.WriteLine(bill);

        int choice = 0;
        

        do
        {
            Console.WriteLine("________________MENU_________________");
            Console.WriteLine("1. Get all bill");
            Console.WriteLine("2. Create a bill.");
            Console.WriteLine("3. Show total consumption volume for every type of customers.");
            Console.WriteLine("4. Show average total price of every international customers.");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("___________________________________");
                    Console.WriteLine("Thanks for using our application!");
                    break;
                case 1:
                    List<Bill> billsCase1 = billService.GetAll();
                    if (billsCase1.Count > 0)
                    {
                        foreach (Bill bill in billsCase1)
                        {
                            Console.WriteLine(bill);
                        }
                    } else
                    {
                        Console.WriteLine("No bills in the system");
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("Create bill for national customer or international customer - Enter 1 for national customer, 2 for international customer: ");
                    int customerChoice = Convert.ToInt32(Console.ReadLine());
                    if (customerChoice != 1 && customerChoice != 2)
                    {
                        Console.WriteLine("Invalid choice");
                        break;
                    }
                    Console.Write("Enter the customer ID: ");
                    int customerId = Convert.ToInt32(Console.ReadLine());
                    if (customerChoice == 1)
                    {
                        NationalCustomer? nationalCustomer = customerService.GetNationalCustomer(customerId);
                        if (nationalCustomer == null)
                        {
                            Console.WriteLine("No customer is existed!");
                            break;
                        }
                        Console.Write("Enter bill Id (Id is an integer): ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill month: ");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill consumption volume: ");
                        long consumptionVolume = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill consumptionStandard: ");
                        long consumptionStandard = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill unit price: ");
                        long unitPrice = Convert.ToInt32(Console.ReadLine());

                        billService.CreateForNationalCustomer(id, nationalCustomer, month, consumptionVolume, consumptionStandard, unitPrice);
                    }
                    if (customerChoice == 2)
                    {
                        InternationalCustomer? internationalCustomer = customerService.GetInternationalCustomer(customerId);
                        if (internationalCustomer == null)
                        {
                            Console.WriteLine("No customer is existed!");
                            break;
                        }
                        Console.Write("Enter bill Id (Id is an integer): ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill month: ");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill consumption volume: ");
                        long consumptionVolume = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill consumptionStandard: ");
                        long consumptionStandard = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter bill unit price: ");
                        long unitPrice = Convert.ToInt32(Console.ReadLine());

                        billService.CreateForInternationalCustomer(id, internationalCustomer, month, consumptionVolume, consumptionStandard, unitPrice);
                    }
                    break;
                case 3:
                    List<Bill> billsCase3 = billService.GetAll();
                    if (billsCase3.Count > 0)
                    {
                        foreach (Bill bill in billsCase3)
                        {
                            Console.WriteLine(bill);
                        }
                        Console.WriteLine($"Total consumption volume in international customers' bills is: {billService.GetTotalPriceForInternationalCustomer()}");
                        Console.WriteLine($"Total consumption volume in national customers' bills is: {billService.GetTotalPriceForNationalCustomer()}");
                    }
                    else
                    {
                        Console.WriteLine("No bills in the system");
                    }
                    break;
                case 4:
                    List<Bill> billsCase4 = billService.GetByCustomerType(Constant.INTERNATIONAL_CUSTOMER);
                    if (billsCase4.Count > 0)
                    {
                        foreach (Bill bill in billsCase4)
                        {
                            Console.WriteLine(bill);
                        }
                        Console.WriteLine($"Average total price in international customers' bills is: {billService.GetAverageTotalPriceInternationalCustomer()}");
                    }
                    else
                    {
                        Console.WriteLine("No bills in the system");
                    }
                    break;
            }

        } while (choice != 0);
    }
}