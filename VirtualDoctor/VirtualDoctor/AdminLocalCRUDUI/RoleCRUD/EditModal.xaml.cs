using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly IRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateIRoleService();
        private readonly RoleViewModel roleViewModel;

        public EditModal(RoleViewModel role)
        {
            roleViewModel = role;
            InitializeComponent();
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            RoleNameBox.Text = roleViewModel.RoleName;
        }
        private void InitializeLabels()
        {
            SetLabelsContent();
        }
        private void SetLabelsContent()
        {
            LabelHelper.SetLabelContent(RoleNameLabel, language.RoleName);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Role role = new Role()
            {
                RoleName = RoleNameBox.Text,
                IdRole = roleViewModel.IdRole,
            };
            DbStatus status = await roleService.Update(role);
            if (status == DbStatus.SUCCESS)
            {
                
                WindowHelper.WriteMessage(language.UpdatingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.NOT_FOUND)
            {
                WindowHelper.WriteMessage(language.EntityNotFound, MessageLabel, false);
            }
            RoleNameBox.Text = string.Empty;
            SaveButton.IsEnabled = false;
        }

        private void RoleNameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }


    }
}
