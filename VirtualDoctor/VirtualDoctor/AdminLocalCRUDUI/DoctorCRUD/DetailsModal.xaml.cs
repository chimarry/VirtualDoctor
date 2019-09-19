using AmbulanceDatabase;
using AmbulanceDatabase.Entities;
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

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    /// <summary>
    /// Interaction logic for DetailsModal.xaml
    /// </summary>
    public partial class DetailsModal : Window
    {

        private readonly IDoctorService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIDoctorService();
        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
        private readonly ILocalAccountService localAccountService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountService();
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        private readonly DoctorViewModel doctor;
        private readonly DoctorClinicsAndTitlesHelper doctorClinicsAndTitlesHelper;

        public object SaveButton { get; private set; }

        public DetailsModal(DoctorViewModel doctor)
        {
            this.doctor = doctor;

            InitializeComponent();
            InitializeComponents();
            doctorClinicsAndTitlesHelper = new DoctorClinicsAndTitlesHelper(ClinicsListBox, MedicalTitlesListBox, doctor);
            InitializeClinicsAndTitles();
        }


        private void InitializeComponents()
        {
            InitializeLabels();

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
            LabelHelper.SetLabelContent(MedicalTitleLabel, language.MedicalTitle);
            LabelHelper.SetLabelContent(ClinicsLabel, language.Clinics);
        }

        private async void InitializeClinicsAndTitles()
        {
            NameBox.Text = doctor.Name;
            LastNameBox.Text = doctor.LastName;
            WorkExperinceBox.Text = doctor.WorkExperience.ToString();
            var account = Mapping.Mapper.Map<LocalAccountViewModel>(await localAccountService.GetByPrimaryKey(new LocalAccount() { IdLocalAccount = doctor.IdLocalAccount }));
            AccountComboBox.Items.Add(account);
            AccountComboBox.SelectedItem = account;

            foreach (DoctorClinic doctorClinic in doctor.GetClinics())
            {
                doctorClinicsAndTitlesHelper.PutClinicInList(Mapping.Mapper.Map<DoctorClinicViewModel>(doctorClinic));
            }
            foreach (DoctorMedicalTitle mt in doctor.GetMedicalTitles())
            {
                var model = Mapping.Mapper.Map<DoctorMedicalTitleViewModel>(mt);
                model.SetMedicalTitleName();
                doctorClinicsAndTitlesHelper.PutMedicalTitleInList(model);
            }
        }


    }
}
