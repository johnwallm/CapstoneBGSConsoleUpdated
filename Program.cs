using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapstoneBGSConsole
{

    using OfficeOpenXml;
    using OfficeOpenXml.Drawing;
    using OfficeOpenXml.Style;
    using System.Configuration;
    using System.Drawing;
    using System.Dynamic;
    using System.IO;
    using System.Web;

    class Program
    {
        static void Main(string[] args)
        {
            DefaultData CallHelper = new DefaultData();
            Console.WriteLine("Group BGS Capstone II");


            /*EPPLUS*/

            DataProvider cmd = new DataProvider();

            //Registration/////////////
            //Console.WriteLine("Register");  ////////////////////////REGISTER
            ////string uname, pw, email, fname, mname, lname; //////////REGISTER
            ////int userid; ///////////REGISTER

            //Console.Write("1 for admin and 2 for user:");/// REGISTER
            //userid = Convert.ToInt32(Console.ReadLine());////REGISTER
            //Console.Write("Enter your Given name:");
            //fname = Console.ReadLine();

            //Console.Write("Enter your Maiden name:");
            //mname = Console.ReadLine();
            //Console.Write("Enter your Family name:");
            //lname = Console.ReadLine();
            //Console.Write("Enter Username:");
            //uname = Console.ReadLine();
            //Console.Write("Enter Password:");
            //pw = Console.ReadLine();
            //Console.Write("Enter your Email:");
            //email = Console.ReadLine();
            //Console.WriteLine("Register Success!");
            //cmd.InsertUserInformation (userid, uname, pw, email, fname, mname, lname); ////////REGISTER


            //foreach (var users in cmd.GetUserInformation()) //for user information
            //{
            //Console.WriteLine(users.UserTypeID + "\t" + users.UserName + "\t" + users.Password + "\t" + users.GivenName + "\t" + users.MaidenName + "\t" + users.FamilyName + "\t" + users.Email);
            //}

            //UPDATING////////////////
            //Console.WriteLine("Update Account"); ////////////////update
            ///*string fname, mname, lname, pw; *////////////update
            //int userinfoid;////////update &&&& delete
            //Console.Write("Enter User ID:"); //////////////////////UPDATE &&&& DELETE
            //userinfoid = Convert.ToInt32(Console.ReadLine());//UPDATE &&&&& DELETE
            //Console.Write("Enter your Given name:");
            //fname = Console.ReadLine();
            //Console.Write("Enter your Maiden name:");
            //mname = Console.ReadLine();
            //Console.Write("Enter your Family name:");
            //lname = Console.ReadLine();
            //Console.Write("Enter Username:");
            //uname = Console.ReadLine();
            //Console.Write("Enter Password:");
            //pw = Console.ReadLine();
            //Console.WriteLine("Updated Account!");
            //cmd.UpdateUserInformation(userinfoid, pw, fname, mname, lname); ///UPDATE
            //foreach (var users in cmd.GetUserInformation()) ////////////FOR UPDATING
            //{
            //    Console.WriteLine(users.UserInformationID + "\t" + users.GivenName + "\t" + users.MaidenName + "\t" + users.FamilyName + "\t" + users.Password);
            //}

            //DELETING ACCOUNT/////
            //Console.WriteLine("Deleting Account");
            
            //int userinfoid;////////update &&&& delete
            //Console.Write("Enter User ID:"); //////////////////////UPDATE &&&& DELETE
            //userinfoid = Convert.ToInt32(Console.ReadLine());//UPDATE &&&&& DELETE
            //cmd.DeleteUserInformation(userinfoid);
            //foreach (var users in cmd.GetUserInformation()) 
            //{
            //    Console.WriteLine(users.UserInformationID);
            //}


            Console.WriteLine("Login");

            string uname, pw;
           
            Console.Write("Enter your Username:");
            uname = Console.ReadLine();
            Console.Write("Enter your password:");
            pw = Console.ReadLine();

            cmd.LoginUserInformation(uname, pw);

            foreach (var users in cmd.GetUserInformation())
            {
                Console.WriteLine(users.UserName + "\t" + users.Password);
            }











            // cmd.InsertUserType(3,"Hello World");
            //cmd.UpdateUserType(3,"woof woof arf arf bark bark");
            //cmd.DeleteUserType(3);

            //foreach (var users in cmd.GetUserType())
            //{
            //    Console.WriteLine(users.Description + "\t" + users.UserTypeID + "\t" + users.Notes);
            //}





            Directory.CreateDirectory(CallHelper.path);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "VDWWD";
                excelPackage.Workbook.Properties.Title = "Title of Document";
                excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                //Add some text to cell A1


                
                int rows = 2;
                foreach (var use in cmd.GetUserInformation().ToList())
                {
                   
                    ws.Cells[rows, 2].Value = use.UserTypeID;
                    ws.Cells[rows, 1].Value = use.UserName;
                    ws.Cells[rows, 3].Value = use.Password;
                    ws.Cells[rows, 4].Value = use.GivenName;
                    ws.Cells[rows, 5].Value = use.MaidenName;
                    ws.Cells[rows, 6].Value = use.FamilyName;
                    ws.Cells[rows, 7].Value = use.Email;
                    rows++;
                }


                for (int i = 1; i <= 10; i++)
                {
                    ws.Column(i).Width = 10;
                }

                //string a = "A1:J1";
                //ws.Cells["" + a + ""].Merge = true;
                //ws.Cells["" + a + ""].Value = "Hello World";

                //Save your file
                FileInfo fi = new FileInfo(CallHelper.path + "/a.xlsx");
                excelPackage.SaveAs(fi);
            }
            Console.ReadLine();
        }
    }
}
