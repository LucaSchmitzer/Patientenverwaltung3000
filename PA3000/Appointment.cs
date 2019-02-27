using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace PA3000
{


  


    class Appointment
    {
        Appointment(UInt32 _id)
        {
            appointmentId = _id;
            dirty = false;
        }

        UInt32 appointmentId;
        string description;
        UInt32 patientId;
        DateTime? date;
        public Appointment() { dirty = false; }

        bool dirty;


        public UInt32 AppointmentId
        {
            get
            {
                return this.appointmentId;
            }
            set
            {
                this.appointmentId = value;
                dirty = true;
            }
        }

        public UInt32 PatientId
        {
            get
            {
                return this.patientId;
            }
            set
            {
                this.patientId = value;
                dirty = true;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                dirty = true;
            }
        }

        public DateTime? Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
                dirty = true;
            }
        }

        public bool Dirty
        {
            get
            {
                return this.dirty;
            }
            set
            {
                this.dirty = value;
            }
        }
    }
}