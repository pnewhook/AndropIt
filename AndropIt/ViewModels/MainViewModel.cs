using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndropIt.Core;
using Caliburn.Micro;

namespace AndropIt.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private string writtenText;

        public string WrittenText
        {
            get { return writtenText; }
            set 
            {
                writtenText = value;
                NotifyOfPropertyChange(()=>WrittenText);
                NotifyOfPropertyChange(() => CanSendWrittenText);
            }
        }
        public bool CanSendWrittenText
        {
            get { return !string.IsNullOrWhiteSpace(WrittenText); }
        }

        public void SendWrittenText()
        {
            PushClient pc = new PushClient();
            pc.SendText(WrittenText);

        }
        
    }
}
