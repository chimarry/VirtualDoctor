using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Windows;
using VirtualDoctor.LoginAuthentication;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ILocalAccountRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountRoleService();
        private readonly IClinicService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();

        public MainWindow()
        {
            InitializeComponent();
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
            WindowHelper.SetBorder(this, this.Grid);

      
            Window window = new LoginAuthentication.Login
            {
                Left = this.Left,
                Top = this.Top
            };
            this.Close();
            window.Show();
        }


    }
}
