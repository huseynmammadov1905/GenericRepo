using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus.Presentation.Services
{
	public interface IMyNavigationService
	{
		void MyNavigateTo<T>() where T : ViewModelBase;
	}
}
