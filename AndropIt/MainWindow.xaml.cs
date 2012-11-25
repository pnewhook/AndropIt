using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Hardcodet.Wpf.TaskbarNotification;
using MahApps.Metro.Controls;

namespace AndropIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        IPushClient pc;
        Brush beginBrush;
        public MainWindow()
        {
            pc = new PushClient();
            InitializeComponent();
            SetPosition();
        }

        private void SetPosition()
        {
            Topmost = true;
            Left = SystemParameters.PrimaryScreenWidth - this.Width - 30;
            Top = SystemParameters.PrimaryScreenHeight - this.Height - 40;
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
                var tb = (TaskbarIcon)FindResource("ErrorIcon");
                tb.Visibility = System.Windows.Visibility.Visible;
                Thread.Sleep(10000);
                tb.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                var tb = (TaskbarIcon)FindResource("SuccessIcon");
                tb.Visibility = System.Windows.Visibility.Visible;
                Thread.Sleep(10000);
                tb.Visibility = System.Windows.Visibility.Collapsed;
            }
        }


        private void txtDragText_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pc.SendFile(files[0]);
            }
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string dropText = e.Data.GetData(DataFormats.Text) as string;
                string text = dropText.Trim();

                pc.SendText(text);
                LogOutput("Dropped " + dropText, true);
                return;
            }

        }

        private void Image_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false))
            {
                e.Effects = DragDropEffects.Copy;

            }
        }
    }
}