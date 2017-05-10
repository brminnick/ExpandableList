// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StoryboardTable
{
    [Register ("MasterViewController")]
    partial class MasterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MasterView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MasterView != null) {
                MasterView.Dispose ();
                MasterView = null;
            }
        }
    }
}