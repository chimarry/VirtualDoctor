using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor.LoginAuthentication
{
    /// <summary>
    /// Interaction logic for UserRoleModalWindow.xaml
    /// </summary>
    public partial class UserRoleModalWindow : Window
    {
        private readonly Window loginWindow;
        public UserRoleModalWindow(CustomPrincipal customPrincipal, Window loginWindow)
        {
            InitializeComponent();
            InitializeButtons();
            InitializeRoles(customPrincipal.Identity.Roles);
            this.loginWindow = loginWindow;
        }

        public void InitializeRoles(string[] possibleRoles)
        {
            foreach (var role in possibleRoles)
            {
                RolesListBox.Items.Add(role);
            }
        }
        private void InitializeButtons()
        {
            ButtonContentHelper.SetContent(LogInButton, language.Login);
            ButtonContentHelper.SetContent(CancelButton, language.Cancel);
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            TransferControl(RolesListBox.SelectedItem.ToString());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TransferControl(string role)
        {
            this.Close();
            switch (role)
            {
                case "Doctor": WindowHelper.ShowWindow(loginWindow, new LocalDoctorUI.MainWindow()); break;
                case "OrganizationalAdmin": WindowHelper.ShowWindow(loginWindow, new AdminLocalCRUDUI.OrganizationalAdminMainWindow()); break;
                case "AccountsAdmin": WindowHelper.ShowWindow(loginWindow, new AdminLocalCRUDUI.AccountAdminMainWindow()); break;
                case "PatientAdmin": WindowHelper.ShowWindow(loginWindow, new AdminLocalCRUDUI.PatientAdminMainWindow()); break;

            }
        }
    }
}
