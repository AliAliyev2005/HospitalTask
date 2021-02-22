using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public static class File
    {
        public static void Save(ref Hospital hospital)
        {
            using (FileStream fs = new FileStream("doctors.txt",FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs,Encoding.UTF8))
                {
                    var departments = new List<Department>
                    {
                        hospital.Pediatriya,
                        hospital.Stamotologiya,
                        hospital.Travmatologiya
                    };
                    foreach (var department in departments)
                    {
                        foreach (var doctor in department.Doctors)
                        {
                            foreach (var time in doctor.WorkTimes)
                            {
                                if(time.Value.Equals(true))
                                {
                                    sw.WriteLine($"{doctor.ID} {time.Key} ");
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void Download(ref Hospital hospital)
        {
            using (FileStream fs = new FileStream("doctors.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var departments = new List<Department>
                    {
                        hospital.Pediatriya,
                        hospital.Stamotologiya,
                        hospital.Travmatologiya
                    };
                    var arr = sr.ReadToEnd().Split('\n');
                    foreach (var item in arr)
                    {
                        if(!item.Equals(string.Empty))
                        {
                            var time = item.Split(' ');
                            foreach (var department in departments)
                            {
                                foreach (var doctor in department.Doctors)
                                {
                                    if (doctor.ID == Convert.ToInt32(time[0]))
                                    {
                                        Console.WriteLine(doctor.WorkTimes[Convert.ToString(time[1])]);
                                        doctor.WorkTimes[time[1]] = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
