using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Linq;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();

        private readonly ClinicViewModel clinicViewModel;
        public EditModal(ClinicViewModel clinic)
        {
            clinicViewModel = clinic;
            InitializeComponent();
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
            LabelHelper.SetLabelContent(NameLabel, language.Name);
            LabelHelper.SetLabelContent(PlaceLabel, language.Place);
        }

        private async void InitializeData()
        {
            var places = (await placeService.GetAll()).Select(x => Mapping.Mapper.Map<PlaceViewModel>(x));
            foreach (PlaceViewModel model in places)
            {
                PlaceComboBox.Items.Add(model);
            }

            NameBox.Text = clinicViewModel.Name;
            var place = await placeService.GetByPrimaryKey(new Place() { IdPlace = clinicViewModel.IdPlace });
            PlaceComboBox.SelectedItem = Mapping.Mapper.Map<PlaceViewModel>(place);
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            Clinic clinic = new Clinic()
            {
                Name = NameBox.Text,
                IdPlace = ((PlaceViewModel)PlaceComboBox.SelectedItem).IdPlace
            };

            DbStatus status = await clinicService.Update(clinic);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.UpdatingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.NOT_FOUND)
            {
                WindowHelper.WriteMessage(language.EntityNotFound, MessageLabel, false);
            }
            else if (status == DbStatus.DATABASE_ERROR)
            {
                WindowHelper.WriteMessage(language.DatabaseError, MessageLabel, false);
            }

        }


    }
}
