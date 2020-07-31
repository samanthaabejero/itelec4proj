using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ApiModels
{
    public class Student_Model
    {
        public Int32 Id { get; set; }
        public String StudentCode { get; set; }
        public String FullName { get; set; }
        public Int32 CourseId { get; set; }
        public String Course { get; set; }
    }
}