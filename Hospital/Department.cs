using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Department
    {
        public List<Doctor> Doctors { get; set; }

        public void PrintDoctors()
        {
            Console.WriteLine();
            for (int i = 0; i < Doctors.Count; i++)
            {
                Console.WriteLine($"{i+1}) {Doctors[i].Name} {Doctors[i].Surname}");
                Console.WriteLine();
            }
        }

        public void PrintDoctorWorktimes(Doctor doctor)
        {
            int i = default;
            foreach (var workTime in doctor.WorkTimes)
            {
                Console.WriteLine();
                Console.Write($"{++i}) {workTime.Key} : ");
                if (workTime.Value) Console.WriteLine("Reserved");
                else Console.WriteLine("Not Rezerved");
            }
        }
    }
}
