using System;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.LocalDoctorUI
{
    /// <summary>
    /// Interaction logic for DoctorsReview.xaml
    /// </summary>
    public partial class DoctorsReview : Window, IRefreshable, IWindowReturnable
    {
        public Window ReturnToWindow { get; set; }
        public DoctorsReview()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, this.Grid);
            IndexControl control = new IndexControl(new IndexControlElementDoctor(), new DataGridControlElementDoctor(), detailsBtnVisibility: Visibility.Visible, crudBtnVisibility: Visibility.Hidden);
            control.SetBorder(Height, Width);
            Grid.Children.Add(control);
        }



        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new DoctorsReview() { ReturnToWindow = this.ReturnToWindow });
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
