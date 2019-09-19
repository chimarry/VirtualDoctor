﻿#pragma checksum "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD339AA855161692699C193821E690BAEFA22898"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace VirtualDoctor.Shared.Controls.DataGridControls {
    
    
    /// <summary>
    /// DataGridControl
    /// </summary>
    public partial class DataGridControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanel;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DataGridTitle;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Backwards;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button First;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PageInfo;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Last;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Forward;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VirtualDoctor;component/shared/controls/datagridcontrols/datagridcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.StackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.DataGridTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Backwards = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            this.Backwards.Click += new System.Windows.RoutedEventHandler(this.Backwards_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.First = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            this.First.Click += new System.Windows.RoutedEventHandler(this.First_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PageInfo = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Last = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            this.Last.Click += new System.Windows.RoutedEventHandler(this.Last_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Forward = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            this.Forward.Click += new System.Windows.RoutedEventHandler(this.Forward_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 100 "..\..\..\..\..\Shared\Controls\DataGridControls\DataGridControl.xaml"
            this.DataGrid.AutoGeneratedColumns += new System.EventHandler(this.DataGrid_AutoGeneratedColumns);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

