﻿#pragma checksum "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8566BB53FF6A3DA6BD9E6FE1FE077479709DEF9F9A051098B719DDFE3EF951E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using stickets.Windows.Cassier.Timetable;


namespace stickets.Windows.Cassier.Timetable {
    
    
    /// <summary>
    /// View
    /// </summary>
    public partial class View : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FiltrationBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Asc;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Desc;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel TimetableBox;
        
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
            System.Uri resourceLocater = new System.Uri("/stickets;component/windows/cassier/timetable/view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
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
            
            #line 8 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
            ((stickets.Windows.Cassier.Timetable.View)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
            this.SearchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FiltrationBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 20 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
            this.FiltrationBox.DropDownClosed += new System.EventHandler(this.FiltrationBox_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Asc = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
            this.Asc.Checked += new System.Windows.RoutedEventHandler(this.Asc_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Desc = ((System.Windows.Controls.RadioButton)(target));
            
            #line 26 "..\..\..\..\..\Windows\Cassier\Timetable\View.xaml"
            this.Desc.Checked += new System.Windows.RoutedEventHandler(this.Desc_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TimetableBox = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
