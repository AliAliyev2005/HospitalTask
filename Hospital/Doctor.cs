using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Doctor : WorkTime
    {
        private static int s_id = default;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Practise { get; set; }

        public Doctor()
        {
            ID = ++s_id;
            WorkTimes = new Dictionary<string, bool>
            {
                ["09:00-11:00"] = false,
                ["12:00-14:00"] = false,
                ["15:00-17:00"] = false
            };
        }
    }
}
