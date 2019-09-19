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

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalTitleCRUD
{
    /// <summary>
    /// Interaction logic for DeleteModal.xaml
    /// </summary>
    public partial class DeleteModal : Window
    {
        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
        private readonly MedicalTitleViewModel medicalTitle;

        public DeleteModal(MedicalTitleViewModel medicalTitle)
        {

            this.medicalTitle = medicalTitle;
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
            DbStatus status = await medicalTitleService.Delete(Mapping.Mapper.Map<MedicalTitle>(medicalTitle));
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
