using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VirtualDoctor.Shared.Helpers
{
    public static class LabelHelper
    {
        public static void SetLabelContent(Label label, string text)
        {
            label.Content = text;
            label.FontWeight = FontWeights.Bold;
            label.FontSize = Config.Properties.Default.LabelFontSize;
            label.FontFamily = Config.Properties.Default.FontFamily;
            label.Foreground = new SolidColorBrush(Config.Properties.Default.FontColor);
        }
    }
}
