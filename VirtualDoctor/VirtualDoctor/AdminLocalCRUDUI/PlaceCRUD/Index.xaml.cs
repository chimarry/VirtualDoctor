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
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI.PlaceCRUD
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
            IndexControl control = new IndexControl(new IndexControlElementPlace(), new DataGridControlElementPlace());
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
