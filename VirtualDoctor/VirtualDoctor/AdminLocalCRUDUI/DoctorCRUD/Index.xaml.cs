using System;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : IRefreshable, IWindowReturnable
    {
        public Window ReturnToWindow { get; set; }

        public Index()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, Grid);
            IndexControl control = new IndexControl(new IndexControlElementDoctor(), new DataGridControlElementDoctor(), detailsBtnVisibility: Visibility.Visible);
            control.SetBorder(Height, Width);
            Grid.Children.Add(control);
        }
        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new Index() { ReturnToWindow = this.ReturnToWindow });
        }

        public void ReturnToPreviousWindow()
        {
            ReturnToWindow = Activator.CreateInstance(ReturnToWindow.GetType()) as Window;

            WindowHelper.ShowWindow(this, ReturnToWindow);
        }

        public void SetReturningWindow(Window window)
        {
            ReturnToWindow = window;
        }
    }
}
