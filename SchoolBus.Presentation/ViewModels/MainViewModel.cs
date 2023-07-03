using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using SchoolBus.Presentation.Messages;
using SchoolBus.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace SchoolBus.Presentation.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IMyNavigationService myNavigationService;

		private ViewModelBase currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get => currentViewModel;
			set => Set(ref currentViewModel, value);
		}

		public MainViewModel(IMessenger messenger, IMyNavigationService navigation)
		{
			myNavigationService = navigation;
			messenger.Register<MyNavigationMessage>(this,
				message =>
				{
					var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
					CurrentViewModel = viewModel;
				});
		}


		public RelayCommand ParentViewCommand
		{
			get => new RelayCommand(() =>
			{
				myNavigationService.MyNavigateTo<ParentViewModel>();
			});
		}

		public RelayCommand StudentViewCommand
		{
			get => new RelayCommand(() =>
			{
				myNavigationService.MyNavigateTo<StudentViewModel>();
			});
		}

		public RelayCommand ClassViewCommand
		{
			get => new RelayCommand(() =>
			{
				myNavigationService.MyNavigateTo<ClassViewModel>();
			});
		}


	}
}
