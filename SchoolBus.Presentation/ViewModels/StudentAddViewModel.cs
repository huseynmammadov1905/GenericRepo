using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolBus.Data.Repos;
using SchoolBus.Model.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
	public class StudentAddViewModel : ViewModelBase
	{
		readonly IRepository<Student>? studentRepo = new Repository<Student>();
		readonly IRepository<Class>? classRepo = new Repository<Class>();
		readonly IRepository<Parent>? parentRepo = new Repository<Parent>();

		private Student addStudent = new();

		public Student AddStudent
		{
			get { return addStudent; }
			set { Set(ref addStudent, value); }
		}

		private Window dataContext;

		public Window DataContext
		{
			get { return dataContext; }
			set { Set(ref dataContext, value); }
		}

		private Parent selectParent = new();

		public Parent SelectParent
		{
			get { return selectParent; }
			set { Set(ref selectParent, value); }
		}

		private Class selectClass = new();

		public Class SelectClass
		{
			get { return selectClass; }
			set { Set(ref selectClass, value); }
		}

		public ObservableCollection<Parent> Parents_ { get; set; }
		public ObservableCollection<Class> Classes_ { get; set; }
		public ObservableCollection<Student> Students_ { get; set; }
		public StudentAddViewModel(Window window)
		{
			dataContext = window;
			addStudent = new();
			Parents_ = ParentViewModel.Parents;
			Classes_ = ClassViewModel.Classes;
			Students_ = StudentViewModel.Students;
		

		}


		public RelayCommand StudentCreateCommand
		{
			get => new RelayCommand(() =>
			{
				try
				{
					if (SelectClass != null && selectParent != null && addStudent!.FirstName != null && addStudent.LastName != null && addStudent!.HomeAdress != null)
					{
						Parents_ = new ObservableCollection<Parent>(this.parentRepo.GetAll());
						Classes_ = new ObservableCollection<Class>(this.classRepo.GetAll());
						addStudent.ParentId = selectParent.Id;
						addStudent.ClassId = selectClass.Id;
						


						StudentViewModel.Students.Add(addStudent);
						studentRepo.Add(addStudent);
						studentRepo.SaveChanges();
						dataContext.Close();

						
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

			});
		}
	}
}
