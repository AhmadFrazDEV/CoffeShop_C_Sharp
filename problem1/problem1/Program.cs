using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Biling_system_version_2_using_lists.BL;

namespace Biling_system_version_2_using_lists
{
    class Program
    {
        static string path1 = "F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\sign_UP_file.txt";
        static string path2 = "F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\admin_login_data.txt";
        static string path3 = "F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\Product_File.txt";

        static void Main(string[] args)
        {
            string menu;
            while (true)
            {
                Console.Clear();
                menu = menufunction();
                if (menu == "1")
                {
                    //sign in
                    Console.Clear();
                    Console.WriteLine("------------------< Welcome to Sign In Menu >------------------");
                    Console.WriteLine();
                    Credencials data = new Credencials();
                    Console.Write("Enter Your Name:");
                    data.name = Console.ReadLine();
                    Console.Write("Enter Your Password:");
                    data.password = Console.ReadLine();
                    int no_of_lines_count;
                    no_of_lines_count = no_of_lines_count_function();
                    if (no_of_lines_count == 0)
                    {
                        Console.WriteLine("signUP first");
                        clearScreen();
                    }
                    else
                    {
                        bool das_phir;
                        das_phir = StoreFromFile(data, no_of_lines_count);
                        if (das_phir == true)
                        {
                            clearScreen();
                            string mainMenu;
                            while (true)
                            {
                                mainMenu = mainMenufunction();
                                if (mainMenu == "1")
                                  {
                                    //administrator
                                    bool isadmin = true;
                                    while (isadmin)
                                    {
                                        Console.Clear();
                                        admin_data_credentials adminC = new admin_data_credentials();
                                        Console.Write("Enter Email:");
                                        adminC.email = Console.ReadLine();
                                        Console.Write("Enter Password:");
                                        adminC.password = Console.ReadLine();
                                        bool admin;
                                        admin = verifyAdminData(adminC);
                                        if (admin == true)
                                        {
                                            isadmin = true;
                                            Console.WriteLine("Wrong Password or email");
                                            clearScreen();
                                        }
                                        else
                                        {

                                            isadmin = false;
                                        }
                                    }
                                    string administrator;

                                    while (true)
                                    {
                                        administrator = administratorMenuFunction();
                                        if(administrator == "1")
                                        {
                                            //add a menu item
                                            Console.WriteLine("Enter Name:");
                                            string name = Console.ReadLine();
                                            Console.WriteLine("Enter type (food/drink):");
                                            string type = Console.ReadLine();
                                            Console.WriteLine("Enter Price:");
                                            float price = float.Parse(Console.ReadLine());
                                            MenuItem items = new MenuItem(name, type, price);
                                            addMenuItemsInFile(items);
                                            clearScreen();
                                        }//end of add a menu item
                                        else if(administrator == "2")
                                        {
                                            //view the cheapest item in the menu
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem> miL = loadData(lines_count, path3);
                                            List <MenuItem>sorted_miL = miL.OrderBy(x => x.price).ToList();
                                            displayData(sorted_miL, lines_count);
                                            clearScreen();
                                        }//end of view the cheapest item in the menu
                                        else if (administrator == "3")
                                        {
                                            //view the drink's menu
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem> miL = loadData(lines_count, path3);
                                            List<MenuItem> miFL = new List<MenuItem>();
                                            for (int i = 0; i < miL.Count; i++)
                                            {
                                                MenuItem temp = new MenuItem();
                                                temp = miL[i];
                                                if (temp.type == "Drink")
                                                {
                                                    miFL.Add(temp);
                                                }
                                            }
                                            displayData(miFL, miFL.Count);
                                            clearScreen();
                                        }//end of view the drink's menu
                                        else if (administrator == "4")
                                        {
                                            //view the food's menu
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem> miL = loadData(lines_count, path3);
                                            List<MenuItem> miFL = new List<MenuItem>();
                                            for (int i = 0; i < miL.Count; i++)
                                            {
                                                MenuItem temp = new MenuItem();
                                                temp = miL[i];
                                                if (temp.type == "Food")
                                                {
                                                    miFL.Add(temp);
                                                }
                                            }
                                            displayData(miFL, miFL.Count);
                                            clearScreen();
                                        }//end of view the food's menu
                                        else if (administrator == "5")
                                        {
                                            //view all products
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem>miL = loadData(lines_count,path3);
                                            displayData(miL, lines_count);
                                            clearScreen();
                                        }//end of view all products
                                        else if (administrator == "6")
                                        {
                                            //sorted list of products
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem> miL = loadData(lines_count, path3);
                                            List<MenuItem> sorted_miL = miL.OrderBy(x => x.price).ToList();
                                            displayData(sorted_miL, lines_count);
                                            clearScreen();
                                        }//end of sorted list of products
                                        else if (administrator == "7")
                                        {
                                            //exit
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong option");
                                            clearScreen();
                                        }
                                    }
                                }//end of administrator
                                else if (mainMenu == "2")
                                {
                                    //buyer
                                    Console.Clear();
                                    string buyer;
                                    while (true)
                                    {
                                        buyer = buyerMenu();
                                        if (buyer == "1")
                                        {
                                            //buy product
                                            /*int count;
                                            count = no_of_lines_count_of_product_file();
                                            displaySorttedData2(count, path3);*/
                                            int lines_count = no_of_lines_count_of_product_file();
                                            List<MenuItem> miL = loadData(lines_count, path3);
                                            List<MenuItem> sorted_miL = miL.OrderBy(x => x.price).ToList();
                                            buyerData(sorted_miL, lines_count);

                                            clearScreen();
                                        }// end of buy product
                                        else if (buyer == "2")
                                        {
                                            //exxit
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong entry");
                                            clearScreen();
                                        }
                                    }//end of buyer menu
                                    clearScreen();
                                }//end of buyer
                                else if (mainMenu == "3")
                                {
                                    //exit
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Entry");
                                    clearScreen();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid user");
                            clearScreen();
                        }
                    }
                }//end of sign in
                else if (menu == "2")
                {
                    //sign up
                    getdata();
                }//end of sign up
                else if (menu == "3")
                {
                    //exit
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Entry");
                    clearScreen();
                }
            }
            Console.Write("Press anykey to continue:");
            Console.ReadKey();
        }
        static string menufunction()
        {
            Console.WriteLine("1 Sign IN");
            Console.WriteLine("2 Sign UP");
            Console.WriteLine("3 Exit");
            Console.Write("Your Choice:");
            string op;
            op = Console.ReadLine();
            return op;
        }
        static void clearScreen()
        {
            Console.Write("Press anykey to continue:");
            Console.ReadKey();
            Console.Clear();
        }
        static void getdata()
        {
            bool flag = true;
            while (flag)
            {
                Credencials data = new Credencials();
                Console.Clear();
                Console.WriteLine("------------------< Welcome to Sign up Menu >------------------");
                Console.WriteLine();
                Console.Write("Enter Your Name:");
                data.name = Console.ReadLine();
                Console.Write("Enter Your Password:");
                data.password = Console.ReadLine();
                int count;
                count = no_of_lines_count_function();
                bool daso_Phir;
                daso_Phir = checkFromFile(count, data);
                if (daso_Phir == true)
                {
                    Console.WriteLine("Try different name or password");
                    clearScreen();
                }
                else
                {
                    storeInfile_of_signUP(data);
                    clearScreen();
                    flag = false;
                }
            }
        }
        static void storeInfile_of_signUP(Credencials data)
        {
            StreamWriter f1 = new StreamWriter(path1, true);
            f1.WriteLine(data.name);
            f1.WriteLine(data.password);
            f1.Flush();
            f1.Close();
        }
        static bool StoreFromFile(Credencials report, int count)
        {

            List<Credencials> sign_up_data_list = new List<Credencials>();
            StreamReader f2 = new StreamReader(path1);
            for (int i = 0; i < count; i++)
            {
                Credencials temp = new Credencials();
                temp.name = f2.ReadLine();
                temp.password = f2.ReadLine();
                sign_up_data_list.Add(temp);
            }
            f2.Close();
            for (int i = 0; i < sign_up_data_list.Count; i++)
            {
                Credencials temp = new Credencials();
                temp = sign_up_data_list[i];
                if (report.name == temp.name && report.password == temp.password)
                {
                    return true;
                }
            }
            return false;
        }
        static int no_of_lines_count_function()
        {
            StreamReader f1 = new StreamReader(path1);
            int count = 0;
            string line;
            while ((line = f1.ReadLine()) != null)
            {
                count++;
            }
            count = count / 2;
            f1.Close();
            return count;
        }
        static bool checkFromFile(int count, Credencials report)
        {
            List<Credencials> sign_up_data_list = new List<Credencials>();
            StreamReader f2 = new StreamReader(path1);
            for (int i = 0; i < count; i++)
            {
                Credencials temp = new Credencials();
                temp.name = f2.ReadLine();
                temp.password = f2.ReadLine();
                sign_up_data_list.Add(temp);
            }
            f2.Close();
            for (int i = 0; i < sign_up_data_list.Count; i++)
            {
                Credencials temp = new Credencials();
                temp = sign_up_data_list[i];
                if (report.name == temp.name && report.password == temp.password)
                {
                    return true;
                }
            }
            return false;
        }
        static string mainMenufunction()
        {
            Console.Clear();
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("|               Supermarket Main Menu >               |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("|1) Administrator                                     |");
            Console.WriteLine("|2) Buyer                                             |");
            Console.WriteLine("|3) Exit                                              |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.Write("Your Choice:");
            string op;
            op = Console.ReadLine();
            return op;
        }
        static bool verifyAdminData(admin_data_credentials adminC)
        {
            admin_data_credentials temp = new admin_data_credentials();
            StreamReader f1 = new StreamReader(path2);
            temp.email = f1.ReadLine();
            temp.password = f1.ReadLine();
            f1.Close();
            if (adminC.email == temp.email && adminC.password == temp.password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static string administratorMenuFunction()
        {
            Console.Clear();
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("|               Administrator Main Menu >             |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("|               1)  Add a Menu item                   |");
            Console.WriteLine("|               2) View the Cheapest Item in the menu |");
            Console.WriteLine("|               3) View the Drink’s Menu              |");
            Console.WriteLine("|               4) View the Food’s Menu               |");
            Console.WriteLine("|               5) View All Products                  |");
            Console.WriteLine("|               6) Sorted List Of Products            |");
            Console.WriteLine("|               7) Back to main menu                  |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.Write("Your Choice:");
            string op;
            op = Console.ReadLine();
            return op;
        }
        static int no_of_lines_count_of_product_file()
        {

            StreamReader f1 = new StreamReader(path3);
            string line;
            int count = 0;
            while ((line = f1.ReadLine()) != null)
            {
                count++;
            }
            f1.Close();
            return (count / 3);
        }
        static List<MenuItem> loadData(int count, string path3)
        {
            List<MenuItem> mIL = new List<MenuItem>();
            StreamReader f1 = new StreamReader(path3);
            for (int i = 0; i < count; i++)
            {
                MenuItem mI = new MenuItem();
                mI.name = f1.ReadLine();
                mI.type = f1.ReadLine();
                mI.price = float.Parse(f1.ReadLine());
                mIL.Add(mI);
            }
            f1.Close();
            return mIL;
        }
        static void displayData(List<MenuItem>mIL,int count)
        {
            Console.Clear();
            Console.WriteLine("|--------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                   Supermarket Products                                           |");
            Console.WriteLine("|--------------------------------------------------------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine("Product ID\t\tProduct Name\t\tProduct Price\t\tProduct Type");
            for (int i = 0; i < count; i++)
            {
                MenuItem temp = new MenuItem();
                temp = mIL[i];
                Console.WriteLine(i + "\t\t\t" + temp.name + "\t\t" + temp.price + "\t\t\t" + temp.type);
            }
        }
        static string buyerMenu()
        {
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("|               Buyer Main Menu >                     |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine("1) Buy Product ");
            Console.WriteLine("2) Go back ");
            Console.WriteLine("Your Choice:");
            string op;
            op = Console.ReadLine();
            return op;
        }
        static void buyerData(List<MenuItem>sorted_miL,int count)
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("|--------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|                                   Supermarket Products                                           |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------|");
                Console.WriteLine();
                Console.WriteLine("Product ID\t\tProduct Name\t\tProduct Price\t\tProduct Type");
                for (int i = 0; i < count; i++)
                {
                    /*productC temp = new productC();*/
                    MenuItem temp = new MenuItem();
                    temp = sorted_miL[i];
                    Console.WriteLine(i + "\t\t\t" + temp.name + "\t\t\t" + temp.price + "\t\t" + temp.type);
                }
                Console.WriteLine("Product ID:");
                string s_id;
                s_id = Console.ReadLine();
                int i_id;
                i_id = int.Parse(s_id);
                if (i_id < count)
                {
                    //get product detail
                    Console.WriteLine("Quantity:");
                    string s_quantity;
                    s_quantity = Console.ReadLine();
                    float f_quantity;
                    f_quantity = float.Parse(s_quantity);
                    StreamWriter f2 = new StreamWriter("F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\buyer_file.txt", true);
                    f2.WriteLine(s_quantity);
                    MenuItem temp = sorted_miL[i_id];
                    f2.WriteLine(temp.name);
                    f2.WriteLine(temp.type);
                    f2.WriteLine(temp.price);
                    f2.Flush();
                    f2.Close();
                    Console.WriteLine("Buy More Press \'y\' for Yess and \'n\' for no:");
                    string choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        flag = true;
                    }
                    else if (choice == "n")
                    {
                        StreamReader f3 = new StreamReader("F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\buyer_file.txt");
                        string line;
                        int countf = 0;
                        while ((line = f3.ReadLine()) != null)
                        {
                            countf++;
                        }
                        f3.Close();
                        countf = countf / 4;
                        calculatebill(countf);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("You Entered wrong product code");
                    clearScreen();
                }
            }
        }
        static void calculatebill(int countf)
        {
            List<MenuItem> miL = new List<MenuItem>();
            //List<productC> pL = new List<productC>();
            float[] quantityA = new float[countf];
            float[] billA = new float[countf];
            float total = 0;
            StreamReader f3 = new StreamReader("F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\buyer_file.txt");
            for (int i = 0; i < countf; i++)
            {
                MenuItem temp = new MenuItem();
                //productC temp = new productC();
                quantityA[i] = float.Parse(f3.ReadLine());
                temp.name = f3.ReadLine();
                temp.type = f3.ReadLine();
                temp.price = float.Parse(f3.ReadLine());
                miL.Add(temp);
            }
            f3.Close();
            for (int i = 0; i < countf; i++)
            {
                MenuItem temp = miL[i];
                billA[i] = (temp.price * quantityA[i]);
            }
            for (int i = 0; i < countf; i++)
            {
                total = total + billA[i];
            }

            Console.Clear();
            Console.WriteLine("|--------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                            RECIPT                                                            |");
            Console.WriteLine("|--------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine();
            Console.WriteLine("Product ID\t\tQuantity\t\tProduct Name\t\tProduct Price\t\tBill");
            for (int i = 0; i < countf; i++)
            {
                MenuItem temp = miL[i];
                Console.WriteLine(i + "\t\t\t" + quantityA[i] + "\t\t\t" + temp.name + "\t\t" + temp.price + "\t\t\t" + billA[i]);
            }
            Console.WriteLine("payable = " + total);
            //File.WriteAllText("F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\buyer_file.txt", string.Empty);
            StreamWriter flash = new StreamWriter("F:\\BS CS Second Semester\\OOP\\Week 5\\Week 5\\problem1\\problem1\\bin\\Debug\\buyer_file.txt");
            flash.Flush();
            flash.Close();
        }
        static void addMenuItemsInFile(MenuItem temp)
        {
            StreamWriter f1 = new StreamWriter(path3,true);
           f1.WriteLine(temp.name);
            f1.WriteLine(temp.type);
            f1.WriteLine(temp.price);
            f1.Flush();
            f1.Close();
        }
    }
}