using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.PlaceCRUD
{
    /// <summary>
    /// Interaction logic for DeleteModal.xaml
    /// </summary>
    public partial class DeleteModal : Window
    {
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        private readonly PlaceViewModel placeViewModel;

        public DeleteModal(PlaceViewModel placeViewModel)
        {
            this.placeViewModel = placeViewModel;
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
            DbStatus status = await placeService.Delete(Mapping.Mapper.Map<Place>(placeViewModel));
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
