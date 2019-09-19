using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Procedures;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD
{
    /// <summary>
    /// Interaction logic for CreateModal.xaml
    /// </summary>
    public partial class CreateModal : Window
    {
        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();
        private readonly ILocalAccountRoleService localAccountRoleService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountRoleService();
        public CreateModal()
        {
            InitializeComponent();
            InitializeComponents();
            this.DataContext = new LocalAccountRolesDataSource();
        }
        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
        }
        private void InitializeLabels()
        {
            SetLabelsContent();
        }
        private void SetLabelsContent()
        {
            LabelHelper.SetLabelContent(EmailLabel, language.Email);
            LabelHelper.SetLabelContent(PasswordLabel, language.Password);
            LabelHelper.SetLabelContent(FullNameLabel, language.FullName);
            LabelHelper.SetLabelContent(RolesLabel, language.Roles);
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            LocalAccount localAccount = new LocalAccount()
            {
                FullName = FullNameBox.Text,
                Email = EmailBox.Text,
                PasswordHash = PasswordBox.Password,
            };
            ObservableCollection<RoleViewModel> roles = selectedItems.SelectedItems as ObservableCollection<RoleViewModel>;
            localAccount.SetRoles(roles.Select(x => Mapping.Mapper.Map<Role>(x)).ToList());
            DbStatus status = await localAccountService.Add(localAccount);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.AddingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.EXISTS)
            {
                WindowHelper.WriteMessage(language.EntityExists, MessageLabel, false);
            }
            else
            {
                WindowHelper.WriteMessage(language.DatabaseError, MessageLabel, false);
            }

            ResetState();
        }
        private void ResetState()
        {
            FullNameBox.Text = string.Empty;
            EmailBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
            SaveButton.IsEnabled = false;
            selectedItems.SelectedItems = new ObservableCollection<RoleViewModel>();
        }

        private void EmailBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }

        private void FullNameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }
    }
}
