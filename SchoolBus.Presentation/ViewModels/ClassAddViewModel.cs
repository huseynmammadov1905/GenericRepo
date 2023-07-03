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
	public class ClassAddViewModel : ViewModelBase
	{
		readonly IRepository<Class>? classRepo = new Repository<Class>();
		private Class addClass = new();

		public Class AddClass
		{
			get { return addClass; }
			set { Set(ref addClass, value); }
		}

		private Window dataContext;

		public Window DataContext
		{
			get { return dataContext; }
			set { Set(ref dataContext, value); }
		}
		public ObservableCollection<Class> Classes { get; set; }


		public ClassAddViewModel(Window window)
		{
			DataContext = window;

		}

		public RelayCommand ClassCreateCommand
		{
			get => new RelayCommand(() =>
			{
				try
				{
					if (AddClass.Name is null)
					{
						MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					}
					else
					{
						ClassViewModel.Classes.Add(addClass);
						classRepo.Add(addClass);
						classRepo.SaveChanges();
						dataContext.Close();
						MessageBox.Show("Class elave olundu", "", MessageBoxButton.OK);
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
