using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VirtualDoctor.Shared.Helpers
{
    public static class LabelResizer
    {
        public static void SetLabelContent(Label label, string text)
        {
            label.Content = text;
        }
        public static void ResizeLabel(Label label, double height, double width)
        {
            label.Width = width;
            label.Height = height;
            
        }
    }
}
