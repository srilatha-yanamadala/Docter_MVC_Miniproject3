using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MVC_Miniproject3.Models
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public Appointment( DateTime dateTime, Doctor doctor, Patient patient)
        {
            
            DateTime = dateTime;
           
            Doctor = doctor;
            
            Patient = patient;
        }

        
        public int AppointmentId { get; set; }
        public DateTime DateTime { get; set; }

        [Display(Name= "Doctor")]
        public int DoctorId { get; set; }


        [ForeignKey("DoctorId")]
        public  Doctor Doctor{ get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public  Patient Patient { get; set; }


    }
}
