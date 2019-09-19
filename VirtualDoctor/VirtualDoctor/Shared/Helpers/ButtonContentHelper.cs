using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VirtualDoctor.Shared.Helpers
{
    public static class ButtonContentHelper
    {
        public static void SetContent(Button button, string text)
        {
            button.Content = new TextBlock()
            {
                Text = text,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                FontWeight = FontWeights.Bold,
                FontFamily = Config.Properties.Default.FontFamily,
                FontSize = Config.Properties.Default.ButtonFontSize,
                TextAlignment = TextAlignment.Center,
                Foreground = new SolidColorBrush(Shared.Config.Properties.Default.FontColor)
            };
        }
        public static void SetStackPaneledButton(StackPanel buttonsStackPanel, TextBlock textBlock, string text)
        {
            buttonsStackPanel.Children.Remove(textBlock);
            buttonsStackPanel.Children.Add(new TextBlock()

            {
                Text = text,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Bold,
                FontFamily = Shared.Config.Properties.Default.FontFamily,
                FontSize = Shared.Config.Properties.Default.ButtonFontSize,
                TextAlignment = TextAlignment.Center,
                Foreground = new SolidColorBrush(Shared.Config.Properties.Default.FontColor)

            });
        }

    }
}
