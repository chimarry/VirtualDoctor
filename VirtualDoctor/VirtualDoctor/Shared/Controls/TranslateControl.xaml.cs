using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.Shared.Controls
{
    /// <summary>
    /// Interaction logic for TranslateControl.xaml
    /// </summary>
    public partial class TranslateControl : UserControl
    {
        private static readonly string SERBIAN_LANGUAGE = "sr-SR";
        private static readonly string ENGLISH_LANGUAGE = "en-EN";
        private static readonly string SWITCH_TO_SERBIAN = "Switch to Serbian";
        private static readonly string SWITCH_TO_ENGLISH = "Prevedi na engleski";
        public TranslateControl()
        {
            InitializeComponent();
            ButtonText.Text = Config.Properties.Default.TranslateText;
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Config.Properties.Default.Language == SERBIAN_LANGUAGE)
            {
                Config.Properties.Default.Language = ENGLISH_LANGUAGE;
             
                Config.Properties.Default.TranslateText = SWITCH_TO_SERBIAN;

            }
            else
            {
                Config.Properties.Default.Language = SERBIAN_LANGUAGE;
                Config.Properties.Default.TranslateText = SWITCH_TO_ENGLISH;
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Config.Properties.Default.Language);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Config.Properties.Default.Language);
            WindowHelper.Refresh(Window.GetWindow(this) as IRefreshable);
        }
    }
}
