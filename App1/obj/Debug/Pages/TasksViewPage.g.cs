﻿

#pragma checksum "C:\Users\Davydov\documents\visual studio 2013\Projects\App1\App1\Pages\TasksViewPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "11FFEB0726CFDC7D5DB1F064CE445A78"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class TasksViewPage : global::App1.Pages.NavBar, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.TasksButtonClick;
                 #line default
                 #line hidden
                #line 13 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.TasksButtonTap;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.EventsButtonClick;
                 #line default
                 #line hidden
                #line 14 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.EventsButtonTap;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 15 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.CalendarButtonClick;
                 #line default
                 #line hidden
                #line 15 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.CalendarButtonTap;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 16 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SubjectsButtonClick;
                 #line default
                 #line hidden
                #line 16 "..\..\Pages\TasksViewPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.SubjectsButtonTap;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


