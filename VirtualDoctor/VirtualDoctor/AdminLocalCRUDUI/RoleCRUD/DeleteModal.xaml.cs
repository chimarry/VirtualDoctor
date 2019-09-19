using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    /// <summary>
    /// Interaction logic for DeleteModal.xaml
    /// </summary>
    public partial class DeleteModal : Window
    {
        private readonly IRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateIRoleService();
        private readonly RoleViewModel roleViewModel;

        public DeleteModal(RoleViewModel role)
        {
            roleViewModel = role;
            InitializeComponent();
            InitializeComponents();
        }
        public void InitializeComponents()
        {
            ButtonContentHelper.SetContent(YesButton, language.Yes);
            ButtonContentHelper.SetContent(NoButton, language.No);
            LabelHelper.SetLabelContent(QuestionLabel, language.ConfirmDelete);
        }
        private async void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DbStatus status = await roleService.Delete(Mapping.Mapper.Map<Role>(roleViewModel));
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
