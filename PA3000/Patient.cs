using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PA3000
{   
    class Patient
    {
        UInt32 patientId;
        string firstName;
        string lastName;
        UInt32 insuranceId;
        DateTime? birthday;
        DateTime? createdDate;
        string street;
        string streetnumber;
        string country;
        string zipcode;
        string city;

        bool dirty;

        public Patient(UInt32 _id)
        {
            patientId = _id;
            dirty = false;
        }

        public Patient() { dirty = false; }


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

        public DateTime? Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
                dirty = true;
            }
        }

        public DateTime? CreatedDate
        {
            get
            {
                return this.createdDate;
            }
            set
            {
                this.createdDate = value;
                dirty = true;
            }
        }
        public UInt32 InsuranceId
        {
            get
            {
                return this.insuranceId;
            }
            set
            {
                this.insuranceId = value;
                dirty = true;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                dirty = true;
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                dirty = true;
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }
            set
            {
                this.street = value;
                dirty = true;
            }
        }

        public string Streetnumber
        {
            get
            {
                return this.streetnumber;
            }
            set
            {
                this.streetnumber = value;
                dirty = true;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                dirty = true;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                dirty = true;
            }
        }

        public string Zipcode
        {
            get
            {
                return this.zipcode;
            }
            set
            {
                this.zipcode = value;
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
