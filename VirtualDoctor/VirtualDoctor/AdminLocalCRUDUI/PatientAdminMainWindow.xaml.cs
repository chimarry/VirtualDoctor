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
using VirtualDoctor.Shared.Controls;
using VirtualDoctor.Shared.Helpers;

namespace VirtualDoctor.AdminLocalCRUDUI
{
    /// <summary>
    /// Interaction logic for PatientAdminMainWindow.xaml
    /// </summary>
    public partial class PatientAdminMainWindow : Window
    {
        private int Count { get; set; }
        public PatientAdminMainWindow()
        {
            InitializeComponent();
            InitializeItsComponents();
        }
        private void InitializeItsComponents()
        {
            Count = WindowHelper.SetBorder(this, this.Grid);

            InitializeButton(MedicalRecord, language.MedicalRecordsReview);
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, Count, Height, language.VirtualAssistant);

        }
        private void InitializeButton(RoundButtonControl control, string buttonContent)
        {
            control.Height = control.Width = ((this.Height / Count) * Shared.Config.Properties.Default.ButtonProportion);
            ButtonContentHelper.SetContent(control.RoundButton.Button, buttonContent);
        }


        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new PatientAdminMainWindow());
        }

        private void MedicalRecord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new MedicalRecordCRUD.Index() { ReturnToWindow = new PatientAdminMainWindow() });
        }
    }
}
