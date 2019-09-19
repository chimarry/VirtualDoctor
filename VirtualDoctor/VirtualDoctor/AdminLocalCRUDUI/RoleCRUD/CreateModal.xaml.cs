using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    /// <summary>
    /// Interaction logic for CreateModal.xaml
    /// </summary>
    public partial class CreateModal : Window
    {


        private readonly IRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateIRoleService();
        public CreateModal()
        {
            InitializeComponent();
            InitializeComponents();
   
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
            LabelHelper.SetLabelContent(RoleNameLabel, language.RoleName);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Role role = new Role()
            {
                RoleName = RoleNameBox.Text
            };
            DbStatus status = await roleService.Add(role);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.AddingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.EXISTS)
            {
                WindowHelper.WriteMessage(language.EntityExists, MessageLabel, false);
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
