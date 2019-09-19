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

namespace VirtualDoctor.Shared.Controls
{
    /// <summary>
    /// Interaction logic for VirtualAssistantControl.xaml
    /// </summary>
    public partial class VirtualAssistantControl : UserControl
    {
        public VirtualAssistantControl()
        {
            InitializeComponent();
        }
        public static void InitializeAssistent(VirtualAssistantControl control,int count,double height,string name) 
        {
            control.AssistantContainter.Height = control.AssistantContainter.Width = (height / count) * Shared.Config.Properties.Default.ButtonProportion;
            control.AssistantBorder.Height = control.AssistantContainter.Height * Config.Properties.Default.ButtonProportion;
            control.AssistantLink.FontFamily = Config.Properties.Default.FontFamily;
            control.AssistantLink.FontSize = Config.Properties.Default.ButtonFontSize;
            control.AssistantLink.Inlines.Clear();
            control.AssistantLink.Inlines.Add(name);
        }
    }
}
