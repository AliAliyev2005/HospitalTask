
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    static class Run
    {
        public static User EnterUser()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your surname : ");
            string surname = Console.ReadLine();
            Console.Write("Enter your email : ");
            string email = Console.ReadLine();
            Console.Write("Enter your phone : ");
            string phone = Console.ReadLine();

            return new User(name, surname, email, phone);
        }

        public static void SelectDepartment(ref Hospital hospital)
        {
            Console.Clear();
            string select;
            do
            {
                Console.WriteLine("1) Pediatriya");
                Console.WriteLine("2) Travmatologiya");
                Console.WriteLine("3) Stamotologiya");

                Console.Write("\nEnter your choice : ");
                select = Console.ReadLine();

                if(select.Equals("1"))
                    SelectDoctor(hospital.Pediatriya);
                else if (select.Equals("2"))
                    SelectDoctor(hospital.Travmatologiya);
                else if(select.Equals("3"))
                    SelectDoctor(hospital.Stamotologiya);

            } while (select != "1" && select != "2" && select != "3");
        }

        public static void SelectDoctor(Department department)
        {
            bool find = false;
            do
            {
                department.PrintDoctors();
                Console.Write("Select your doctor : ");
                string doctorID = Console.ReadLine();

            } while (true);

        }

        public static void RunProgram()
        {
            Hospital hospital = new Hospital();
            User user = new User();
            user = EnterUser();
            SelectDepartment(ref hospital);
        }
    }
}
