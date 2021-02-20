using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Doctor : WorkTime
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Practise { get; set; }

        public Doctor()
        {
            WorkTimes = new Dictionary<string, bool>();
            WorkTimes["09:00-11:00"] = false;
            WorkTimes["12:00-14:00"] = false;
            WorkTimes["15:00-17:00"] = false;
        }
    }
}
