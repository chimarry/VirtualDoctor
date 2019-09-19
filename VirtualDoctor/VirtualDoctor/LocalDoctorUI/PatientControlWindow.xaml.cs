using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Controls;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;
namespace VirtualDoctor.LocalDoctorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PatientControl : Window, IRefreshable, IWindowReturnable
    {

        private int Count;
        private int CountOptionsGrid;
        private int CountMedicalRecordGrid;

        public Window ReturnToWindow { get; set; }
        public PatientControl()
        {
            InitializeComponent();
            InitializeItsComponents();
            InitializeButton(GiveReceipt.RoundButton, language.GiveReceipt, CountOptionsGrid);
            InitializeButton(PutInRecord.RoundButton, language.PutInRecord, CountOptionsGrid);
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, CountOptionsGrid, this.Height, language.VirtualAssistant);
        }
        private void InitializeItsComponents()
        {
            Count = WindowHelper.SetBorder(this, this.Grid);
            CountOptionsGrid = WindowHelper.CalculateGridMaxCount(OptionsGrid);
            CountMedicalRecordGrid = WindowHelper.CalculateGridMaxCount(MedicalRecordGrid);
            ButtonContentHelper.SetStackPaneledButton(GoBack.GoBackButton.Content as StackPanel, GoBack.GoBackText, language.GoBack);
        }
        private void InitializeButton(RoundButtonControl control, string buttonContent, int count)
        {
            control.Height = control.Width = ((this.Height / count) * Shared.Config.Properties.Default.ButtonProportion);
            ButtonContentHelper.SetContent(control.RoundButton.Button, buttonContent);
        }

        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new PatientControl() { ReturnToWindow = this.ReturnToWindow });
        }

        public void ReturnToPreviousWindow()
        {
            WindowHelper.ReturnToPrevious(ReturnToWindow, this);
        }

        public void SetReturningWindow(Window window)
        {
            ReturnToWindow = window;
        }
    }
}
