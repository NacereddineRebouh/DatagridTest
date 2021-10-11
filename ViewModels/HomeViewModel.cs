using DatagridTest.DataAccess;
using DatagridTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatagridTest.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public DatabaseAccess Dba { get; set; }
        private List<Users> _UsersList = null;
        private List<Users> _UsersListDummy = null;

        public List<Users> UsersList
        {
            get { return _UsersList; }
            set { _UsersList = value; OnPropertyChanged("UsersList"); }
        }


        public HomeViewModel()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                threading();
            }).Start();
            Debug.WriteLine("Threading has been Called Successfully!");
        }

        private void threading()
        {
            Debug.WriteLine("----------Welcome to HomeViewModel threading Method------------");
            Dba = new DatabaseAccess();
            Dba.OpenConnection();
            while (true)
            {
                _UsersListDummy = Dba.Get_Users();
                UsersList = _UsersListDummy;
                if (_UsersListDummy.Count != UsersList.Count)
                {
                    UsersList = _UsersListDummy;
                }

                //OperationsList 
                Thread.Sleep(15000); Debug.WriteLine("Updated!");

            }

        }


        public void Quick_Update()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                continueUpdate();
            }).Start();
        }

        public void continueUpdate()
        {
            Debug.WriteLine("inside continueUpdate!");
            Dba = new DatabaseAccess();
            Dba.OpenConnection();
            _UsersListDummy = Dba.Get_Users();
            UsersList = _UsersListDummy;
            if (_UsersListDummy.Count != UsersList.Count)
            {
                Debug.WriteLine("update done!");
                UsersList = _UsersListDummy;
            }
        }

    }
}
