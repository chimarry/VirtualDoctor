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

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalTitleCRUD
{
    /// <summary>
    /// Interaction logic for EditModal.xaml
    /// </summary>
    public partial class EditModal : Window
    {
        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
        private readonly MedicalTitleViewModel medicalTitle;

        public EditModal(MedicalTitleViewModel medicalTitle)
        {
            this.medicalTitle = medicalTitle;
            InitializeComponent();
            InitializeComponents();
        }
        private void InitializeComponents()
        {
            InitializeLabels();
            ButtonContentHelper.SetContent(SaveButton, language.Save);
            NameBox.Text = medicalTitle.Name;
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
            MedicalTitle entity = new MedicalTitle()
            {
                Name = NameBox.Text,
                IdMedicalTitle = medicalTitle.IdMedicalTitle

            };
     
            DbStatus status = await medicalTitleService.Update(entity);
            if (status == DbStatus.SUCCESS)
            {

                WindowHelper.WriteMessage(language.UpdatingSuccess, MessageLabel, true);
            }
            else if (status == DbStatus.NOT_FOUND)
            {
                WindowHelper.WriteMessage(language.EntityNotFound, MessageLabel, false);
            }
            NameBox.Text = string.Empty;
            SaveButton.IsEnabled = false;
        }

        private void NameBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
        }


    }
}
