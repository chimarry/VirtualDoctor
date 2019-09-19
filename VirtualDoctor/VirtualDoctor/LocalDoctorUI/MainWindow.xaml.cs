using System.Windows;
using System.Windows.Input;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Controls;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.LocalDoctorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window, IRefreshable
    {

        private int Count;
        public MainWindow()
        {
            InitializeComponent();
            InitializeItsComponents();
        }
        private void InitializeItsComponents()
        {
            Count = WindowHelper.SetBorder(this, this.Grid);
            InitializeButton(PatientControl, language.PatientControl);
            InitializeButton(Doctors, language.Doctors);
            InitializeButton(MedicalRecordsReview, language.MedicalRecordsReview);
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, Count, Height, language.VirtualAssistant);

        }
        private void InitializeButton(RoundButtonControl control, string buttonContent)
        {
            control.Height = control.Width = ((this.Height / Count) * Shared.Config.Properties.Default.ButtonProportion);
            ButtonContentHelper.SetContent(control.RoundButton.Button, buttonContent);
        }



        private void PatientControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new PatientControl() { ReturnToWindow = new MainWindow() });
        }

        private void MedicalRecordsReview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new MedicalRecordsReview() { ReturnToWindow = new MainWindow() });

        }
        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new MainWindow() );
        }

        private void Doctors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new DoctorsReview() { ReturnToWindow = new MainWindow() });
        }
    }
}
