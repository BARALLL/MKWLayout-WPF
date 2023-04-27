using MKWLayout_WPF.Core;
using System.Windows.Input;

namespace MKWLayout_WPF.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

		public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DatabaseViewCommand { get; set; }


        public HomeViewModel homeVM { get; set; }
        public DatabaseViewModel databaseVM { get; set; }


        private object _currentView;

		public object CurrentView
        {
			get { return _currentView; }
			set 
			{ 
				_currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel() 
		{
			homeVM = new HomeViewModel();
            databaseVM = new DatabaseViewModel();
            
            CurrentView = homeVM;

            HomeViewCommand = new RelayCommand(o => { CurrentView = homeVM; });
            DatabaseViewCommand = new RelayCommand(o => { CurrentView = databaseVM; });
        }
    }
}
