using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public int Height { get; set; }

        public DateTime DOB { get; set; }
    }
}