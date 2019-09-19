using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly LocalAccountViewModel localAccountViewModel;
        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();

        public EditModal(LocalAccountViewModel localAccountViewModel)
        {
            this.localAccountViewModel = localAccountViewModel;
            InitializeComponent();
            DataContext = new LocalAccountRolesDataSource(localAccountViewModel.IdLocalAccount);
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            InitializeData();
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
                IdLocalAccount = localAccountViewModel.IdLocalAccount
            };
            ObservableCollection<RoleViewModel> roles = selectedItems.SelectedItems as ObservableCollection<RoleViewModel>;
            localAccount.SetRoles(roles.Select(x => Mapping.Mapper.Map<Role>(x)).ToList());
            DbStatus status = await localAccountService.Update(localAccount);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.UpdatingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.NOT_FOUND)
            {
                WindowHelper.WriteMessage(language.EntityNotFound, MessageLabel, false);
            }
            else
            {
                WindowHelper.WriteMessage(language.DatabaseError, MessageLabel, false);
            }
            
        }
        public void InitializeData()
        {
            FullNameBox.Text = localAccountViewModel.FullName;
            PasswordBox.Password = localAccountViewModel.PasswordHash;
            EmailBox.Text = localAccountViewModel.Email;

        }
    }
}
