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
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI
{
    /// <summary>
    /// Interaction logic for OrganizationalAdminMainWindow.xaml
    /// </summary>
    public partial class OrganizationalAdminMainWindow : Window, IRefreshable
    {
        private int Count { get; set; }
        public OrganizationalAdminMainWindow()
        {
            InitializeComponent();
            InitializeItsComponents();
        }
        private void InitializeItsComponents()
        {
            Count = WindowHelper.SetBorder(this, this.Grid);
            InitializeButton(Role, language.Roles);
            InitializeButton(MedicalTitle, language.MedicalTitles);
            InitializeButton(Clinic, language.Clinics);
            InitializeButton(Place, language.Places);
            InitializeButton(Doctor, language.Doctors);
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, Count, Height, language.VirtualAssistant);

        }
        private void InitializeButton(RoundButtonControl control, string buttonContent)
        {
            control.Height = control.Width = ((this.Height / Count) * Shared.Config.Properties.Default.ButtonProportion);
            ButtonContentHelper.SetContent(control.RoundButton.Button, buttonContent);
        }

        private void Role_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            WindowHelper.ShowWindow(this, new RoleCRUD.Index() { ReturnToWindow = new OrganizationalAdminMainWindow() });

        }

        private void Clinic_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new ClinicCRUD.Index() { ReturnToWindow = new OrganizationalAdminMainWindow() });

        }

        private void Place_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new PlaceCRUD.Index() { ReturnToWindow = new OrganizationalAdminMainWindow() });

        }

        private void MedicalTitle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new MedicalTitleCRUD.Index() { ReturnToWindow = new OrganizationalAdminMainWindow() });
        }

        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new OrganizationalAdminMainWindow() );
        }

        private void Doctor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new DoctorCRUD.Index() { ReturnToWindow = new OrganizationalAdminMainWindow() });
        }
    }
}
