// See https://aka.ms/new-console-template for more information


using BillManagement;
using BillManagement.service;
using BillManagement.service.impl;
using BillManagement.common;

delegate int InputDelegateInt();
delegate String InputDelegateString();

class Program
{

    public static void Main(String[] args)
    {
        Program program = new Program();
        InputDelegateInt inputDelegateInt = program.inputInt;
        InputDelegateString inputDelegateString = program.inputString;
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
            Console.WriteLine("5. Create a customer");
            Console.WriteLine("6. Get all customer");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            choice = inputDelegateInt();
            //choice = Convert.ToInt32(Console.ReadLine());
            
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
                    
                    Bill? checkBill;
                    int billId;
                    do
                    {
                        Console.Write("Enter bill Id (Id is an integer): ");
                        billId = inputDelegateInt();
                        checkBill = billService.GetById(billId);
                        if (checkBill != null)
                        {
                            Console.WriteLine("Id is existed!");
                        }
                    } while (checkBill != null);
                    Console.WriteLine("Create bill for national customer or international customer - Enter 1 for national customer, 2 for international customer: ");
                    int customerChoice = inputDelegateInt();
                    if (customerChoice != 1 && customerChoice != 2)
                    {
                        Console.WriteLine("Invalid choice");
                        break;
                    }
                    Console.Write("Enter the customer ID: ");
                    int customerId = inputDelegateInt();
                    if (customerChoice == 1)
                    {
                        NationalCustomer? nationalCustomer = customerService.GetNationalCustomer(customerId);
                        if (nationalCustomer == null)
                        {
                            Console.WriteLine("No customer is existed!");
                            break;
                        }
                        Console.Write("Enter bill month: ");
                        int month = inputDelegateInt();
                        Console.Write("Enter bill consumption volume: ");
                        long consumptionVolume = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter bill consumptionStandard: ");
                        long consumptionStandard = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter bill unit price: ");
                        long unitPrice = Convert.ToInt64(Console.ReadLine());

                        billService.CreateForNationalCustomer(billId, nationalCustomer, month, consumptionVolume, consumptionStandard, unitPrice);
                    }
                    if (customerChoice == 2)
                    {
                        InternationalCustomer? internationalCustomer = customerService.GetInternationalCustomer(customerId);
                        if (internationalCustomer == null)
                        {
                            Console.WriteLine("No customer is existed!");
                            break;
                        }
                        
                        Console.Write("Enter bill month: ");
                        int month = inputDelegateInt();
                        Console.Write("Enter bill consumption volume: ");
                        long consumptionVolume = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter bill consumptionStandard: ");
                        long consumptionStandard = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter bill unit price: ");
                        long unitPrice = Convert.ToInt64(Console.ReadLine());

                        billService.CreateForInternationalCustomer(billId, internationalCustomer, month, consumptionVolume, consumptionStandard, unitPrice);
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
                case 5:
                    
                    Customer? checkCustomer;
                    int id = 0;
                    do
                    {
                        Console.Write("Enter customer Id (Id is an integer): ");
                        id = inputDelegateInt();
                        checkCustomer = customerService.GetById(id);
                        if (checkCustomer != null)
                        {
                            Console.WriteLine("Id is existed!");
                        }
                    } while (checkCustomer != null);
                    Console.WriteLine("You want to add which type of customers:");
                    Console.WriteLine("1. International customers");
                    Console.WriteLine("1. National customers");
                    Console.Write("Your choice: ");
                    int choiceCase5 = inputDelegateInt();
                    if (choiceCase5 == 1)
                    {
                        Console.Write("Enter customer name: ");
                        string name = inputDelegateString();
                        Console.Write("Enter customer address: ");
                        string address = inputDelegateString();
                        Console.Write("Enter customer nationality: ");
                        string nationality = inputDelegateString();
                        customerService.CreateInternationalCustomer(id, name, address, nationality);
                    } 
                    else
                    {
                        Console.Write("Enter customer name: ");
                        string name = inputDelegateString();
                        Console.Write("Enter customer address: ");
                        string address = inputDelegateString();
                        Console.WriteLine("Enter kind of national customer: ");
                        Console.WriteLine("1. Common");
                        Console.WriteLine("2. Manufacture");
                        Console.WriteLine("3. Business");
                        Console.Write("Your choice: ");
                        int typeChoice = inputDelegateInt();
                        string business = "";
                        do
                        {
                            switch (typeChoice)
                            {
                                case 1:
                                    business = Constant.COMMON_CUSTOMER;
                                    break;
                                case 2:
                                    business = Constant.MANUFACTURE_CUSTOMER;
                                    break;
                                case 3:
                                    business = Constant.BUSINESS_CUSTOMER;
                                    break;
                                default:
                                    Console.WriteLine("Value is invalid!");
                                    break;
                            }
                        } while (typeChoice > 3 || typeChoice < 1);
                        
                        customerService.CreateNationalCustomer(id, name, address, business);
                    }
                    break;
                case 6:
                    List<Customer> customers = customerService.GetAll();
                    if (customers.Count > 0)
                    {
                        foreach (Customer customer in customers)
                        {
                            Console.WriteLine(customer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No customers in the system");
                    }

                    break;
            }

        } while (choice != 0);
    }
    private int inputInt()
    {
        int validValue = 0;
        do
        {
            try
            {
                validValue = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                validValue = -1;
                Console.WriteLine("Invalid input! Please enter again!");
            }
        } while(validValue == -1);
        return validValue;
    }

    private string inputString()
    {
        string? validValue = "";
        do
        {
            validValue = Console.ReadLine();
            if (validValue == null)
            {
                validValue = "";
                Console.WriteLine("This field is required!");
            }
            
        } while (validValue == "");
        return validValue;
    }
}