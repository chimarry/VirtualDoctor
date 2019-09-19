using System.Windows;
using VirtualDoctor.AdminLocalCRUDUI.MedicalRecordCRUD;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.LocalDoctorUI
{
    /// <summary>
    /// Interaction logic for MedicalRecordsReview.xaml
    /// </summary>
    public partial class MedicalRecordsReview : Window, IRefreshable, IWindowReturnable
    {
        public Window ReturnToWindow { get; set; }
        public MedicalRecordsReview()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, this.Grid);
            IndexControl control = new IndexControl(new IndexControlElementMedicalRecord(), new DataGridControlElementMedicalRecord(), crudBtnVisibility: Visibility.Hidden);
            control.SetBorder(Height, Width);
            Grid.Children.Add(control);
        }



        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new MedicalRecordsReview() { ReturnToWindow = this.ReturnToWindow });
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
