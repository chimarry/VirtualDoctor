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
using VirtualDoctor.Shared.Config;
using VirtualDoctor.Shared.Controls;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI
{
    /// <summary>
    /// Interaction logic for AccountAdminMainWindow.xaml
    /// </summary>
    public partial class AccountAdminMainWindow : Window, IRefreshable
    {
        private int Count { get; set; }
        public AccountAdminMainWindow()
        {
            InitializeComponent();
            InitializeItsComponents();
        }
        private void InitializeItsComponents()
        {
            Count = WindowHelper.SetBorder(this, this.Grid); ;
            InitializeButton(LocalAccount, language.Accounts);
            VirtualAssistantControl.InitializeAssistent(VirtualAssistant, Count, Height, language.VirtualAssistant);

        }
        private void InitializeButton(RoundButtonControl control, string buttonContent)
        {
            control.Height = control.Width = ((this.Height / Count) * Shared.Config.Properties.Default.ButtonProportion);
            ButtonContentHelper.SetContent(control.RoundButton.Button, buttonContent);
        }



        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new AccountAdminMainWindow() );
        }

        private void LocalAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.ShowWindow(this, new LocalAccountCRUD.Index() { ReturnToWindow = new AccountAdminMainWindow() });
        }
    }
}

