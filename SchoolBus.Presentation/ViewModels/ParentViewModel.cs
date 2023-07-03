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
	public class ParentViewModel : ViewModelBase
	{
		private readonly IRepository<Parent> parentRepo;


		public static Parent selectParent;

		public Parent SelectParent
		{
			get { return selectParent; }
			set { Set(ref selectParent, value); }
		}

		public static ObservableCollection<Parent> Parents { get; set; } = new();

		public ParentViewModel(IRepository<Parent> parentRepo)
		{

			this.parentRepo = parentRepo;
			Parents = new ObservableCollection<Parent>(this.parentRepo.GetAll());
		}


		public RelayCommand ParentAddCommand
		{
			get => new RelayCommand(() =>
			{
				Window window = new ParentAddView();
				window.DataContext = new ParentAddViewModel(window);
				window.Show();

			});
		}

		public RelayCommand ParentEditCommand
		{
			get => new RelayCommand(() =>
			{
				Window window = new ParentEditView();
				window.DataContext = new ParentEditViewModel(window, SelectParent);
				window.Show();

			});
		}
	}
}
