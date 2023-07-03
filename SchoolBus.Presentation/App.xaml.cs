using GalaSoft.MvvmLight.Messaging;
using SchoolBus.Data.Repos;
using SchoolBus.Model.Concretes;
using SchoolBus.Presentation.Services;
using SchoolBus.Presentation.ViewModels;
using SchoolBus.Presentation.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SchoolBus.Presentation
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static Container Container { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			Register();
			Window window = new MainView();
			var viewModel = Container.GetInstance<MainViewModel>();
			window.DataContext = viewModel;
			window.ShowDialog();
			window.Close();
			base.OnStartup(e);
		}

		private void Register()
		{
			Container = new Container();
			Container.RegisterSingleton<IMyNavigationService, MyNavigationService>();
			Container.RegisterSingleton<IMessenger, Messenger>();

			Container.RegisterSingleton<IRepository<Class>, Repository<Class>>();
			Container.RegisterSingleton<IRepository<Parent>, Repository<Parent>>();
			Container.RegisterSingleton<IRepository<Student>, Repository<Student>>();
		


			Container.Register<MainView>();
			Container.Register<MainViewModel>();

		
			Container.Register<ClassView>();
			Container.Register<ClassViewModel>();

			Container.Register<ParentView>();
			Container.Register<ParentViewModel>();

			Container.Register<StudentView>();
			Container.Register<StudentViewModel>();

		
		}
	}
}
