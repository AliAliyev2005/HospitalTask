
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
                if(reservation.Equals("1") || reservation.Equals("2") || reservation.Equals("3"))
                {
                    var time = doctor.WorkTimes.ElementAt(Convert.ToInt32(reservation) - 1);
                    if(!time.Value)
                    {
                        rez = true;
                        doctor.WorkTimes[time.Key] = true;
                        Console.WriteLine($"\nTesekkurler {user.Name} {user.Surname}, Siz {time.Key} da {doctor.Name} hekimin qebuluna yazildiniz.");
                        Thread.Sleep(1500);
                        RunProgram(hospital);
                    }
                }
                if (!rez)
                {

                    Console.WriteLine("\nTeessuf ki sizin secdiyiniz vaxt rezerv olunub");
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
