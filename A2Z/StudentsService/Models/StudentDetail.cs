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
        public int studentID { get; set; }
        public string InternationalID { get; set; }
        public DateTime RegistrationTimestamp { get; set; }

	}
}