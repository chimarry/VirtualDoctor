using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.PlaceCRUD
{
    /// <summary>
    /// Interaction logic for CreateModal.xaml
    /// </summary>
    public partial class CreateModal : Window
    {
        private static int MAX_DROP_DOWN_HEIGHT = 60;
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        public CreateModal()
        {
            InitializeComponent();
            InitializeComponents();

        }


        private void InitializeComponents()
        {
            InitializeLabels();
            InitalizeComboBoxes();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
        }
        private void InitializeLabels()
        {
            LabelHelper.SetLabelContent(NameLabel, language.Name);
            LabelHelper.SetLabelContent(TerrainQualityLabel, language.TerrainQuality);
            LabelHelper.SetLabelContent(FoodQualityLabel, language.FoodQuality);
            LabelHelper.SetLabelContent(RecreationalWaterLabel, language.RecreationalWaterQuality);
            LabelHelper.SetLabelContent(DrinkingWaterQualityLabel, language.DrinkingWaterQuality);
            LabelHelper.SetLabelContent(MedicalVasteLabel, language.MedicalVasteInformation);
            LabelHelper.SetLabelContent(InlandWaterQualityLabel, language.InlandWaterQualtiy);
            LabelHelper.SetLabelContent(NoiseInformationLabel, language.NoiseInformation);
            LabelHelper.SetLabelContent(RadiationLabel, language.Radiation);
            LabelHelper.SetLabelContent(CountryNameLabel, language.CountryName);
            LabelHelper.SetLabelContent(PostalCodeLabel, language.PostalCode);
            LabelHelper.SetLabelContent(AirQualityLabel, language.AirQuality);
        }
        private void InitalizeComboBoxes()
        {
            for (int i = 0; i <= PlaceViewModel.END_SCALE; ++i)
            {
                RadiationComboBox.Items.Add(i);
                NoiseInformationComboBox.Items.Add(i);
                MedicalVasteComboBox.Items.Add(i);
            }
            for (int i = PlaceViewModel.END_SCALE; i >= 0; --i)
            {
                AirQualityComboBox.Items.Add(i);
                DrinkingWaterComboBox.Items.Add(i);
                RecreationalWaterComboBox.Items.Add(i);
                FoodQualityComboBox.Items.Add(i);
                TerrainQualityComboBox.Items.Add(i);
                InlandWaterQualityComboBox.Items.Add(i);
            }
            RadiationComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            AirQualityComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            RecreationalWaterComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            DrinkingWaterComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            FoodQualityComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            TerrainQualityComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            MedicalVasteComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            InlandWaterQualityComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
            NoiseInformationComboBox.MaxDropDownHeight = MAX_DROP_DOWN_HEIGHT;
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Place place = new Place()
            {
                Name = NameBox.Text,
                CountryName = CountryNameBox.Text,
                PostalCode = PostalCodeBox.Text,
                FoodQuality = (int)FoodQualityComboBox.SelectedItem,
                AirQuality = (int)AirQualityComboBox.SelectedItem,
                DrinkingWaterQuality = (int)DrinkingWaterComboBox.SelectedItem,
                RecreationalWaterQuality = (int)RecreationalWaterComboBox.SelectedItem,
                TerrainQuality = (int)TerrainQualityComboBox.SelectedItem,
                InlandWaterQuality = (int)InlandWaterQualityComboBox.SelectedItem,
                MedicalVasteInformation = (int)MedicalVasteComboBox.SelectedItem,
                NoiseInformation = (int)NoiseInformationComboBox.SelectedItem,
                Radiation = (int)RadiationComboBox.SelectedItem

            };
            DbStatus status = await placeService.Add(place);

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
            ResetValues();
            SaveButton.IsEnabled = false;
        }
        private void ResetValues()
        {
            NameBox.Text = string.Empty;
            CountryNameBox.Text = string.Empty;
            PostalCodeBox.Text = string.Empty;
            FoodQualityComboBox.SelectedItem = null;
            AirQualityComboBox.SelectedItem = null;
            DrinkingWaterComboBox.SelectedItem = null;
            RecreationalWaterComboBox.SelectedItem = null;
            TerrainQualityComboBox.SelectedItem = null;
            InlandWaterQualityComboBox.SelectedItem = null;
            MedicalVasteComboBox.SelectedItem = null;
            NoiseInformationComboBox.SelectedItem = null;
            RadiationComboBox.SelectedItem = null;

        }
    }
}
