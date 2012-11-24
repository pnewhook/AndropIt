﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AndropIt.Core;

namespace AndropIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPushClient pc;
        public MainWindow()
        {
            pc = new PushClient();
            InitializeComponent();
        }

        private void btnClipboard_Click(object sender, RoutedEventArgs e)
        {
            string clipboardText;
            if (Clipboard.ContainsText())
            {
                clipboardText = Clipboard.GetText();
            }
            else
            {
                LogOutput("Clipboard doesn't contain text", false);
                return;
            }
            try 
                {
                    pc.SendText(clipboardText);
                    string successMessage = "Pushed " + clipboardText + " from clipboard";
                    LogOutput(successMessage, true);

                }
                catch (Exception)
                {
                    throw;
                }

        }
  
        private void LogOutput(string messageText, bool isSuccess)
        {
            if (isSuccess == false)
            {
                txtOutput.Foreground = Brushes.Red;
            }
            else
            {
                txtOutput.Foreground = Brushes.Black;
            }
            // TODO: Implement this method
            this.txtOutput.Text =  messageText;
        }

        private void btnContent_Click(object sender, RoutedEventArgs e)
        {
            if (txtContent.Text == string.Empty)
            {
                LogOutput("Enter a value in the textbox", false);
                return;
            }
            try
            {
                pc.SendText(txtContent.Text);
                string successMessage = "Pushed " + txtContent.Text + " from text field";
                LogOutput(successMessage, true);
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}