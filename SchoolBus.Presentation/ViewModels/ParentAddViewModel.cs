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
	public class ParentAddViewModel : ViewModelBase
	{
		readonly IRepository<Parent>? parentRepo = new Repository<Parent>();
		private Parent addParent = new();

		public Parent AddParent
		{
			get { return addParent; }
			set { Set(ref addParent, value); }
		}

		private Window dataContext;

		public Window DataContext
		{
			get { return dataContext; }
			set { Set(ref dataContext, value); }
		}
		public ObservableCollection<Parent> Parents { get; set; }


		public ParentAddViewModel(Window window)
		{
			DataContext = window;

		}

		public RelayCommand ParentCreateCommand
		{
			get => new RelayCommand(() =>
			{
				try
				{
					if (addParent.FirstName is null || addParent.LastName is null || addParent.Phone is null)
					{
						MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					}
					else
					{
						ParentViewModel.Parents.Add(addParent);
						parentRepo.Add(addParent);
						parentRepo.SaveChanges();
						dataContext.Close();
						MessageBox.Show("Parent elave olundu", "", MessageBoxButton.OK);
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