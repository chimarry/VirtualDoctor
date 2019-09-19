using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalTitleCRUD
{
    /// <summary>
    /// Interaction logic for CreateModal.xaml
    /// </summary>
    public partial class CreateModal : Window
    {

        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
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
            LabelHelper.SetLabelContent(NameLabel, language.MedicalTitle);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MedicalTitle medicalTitle = new MedicalTitle()
            {
                Name = NameBox.Text
            };

            DbStatus status = await medicalTitleService.Add(medicalTitle);
            if (status == DbStatus.SUCCESS)
            {
                WindowHelper.WriteMessage(language.AddingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.EXISTS)
            {
                WindowHelper.WriteMessage(language.EntityExists, MessageLabel, false);
            }
            NameBox.Text = string.Empty;
            SaveButton.IsEnabled = false;
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }
    }

}
