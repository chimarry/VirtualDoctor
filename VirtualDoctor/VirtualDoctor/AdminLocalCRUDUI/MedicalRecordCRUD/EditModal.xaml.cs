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
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalRecordCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly MedicalRecordViewModel medicalRecordViewModel;
        private readonly IMedicalRecordService medicalRecordService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalRecordService();
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        public EditModal(MedicalRecordViewModel medicalRecord)
        {
            medicalRecordViewModel = medicalRecord;
            InitializeComponent();
            WindowHelper.SetBorder(this, this.Container);
            InitializeComponents();
            InitializeData();
        }
        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            InitializeComboBox();
        }
        private void InitializeLabels()
        {

            LabelHelper.SetLabelContent(NameLabel, language.Name);
            LabelHelper.SetLabelContent(LastNameLabel, language.LastName);
            LabelHelper.SetLabelContent(JMBLabel, language.UBN);
            LabelHelper.SetLabelContent(BirthPlaceLabel, language.BirthPlace);
            LabelHelper.SetLabelContent(BirthDateLabel, language.BirthDate);
            LabelHelper.SetLabelContent(GenderLabel, language.Gender);
            LabelHelper.SetLabelContent(MarriageStatusLabel, language.MarriageStatus);
            LabelHelper.SetLabelContent(MothersNameLabel, language.MothersName);
            LabelHelper.SetLabelContent(MothersProfessionLabel, language.MothersProfession);
            LabelHelper.SetLabelContent(FathersNameLabel, language.FathersName);
            LabelHelper.SetLabelContent(FathersProfessionLabel, language.FathersProfession);
            LabelHelper.SetLabelContent(InsuranceNumberLabel, language.InsuranceNumber);
            LabelHelper.SetLabelContent(ResidancePlaceLabel, language.ResidancePlace);
        }


        private async void InitializeComboBox()
        {
            var places = await placeService.GetAll();
            foreach (var place in places)
            {
                ResidancePlaceComboBox.Items.Add(Mapping.Mapper.Map<PlaceViewModel>(place));
            }
        }
        public async void InitializeData()
        {
            NameBox.Text = medicalRecordViewModel.Name;
            LastNameBox.Text = medicalRecordViewModel.LastName;
            BirthDatePicker.SelectedDate = medicalRecordViewModel.BirthDate;
            BirthPlaceBox.Text = medicalRecordViewModel.BirthPlace;
            FathersNameBox.Text = medicalRecordViewModel.FathersFullName;
            MothersNameBox.Text = medicalRecordViewModel.MothersFullName;
            FathersProfessionBox.Text = medicalRecordViewModel.FathersProfession;
            MothersProfessionBox.Text = medicalRecordViewModel.MothersProfession;
            MaleCheckBox.IsChecked = medicalRecordViewModel.Gender == 0 ? true : false;
            FemaleCheckBox.IsChecked = !MaleCheckBox.IsChecked;
            MarriedCheckBox.IsChecked = medicalRecordViewModel.MarriageStatus == 0 ? true : false;
            NotMarriedCheckBox.IsChecked = !MarriedCheckBox.IsChecked;
            JmbBox.Text = medicalRecordViewModel.Jmb;
            InsuranceNumberBox.Text = medicalRecordViewModel.InsuranceNumber;
            ResidancePlaceComboBox.SelectedItem = Mapping.Mapper.Map<PlaceViewModel>((await placeService.GetByPrimaryKey
                (new Place() { IdPlace = medicalRecordViewModel.IdResidence })));

        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            MedicalRecord medicalRecord = new MedicalRecord()
            {
                IdMedicalRecord = medicalRecordViewModel.IdMedicalRecord,
                Name = NameBox.Text,
                LastName = LastNameBox.Text,
                BirthDate = BirthDatePicker.SelectedDate.Value,
                BirthPlace = BirthPlaceBox.Text,
                FathersFullName = FathersNameBox.Text,
                MothersFullName = MothersNameBox.Text,
                FathersProfession = FathersProfessionBox.Text,
                MothersProfession = MothersProfessionBox.Text,
                Gender = (sbyte)(MaleCheckBox.IsChecked.Value ? 0 : 1),
                MarriageStatus = (sbyte)(MarriedCheckBox.IsChecked.Value ? 0 : 1),
                Jmb = JmbBox.Text,
                InsuranceNumber = InsuranceNumberBox.Text,
                IdResidence = ((PlaceViewModel)(ResidancePlaceComboBox.SelectedItem)).IdPlace
            };
            DbStatus status = await medicalRecordService.Update(medicalRecord);
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

            SaveButton.IsEnabled = false;

        }
        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            FemaleCheckBox.IsEnabled = false;
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            MaleCheckBox.IsEnabled = false;
        }

        private void MarriedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NotMarriedCheckBox.IsEnabled = false;
        }

        private void NotMarriedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MarriedCheckBox.IsEnabled = false;
        }

        private void MarriedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            NotMarriedCheckBox.IsEnabled = true;
        }

        private void NotMarriedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MarriedCheckBox.IsEnabled = true;
        }

        private void Male_Unchecked(object sender, RoutedEventArgs e)
        {
            FemaleCheckBox.IsEnabled = true;
        }

        private void Female_Unchecked(object sender, RoutedEventArgs e)
        {
            MaleCheckBox.IsEnabled = true;
        }
    }
}
