﻿

#pragma checksum "C:\Users\Davydov\documents\visual studio 2013\Projects\App1\App2\App2.Shared\Pages\SubjectsAddPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B70724996057F3D25F7EE6421D786770"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App2.Pages
{
    partial class SubjectsAddPage : global::App2.Pages.NavBar, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 11 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.TasksButtonClick;
                 #line default
                 #line hidden
                #line 11 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.TasksButtonTap;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 12 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.EventsButtonClick;
                 #line default
                 #line hidden
                #line 12 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.EventsButtonTap;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 13 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.LecturersButtonClick;
                 #line default
                 #line hidden
                #line 13 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.LecturersButtonTap;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 14 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SubjectsButtonClick;
                 #line default
                 #line hidden
                #line 14 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.SubjectsButtonTap;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 15 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.NameTextBoxGotFocus;
                 #line default
                 #line hidden
                #line 15 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.NameTextBoxLostFocus;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 16 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.DescriptionTextBoxGotFocus;
                 #line default
                 #line hidden
                #line 16 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.DescriptionTextBoxLostFocus;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 18 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.AddButtonTap;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 19 "..\..\..\Pages\SubjectsAddPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.CancelButtonTap;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


