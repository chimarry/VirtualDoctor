using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly IDoctorService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIDoctorService();
        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        private readonly DoctorViewModel doctor;
        private readonly DoctorClinicsAndTitlesHelper doctorClinicsAndTitlesHelper;
        public EditModal(DoctorViewModel doctor)
        {
            this.doctor = doctor;

            InitializeComponent();
            InitializeComponents();
            InitalizeData();
            doctorClinicsAndTitlesHelper = new DoctorClinicsAndTitlesHelper(ClinicsListBox, MedicalTitlesListBox, MedicalTitleComboBox, ClinicComboBox, doctor);
            InitializeClinicsAndTitles();
        }


        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            ButtonContentHelper.SetContent(AddClinicButton, language.AddRight);
            ButtonContentHelper.SetContent(AddMedicalTitleButton, language.AddRight);
        }
        private void InitializeLabels()
        {
            SetLabelsContent();
        }
        private void SetLabelsContent()
        {
            LabelHelper.SetLabelContent(NameLabel, language.Name);
            LabelHelper.SetLabelContent(LastNameLabel, language.LastName);
            LabelHelper.SetLabelContent(AccountLabel, language.Account);
            LabelHelper.SetLabelContent(WorkExperienceLabel, language.WorkExperience);
            LabelHelper.SetLabelContent(ClinicLabel, language.Clinic);
            LabelHelper.SetLabelContent(SinceLabel, language.Since);
            LabelHelper.SetLabelContent(UntilLabel, language.Until);
            LabelHelper.SetLabelContent(MedicalTitleLabel, language.MedicalTitle);
            LabelHelper.SetLabelContent(GetTitleDateLabel, language.GettingTitleDate);
        }
        private async void InitalizeData()
        {
            (await clinicService.GetAll()).Select(x => Mapping.Mapper.Map<ClinicViewModel>(x))?.ToList()?.
             ForEach(x => ClinicComboBox.Items.Add(x));

            (await medicalTitleService.GetAll()).Select(x => Mapping.Mapper.Map<MedicalTitleViewModel>(x))?.ToList()?.
                ForEach(x => MedicalTitleComboBox.Items.Add(x));
            (await localAccountService.GetAllWithRoleNames()).Select(x => Mapping.Mapper.Map<LocalAccountViewModel>(x))?.ToList()?.
                ForEach(x => AccountComboBox.Items.Add(x));


        }

        private async void InitializeClinicsAndTitles()
        {
            NameBox.Text = doctor.Name;
            LastNameBox.Text = doctor.LastName;
            WorkExperinceBox.Text = doctor.WorkExperience.ToString();
            AccountComboBox.SelectedItem = Mapping.Mapper.Map<LocalAccountViewModel>(await localAccountService.GetByPrimaryKey(new LocalAccount() { IdLocalAccount = doctor.IdLocalAccount }));

            foreach (DoctorClinic doctorClinic in doctor.GetClinics())
            {
                var model = Mapping.Mapper.Map<DoctorClinicViewModel>(doctorClinic);

                doctorClinicsAndTitlesHelper.PutClinicInList(model, DeleteClinicButton_Click);
            }
            foreach (DoctorMedicalTitle mt in doctor.GetMedicalTitles())
            {
                var model = Mapping.Mapper.Map<DoctorMedicalTitleViewModel>(mt);
                model.SetMedicalTitleName();
                doctorClinicsAndTitlesHelper.PutMedicalTitleInList(model, DeleteMedicalTitleButton_Click);
            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            doctor.Name = NameBox.Text;
            doctor.LastName = LastNameBox.Text;
            doctor.IdLocalAccount = ((LocalAccountViewModel)AccountComboBox.SelectedItem).IdLocalAccount;
            doctor.WorkExperience = int.Parse(WorkExperinceBox.Text);
            DbStatus status = await doctorService.Update(Mapping.Mapper.Map<Doctor>(doctor));
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.UpdatingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.NOT_FOUND)
            {
                WindowHelper.WriteMessage(language.EntityExists, MessageLabel, false);
            }
            else if (status == DbStatus.DATABASE_ERROR)
            {
                WindowHelper.WriteMessage(language.DatabaseError, MessageLabel, false);
            }

            SaveButton.IsEnabled = false;
        }
        private void AddMedicalTitleButton_Click(object sender, RoutedEventArgs e)
        {
            doctorClinicsAndTitlesHelper.AddTilte(GettingTitleDatePicker, DeleteMedicalTitleButton_Click);
        }
        private void DeleteMedicalTitleButton_Click(object sender, RoutedEventArgs e)
        {

            doctorClinicsAndTitlesHelper.DeleteMedicalTitle(e, medicalTitleService);
        }
        private void AddClinicButton_Click(object sender, RoutedEventArgs e)
        {

            doctorClinicsAndTitlesHelper.AddClinic(SinceDataPicker, UntilDatePicker, DeleteClinicButton_Click);

        }
        private void DeleteClinicButton_Click(object sender, RoutedEventArgs e)
        {
            doctorClinicsAndTitlesHelper.DeleteClinic(e);
        }


    }
}
