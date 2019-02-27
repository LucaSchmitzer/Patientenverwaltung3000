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
    class Insurance
    {
        public Insurance() { dirty = false; }
        string street;
        string streetnumber;
        string country;
        string zipcode;
        string city;
        int is_Private;
        UInt32 insuranceId;
        string name;

        bool dirty;

        Insurance(UInt32 _id)
        {
            insuranceId = _id;
            dirty = false;
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

        public int Is_Private
        {
            get
            {
                return this.is_Private;
            }
            set
            {
                this.is_Private = value;
                dirty = true;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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
