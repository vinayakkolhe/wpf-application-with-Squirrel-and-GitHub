using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    internal class HomeModel
    {
		HomeViewModel _homeViewModel;
		public HomeModel()
		{
			_homeViewModel = new HomeViewModel();
		}

		private string _Name = "vinayak";

		public string Name
		{
			get { return _Name; }
			set 
			{ 
				_Name = value;
                _homeViewModel.onPropertyChange(_Name);

            }
		}

	}
}
