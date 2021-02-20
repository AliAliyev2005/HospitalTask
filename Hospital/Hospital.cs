using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Hospital
    {
        public Department Pediatriya { get; set; }
        public Department Travmatologiya { get; set; }
        public Department Stamotologiya { get; set; }

        public Hospital()
        {
            Pediatriya = new Department();
            Pediatriya.Doctors = new List<Doctor>();
            Travmatologiya = new Department();
            Travmatologiya.Doctors = new List<Doctor>();
            Stamotologiya = new Department();
            Stamotologiya.Doctors = new List<Doctor>();

            Pediatriya.Doctors.Add(new Doctor
            {
                Name = "Fizuli",
                Surname = "Huseynov",
                Practise = 10
            });
            Pediatriya.Doctors.Add(new Doctor
            {
                Name = "Mirze",
                Surname = "Quliyev",
                Practise = 4
            });

            Travmatologiya.Doctors.Add(new Doctor
            {
                Name = "Bayram",
                Surname = "Elekberov",
                Practise = 7
            });
            Travmatologiya.Doctors.Add(new Doctor
            {
                Name = "Mark",
                Surname = "Markli",
                Practise = 2
            });
            Travmatologiya.Doctors.Add(new Doctor
            {
                Name = "John",
                Surname = "Johnlu",
                Practise = 3
            });

            Stamotologiya.Doctors.Add(new Doctor
            {
                Name = "Elcin",
                Surname = "Abbasov",
                Practise = 4
            });
            Stamotologiya.Doctors.Add(new Doctor
            {
                Name = "Arif",
                Surname = "Balabeyov",
                Practise = 8
            });
        }

    }
}
