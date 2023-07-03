using SchoolBus.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Model.Concretes
{
	public class Student : BaseEntity
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public int ParentId { get; set; }
		
		public int ClassId { get; set; }
		public string HomeAdress { get; set; } = null!;
		public string? OtherAdress { get; set; }

		public Parent? Parent { get; set; }

		

		public Class? Class { get; set; }
	}
}
