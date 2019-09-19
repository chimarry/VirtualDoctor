﻿#pragma checksum "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7CB303451F3FC46CDFEA0D3D8676752C48186112"
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
using VirtualDoctor.Shared.Controls;


namespace VirtualDoctor.Shared.Controls {
    
    
    /// <summary>
    /// ConfirmDeleteControl
    /// </summary>
    public partial class ConfirmDeleteControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label QuestionLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ButtonsGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YesButton;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoButton;
        
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
            System.Uri resourceLocater = new System.Uri("/VirtualDoctor;component/shared/controls/confirmdeletecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
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
            this.QuestionLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ButtonsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.YesButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
            this.YesButton.Click += new System.Windows.RoutedEventHandler(this.ButtonOne_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NoButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Shared\Controls\ConfirmDeleteControl.xaml"
            this.NoButton.Click += new System.Windows.RoutedEventHandler(this.ButtonTwo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

