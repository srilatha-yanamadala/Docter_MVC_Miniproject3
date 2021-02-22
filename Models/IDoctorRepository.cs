using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor_MVC_Miniproject3.Models
{
   public  interface IDoctorRepository
    {
        IEnumerable<Appointment> AllAppointments { get; }
        IEnumerable<Doctor> AllDoctors { get; set; }

        Appointment GetAppointmentsById (int AppointmentId);
   }
}
