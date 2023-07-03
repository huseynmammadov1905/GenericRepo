using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SchoolBus.Data.Repos;
using SchoolBus.Model.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus.Presentation.ViewModels
{
	public class ParentEditViewModel : ViewModelBase
	{
		readonly IRepository<Parent>? parentRepo = new Repository<Parent>();

		private Parent editParent = new();

		public Parent EditParent
		{
			get { return editParent; }
			set { Set(ref editParent, value); }
		}



		private Window dataContext;

		public Window DataContext
		{
			get { return dataContext; }
			set { Set(ref dataContext, value); }
		}

		public ParentEditViewModel(Window window, Parent SelectParent)
		{
			dataContext = window;
			editParent = SelectParent;
		}



		public RelayCommand ParentEditCommand
		{
			get => new RelayCommand(() =>
			{
				try
				{
					if (editParent.FirstName is null || editParent.LastName is null || editParent.Phone is null)
					{
						MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
					}
					else
					{
						foreach (var item in ParentViewModel.Parents)
						{
							if (item.Id == editParent.Id)
							{
								item.FirstName = editParent.FirstName;
								item.LastName = editParent.LastName;
								item.Phone = editParent.Phone;
								break;
							}
						}
						parentRepo.Update(editParent);
						parentRepo.SaveChanges();
						dataContext.Close();
						MessageBox.Show("Parent elave olundu", "", MessageBoxButton.OK);
						//dataContext.Close();
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
