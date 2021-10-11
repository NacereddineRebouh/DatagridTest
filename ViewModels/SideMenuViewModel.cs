using DatagridTest.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatagridTest.ViewModels
{
    public class SideMenuViewModel : BaseViewModel
    {
        public ICommand NavigateHomeViewModel { get; }
        public ICommand NavigateUsersViewModel { get; }

        public SideMenuViewModel(NavigateCommand<HomeViewModel> navigateHomeViewModel, NavigateCommand<UsersViewModel> navigateUsersViewModel)
        {
            NavigateHomeViewModel = navigateHomeViewModel;
            NavigateUsersViewModel = navigateUsersViewModel;
        }

    }
}
