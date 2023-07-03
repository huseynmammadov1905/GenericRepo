using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using SchoolBus.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Presentation.Services
{
	public class MyNavigationService : IMyNavigationService
	{
		private readonly IMessenger messenger;

		public MyNavigationService(IMessenger messenger)
		{
			this.messenger = messenger;
		}

		public void MyNavigateTo<T>() where T : ViewModelBase
		{
			messenger.Send(new MyNavigationMessage { ViewModelType = typeof(T) });
		}
	}
}
