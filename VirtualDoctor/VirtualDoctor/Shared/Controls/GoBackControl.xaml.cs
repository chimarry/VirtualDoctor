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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.Shared.Controls
{
    /// <summary>
    /// Interaction logic for GoBackControl.xaml
    /// </summary>
    public partial class GoBackControl : UserControl
    {

        public GoBackControl()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            IWindowReturnable toReturn = Window.GetWindow(this) as IWindowReturnable;
            toReturn.ReturnToPreviousWindow();
        }
    }
}
