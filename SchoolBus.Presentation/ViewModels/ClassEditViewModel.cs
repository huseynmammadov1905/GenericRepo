using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolBus.Data.Repos;
using SchoolBus.Model.Concretes;
using SchoolBus.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
	public class ClassEditViewModel : ViewModelBase
	{
		public IMyNavigationService myNavigationService;
		private Class _class = new();

		public Class _Class
		{
			get { return _class; }
			set { _class = value; }
		}

		public Class ClassTemp { get; set; } = new Class();



		private readonly IRepository<Class> clasRepo = new Repository<Class>();



		public ClassEditViewModel()
		{
			_class = ClassViewModel.selectClass;

		}


		public RelayCommand EditClassCommand
		{
			get => new RelayCommand(() =>
			{
				try
				{
					if (_class.Name is null)
					{
						MessageBox.Show("dsfa", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					}
					else
					{
						ClassTemp = ClassViewModel.selectClass;
						Class editClass = clasRepo!.Get(c => c.Id == ClassViewModel.selectClass.Id!)!.FirstOrDefault()!;
						editClass.Name = ClassTemp.Name;

						clasRepo.Update(editClass);
						clasRepo.SaveChanges();
						ClassViewModel.Classes.Remove(ClassTemp);
						ClassViewModel.Classes.Add(editClass);

						MessageBox.Show("Class Edit olundu", "", MessageBoxButton.OK);

					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

				}

			});
		}
	}
}
