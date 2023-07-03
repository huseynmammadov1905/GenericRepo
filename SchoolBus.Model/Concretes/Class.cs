using SchoolBus.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Model.Concretes
{
	public class Class : BaseEntity
	{
		public string Name { get; set; } = null!;
		public ObservableCollection<Student>? Students { get; set; }

		public override string ToString() => Name;

	}
}
