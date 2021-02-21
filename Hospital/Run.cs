
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hospital
{
    static class Run
    {
        public static User EnterUser()
        {
            Console.Clear();
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

        public static void SelectDepartment(ref Hospital hospital, ref User user)
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

                if (select.Equals("1"))
                    SelectDoctor(hospital.Pediatriya, ref hospital, user);
                else if (select.Equals("2"))
                    SelectDoctor(hospital.Travmatologiya, ref hospital, user);
                else if (select.Equals("3"))
                    SelectDoctor(hospital.Stamotologiya, ref hospital, user);

            } while (select != "1" && select != "2" && select != "3");
        }

        public static void SelectDoctor(Department department, ref Hospital hospital, User user)
        {
            bool find = false;
            do
            {
                Console.Clear();
                department.PrintDoctors();
                Console.Write("Select your doctor : ");
                try
                {
                    string doctorID = Console.ReadLine();
                    foreach (var doctor in department.Doctors)
                    {
                        if (doctor.ID == Convert.ToInt32(doctorID))
                        {
                            find = true;
                            SelectDoctorReservation(department, doctor, ref hospital, user);
                        }
                    }
                    if (!find)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter correct ID !");
                        Thread.Sleep(1500);
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Enter correct ID !");
                    Thread.Sleep(1500);
                }

            } while (!find);
        }

        public static void SelectDoctorReservation(Department department, Doctor doctor, ref Hospital hospital, User user)
        {
            bool rez = false;
            do
            {
                Console.Clear();
                department.PrintDoctorWorktimes(doctor);
                Console.Write("\nSelect your reservation : ");
                string reservation = Console.ReadLine();
                if (reservation == "1")
                {
                    if (!doctor.WorkTimes["09:00-11:00"])
                    {
                        rez = true;
                        doctor.WorkTimes["09:00-11:00"] = true;
                        Console.WriteLine($"Tesekkurler {user.Name} {user.Surname}, Siz 09:00-11:00 da {doctor.Name} hekimin qebuluna yazildiniz.");
                        Thread.Sleep(1500);
                        RunProgram(hospital);
                    }
                }
                else if (reservation == "2")
                {
                    if (!doctor.WorkTimes["12:00-14:00"])
                    {
                        rez = true;
                        doctor.WorkTimes["12:00-14:00"] = true;
                        Console.WriteLine($"Tesekkurler {user.Name} {user.Surname}, Siz 12:00-14:00 da {doctor.Name} hekimin qebuluna yazildiniz.");
                        Thread.Sleep(1500);
                        RunProgram(hospital);
                    }
                }
                else if (reservation == "3")
                {
                    if (!doctor.WorkTimes["15:00-17:00"])
                    {
                        rez = true;
                        doctor.WorkTimes["15:00-17:00"] = true;
                        Console.WriteLine($"Tesekkurler {user.Name} {user.Surname}, Siz 15:00-17:00 da {doctor.Name} hekimin qebuluna yazildiniz.");
                        Thread.Sleep(1500);
                        RunProgram(hospital);
                    }
                }
                if (!rez)
                {

                    Console.WriteLine("Teessuf ki sizin secdiyiniz vaxt rezerv olunub");
                    Thread.Sleep(1500);
                    SelectDoctorReservation(department, doctor, ref hospital, user);
                }
            } while (!rez);
        }

        public static void RunProgram(Hospital hospital)
        {
            User user = new User();
            user = EnterUser();
            SelectDepartment(ref hospital, ref user);
        }
    }
}
