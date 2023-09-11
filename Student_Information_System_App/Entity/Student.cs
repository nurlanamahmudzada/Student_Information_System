using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Information_System_App.Entity
{
    public class Student : Staff
    {   
        public int EntrancePoint { get; set; }
        public int DepartmentId { get; set; }
    }
}