using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD
{
    /// <summary>
    /// Interaction logic for DeleteModal.xaml
    /// </summary>
    public partial class DeleteModal : Window
    {
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private readonly ClinicViewModel clinicViewModel;

        public DeleteModal(ClinicViewModel clinic)
        {
            clinicViewModel = clinic;
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
            DbStatus status = await clinicService.Delete(Mapping.Mapper.Map<Clinic>(clinicViewModel));
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
