﻿// Copyright © Omron Robotics and Safety Technologies, Inc. All rights reserved.
//

using Ace.OperatorInterface.ViewModel;
using System;
using System.Windows.Controls;

namespace Ace.OperatorInterface.View
{
    /// <summary>
    /// Interaction logic for OperatorInterface.xaml
    /// </summary>
    public partial class OperatorInterfaceView : UserControl, IOperatorInterfaceView
    {
        private IOperatorInterfaceViewModel OperatorInterfaceVM
        {
            get
            {
                return this.DataContext as IOperatorInterfaceViewModel;
            }
        }

        public OperatorInterfaceView()
        {
            InitializeComponent();
            this.DataContextChanged += OperatorInterfaceView_DataContextChanged;
        }

        private void OperatorInterfaceView_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            this.OperatorInterfaceVM.UpdateControllerCollection();

            // Get the DataContext for this XAML-UserControl.
            // Assign the OnViewModel_ReportError() method below to the Action<string> ReportError delegate of the ViewModel base class
            ((OperatorInterfaceViewModel)DataContext).ControllerItems.ReportError = OnViewModel_ReportError;
        }

        // Popup a MessageBox in case of an error thrown in the ViewModel classes.
        private void OnViewModel_ReportError(string obj)
        {
            System.Windows.MessageBox.Show(obj.ToString());
        }
    }
}

