using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Controls;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.LoginAuthentication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window, IRefreshable
    {

        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();
        private readonly IUserAuthenticationService userAuthenticationService = ServicesAmbulanceFactory.GetInstance().CreateIUserAuthenticationService();
        public Login()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, this.Grid);
            InitializeComponents();

        }

        private void InitializeComponents()
        {
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, Grid.RowDefinitions.Count, this.Height * Grid.RowDefinitions.First().Height.Value, language.VirtualAssistant);
            InitializeLabels();
            InitializeButtons();

        }
        private void InitializeButtons()
        {
            ButtonContentHelper.SetContent(LoginButton, language.Login);

        }
        private void InitializeLabels()
        {
            LabelHelper.SetLabelContent(EmailLabel, language.Email);
            LabelHelper.SetLabelContent(PasswordLabel, language.Password);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            customPrincipal.Identity = await GetUserPrincipal();
            if (customPrincipal.Identity.GetType() != typeof(AnonymousIdentity))
            {
                UserRoleModalWindow window = new UserRoleModalWindow(customPrincipal, this);
                window.Top = (this.Height - window.Height) / 2;
                window.Left = (this.Width - window.Width) / 2;
                window.ShowDialog();
            }
        }

        private async Task<CustomIdentity> GetUserPrincipal()
        {
            LocalAccount localAccount = await userAuthenticationService.ValidateUser(EmailBox.Text, PasswordBox.Password);
            if (localAccount == null)
            {
                WindowHelper.WriteMessage(language.WrongPasswordOrEmail, ErrorLabel, false);
                return new AnonymousIdentity();
            }

            var roleNames = localAccount.GetRoles();
            if (roleNames == null)
            {
                WindowHelper.WriteMessage(language.NoKnownRoles, ErrorLabel, false);
                return new AnonymousIdentity();
            }
            string[] accountRoles = roleNames.Select(x => x.RoleName).ToArray();
            CustomIdentity customIdentity = new CustomIdentity(localAccount.FullName, localAccount.Email, accountRoles, localAccount.PasswordHash);
            return customIdentity;

        }
        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EmailBox.Text != string.Empty)
                ErrorLabel.Content = new TextBlock() { Text = string.Empty };
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password != string.Empty)
                ErrorLabel.Content = new TextBlock() { Text = string.Empty };
        }
        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new Login());
        }


    }
}
