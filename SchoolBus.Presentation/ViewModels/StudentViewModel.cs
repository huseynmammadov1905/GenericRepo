using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolBus.Data.Repos;
using SchoolBus.Model.Concretes;
using SchoolBus.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
	public class StudentViewModel : ViewModelBase
	{
		private readonly IRepository<Student> studentRepo;


		public static Student selectStudent;

		public Student SelectStudent
		{
			get { return selectStudent; }
			set { Set(ref selectStudent, value); }
		}

		public static ObservableCollection<Student> Students { get; set; } = new();

		public StudentViewModel(IRepository<Student> studentRepo)
		{

			this.studentRepo = studentRepo;
			Students = new ObservableCollection<Student>(this.studentRepo.GetAll());
		}


		public RelayCommand StudentAddCommand
		{
			get => new RelayCommand(() =>
			{
				Window window = new StudentAddView();
				window.DataContext = new StudentAddViewModel(window);
				window.Show();

			});
		}


	}
}
