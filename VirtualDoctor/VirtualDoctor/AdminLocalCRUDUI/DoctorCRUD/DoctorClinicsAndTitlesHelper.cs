using AmbulanceDatabase;
using AmbulanceDatabase.Entities;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    public class DoctorClinicsAndTitlesHelper
    {
        public ListBox ClinicsListBox { get; set; }
        public ListBox MedicalTitlesListBox { get; set; }
        public ComboBox MedicalTitleComboBox { get; set; }
        public ComboBox ClinicComboBox { get; set; }
        private readonly DoctorViewModel doctor;

        public DoctorClinicsAndTitlesHelper(ListBox clinicsListBox, ListBox medicalTitlesListBox, DoctorViewModel doctor)
        {
            ClinicsListBox = clinicsListBox;
            MedicalTitlesListBox = medicalTitlesListBox;
            this.doctor = doctor;
        }

        public DoctorClinicsAndTitlesHelper(ListBox clinicsListBox, ListBox medicalTitlesListBox, ComboBox medicalTitleComboBox, ComboBox clinicComboBox, DoctorViewModel doctor)
        {
            ClinicsListBox = clinicsListBox;
            MedicalTitlesListBox = medicalTitlesListBox;
            MedicalTitleComboBox = medicalTitleComboBox;
            ClinicComboBox = clinicComboBox;
            this.doctor = doctor;
        }

        public void AddTilte(DatePicker gettingTitleDatePicker, RoutedEventHandler onDelete)
        {
            MedicalTitleViewModel medicalTitleViewModel = (MedicalTitleViewModel)MedicalTitleComboBox.SelectedItem;
            DateTime gettingTitleDate = gettingTitleDatePicker.SelectedDate.Value;
            DoctorMedicalTitleViewModel doctorMedicalTitleViewModel = new DoctorMedicalTitleViewModel()
            {
                IdMedicalTitle = medicalTitleViewModel.IdMedicalTitle,
             //   MedicalTitleName = medicalTitleViewModel.Name,
                GettingTitleDate = gettingTitleDate,
                IdDoctor = doctor.IdDoctor
            };
            doctorMedicalTitleViewModel.SetMedicalTitleName();
            doctor.GetMedicalTitles().Add(Mapping.Mapper.Map<DoctorMedicalTitle>(doctorMedicalTitleViewModel));
            PutMedicalTitleInList(doctorMedicalTitleViewModel, onDelete);
            MedicalTitleComboBox.Items.Remove(medicalTitleViewModel);
            gettingTitleDatePicker.SelectedDate = null;
        }
        public void AddClinic(DatePicker sinceDatePicker, DatePicker untilDatePicker, RoutedEventHandler onDelete)
        {

            ClinicViewModel clinicViewModel = ClinicComboBox.SelectedItem as ClinicViewModel;
            DateTime since = sinceDatePicker.SelectedDate.Value;
            DateTime? until = untilDatePicker.SelectedDate != null ? untilDatePicker.SelectedDate : null;
            DoctorClinicViewModel doctorClinicViewModel = new DoctorClinicViewModel()
            {
                IdClinic = clinicViewModel.IdClinic,
                Since = since,
                UntilDate = until,
                IdDoctor = doctor.IdDoctor

            };
            doctor.GetClinics().Add(Mapping.Mapper.Map<DoctorClinic>(doctorClinicViewModel));
            PutClinicInList(doctorClinicViewModel, onDelete);
            untilDatePicker.SelectedDate = null;
            sinceDatePicker.SelectedDate = null;
            ClinicComboBox.SelectedItem = null;
        }

        public void DeleteClinic(RoutedEventArgs e)
        {
            StackPanel item = (e.OriginalSource as Button).Parent as StackPanel;
            string sinceDate = (item.Children[2] as TextBlock).Text.Substring(language.Since.Count() + 2);
            DoctorClinicViewModel doctorClinicViewModel = new DoctorClinicViewModel()
            {
                IdClinic = int.Parse((item.Children[0] as TextBlock).Text),
                Since = DateTime.Parse(sinceDate)

            };
            doctor.GetClinics().Remove(doctor.GetClinics().Where(x => x.IdClinic == doctorClinicViewModel.IdClinic && x.Since == doctorClinicViewModel.Since).Single());
            ClinicsListBox.Items.Remove(item);
            ClinicsListBox.Items.Refresh();
        }
        public async void DeleteMedicalTitle(RoutedEventArgs e, IMedicalTitleService medicalTitleService)
        {
            StackPanel item = (e.OriginalSource as Button).Parent as StackPanel;

            DoctorMedicalTitle medicalTitle = new DoctorMedicalTitle()
            {
                IdMedicalTitle = int.Parse((item.Children[0] as TextBlock).Text),

            };
            doctor.GetMedicalTitles().Remove(doctor.GetMedicalTitles().Where(x => x.IdMedicalTitle == medicalTitle.IdMedicalTitle).Single());
            MedicalTitle titleToAdd = await medicalTitleService.GetByPrimaryKey(new MedicalTitle() { IdMedicalTitle = medicalTitle.IdMedicalTitle });
            MedicalTitleComboBox.Items.Add(Mapping.Mapper.Map<MedicalTitleViewModel>(titleToAdd));

            MedicalTitlesListBox.Items.Remove(item);
            MedicalTitlesListBox.Items.Refresh();
        }
        public void PutClinicInList(DoctorClinicViewModel doctorClinicViewModel, RoutedEventHandler onDelete = null)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock()
            {
                Visibility = Visibility.Hidden,
                Text = doctorClinicViewModel.IdClinic.ToString()
            });
            stackPanel.Children.Add(new TextBlock()
            {
                Text = language.Name + " : " + doctorClinicViewModel.ClinicsName
            });
            stackPanel.Children.Add(new TextBlock()
            {
                Text = language.Since + " : " + doctorClinicViewModel.Since
            });
            stackPanel.Children.Add(new TextBlock()
            {
                Text = language.Until + " : " + doctorClinicViewModel.UntilDate
            });
            if (onDelete != null)
            {
                Button deleteButton = new Button()
                {
                    Content = language.Delete
                };
                deleteButton.Click += onDelete;

                stackPanel.Children.Add(deleteButton);
            }
            ClinicsListBox.Items.Add(stackPanel);
            ClinicsListBox.Items.Refresh();
        }
        public void PutMedicalTitleInList(DoctorMedicalTitleViewModel doctorMedicalTitleViewModel, RoutedEventHandler onDelete = null)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(new TextBlock()
            {
                Visibility = Visibility.Hidden,
                Text = doctorMedicalTitleViewModel.IdMedicalTitle.ToString()
            });
            stackPanel.Children.Add(new TextBlock()
            {
                Text = language.Name + " : " + doctorMedicalTitleViewModel.MedicalTitleName
            });
            stackPanel.Children.Add(new TextBlock()
            {
                Text = language.GettingTitleDate + " : " + doctorMedicalTitleViewModel.GettingTitleDate
            });
            if (onDelete != null)
            {
                Button deleteButton = new Button()
                {
                    Content = language.Delete
                };

                deleteButton.Click += onDelete;
                stackPanel.Children.Add(deleteButton);
            }
            MedicalTitlesListBox.Items.Add(stackPanel);
            MedicalTitlesListBox.Items.Refresh();

        }
    }
}
