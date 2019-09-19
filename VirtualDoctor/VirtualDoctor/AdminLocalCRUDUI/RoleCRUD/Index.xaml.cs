using System;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window, IRefreshable, IWindowReturnable
    {
        public Window ReturnToWindow { get; set; }

        public Index()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, Grid);
            IndexControl control = new IndexControl(new IndexControlElementRoles(), new DataGridControlElementRoles());
            control.SetBorder(Height, Width);
            Grid.Children.Add(control);
        }
        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new Index() { ReturnToWindow = this.ReturnToWindow });
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
