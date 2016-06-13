using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsService.Models
{
    public class StudentDetail
    {
        [Key]
        public int StudentRef { get; set; }
        public string InternationalNmber { get; set; }
    }
}