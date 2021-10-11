using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatagridTest.Stores;
namespace DatagridTest.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public SideMenuViewModel SideMenuViewModel { get; }

        public MainViewModel(SideMenuViewModel sideMenuViewModel, NavigationStore navigationStore)
        {
            SideMenuViewModel = sideMenuViewModel;
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
