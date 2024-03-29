﻿using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.Shared.Interfaces;

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalRecordCRUD
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window, IWindowReturnable, IRefreshable
    {
        public Window ReturnToWindow { get; set; }

        public Index()
        {
            InitializeComponent();
            WindowHelper.SetBorder(this, Grid);
            IndexControl control = new IndexControl(new IndexControlElementMedicalRecord(), new DataGridControlElementMedicalRecord());
            control.SetBorder(Height, Width);
            Grid.Children.Add(control);
        }
        public void Refresh()
        {
            WindowHelper.ShowWindow(this, new Index() { ReturnToWindow = this.ReturnToWindow });
        }

        public void ReturnToPreviousWindow()
        {
            WindowHelper.ShowWindow(this, ReturnToWindow);
        }

        public void SetReturningWindow(Window window)
        {
            ReturnToWindow = window;
        }
    }
}
