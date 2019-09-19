using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD
{
    /// <summary>
    /// Interaction logic for CreateModal.xaml
    /// </summary>
    public partial class CreateModal : Window
    {
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        public CreateModal()
        {
            InitializeComponent();
            InitializeComponents();

        }


        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            InitalizeData();
        }
        private void InitializeLabels()
        {
            SetLabelsContent();
        }
        private void SetLabelsContent()
        {
            LabelHelper.SetLabelContent(NameLabel, language.Name);
            LabelHelper.SetLabelContent(PlaceLabel, language.Place);
        }
        private async void InitalizeData()
        {
            var places = (await placeService.GetAll()).Select(x => Mapping.Mapper.Map<PlaceViewModel>(x));
            foreach (PlaceViewModel place in places)
            {
                PlaceComboBox.Items.Add(place);
            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Clinic clinic = new Clinic()
            {
                Name = NameBox.Text,
                IdPlace = ((PlaceViewModel)PlaceComboBox.SelectedItem).IdPlace
            };

            DbStatus status = await clinicService.Add(clinic);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.AddingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.EXISTS)
            {
                WindowHelper.WriteMessage(language.EntityExists, MessageLabel, false);
            }
            else if (status == DbStatus.DATABASE_ERROR)
            {
                WindowHelper.WriteMessage(language.DatabaseError, MessageLabel, false);
            }

            SaveButton.IsEnabled = false;
        }
        private void Reset()
        {
            NameBox.Text = string.Empty;
            PlaceComboBox.SelectedItem = null;
        }
        private void NameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }

        private void PlaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }
    }
}
