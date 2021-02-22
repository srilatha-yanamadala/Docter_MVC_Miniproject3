using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MVC_Miniproject3.Models
{
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(int doctorId, string dOctorName, string specliazation, string imageUrl, List<Appointment> appointments)
        {
            DoctorId = doctorId;
            DOctorName = dOctorName;
            Specliazation = specliazation;
            ImageUrl = imageUrl;
            Appointments = appointments;
        }

        public int DoctorId { get; set; }
        public string  DOctorName { get; set; }
        public string Specliazation { get; set; }

        public string ImageUrl { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
