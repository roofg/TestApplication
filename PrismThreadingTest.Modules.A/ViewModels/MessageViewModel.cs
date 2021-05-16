using System;
using System.Collections.Generic;
using System.Text;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismThreadingTest.Core;

namespace PrismThreadingTest.Modules.A.ViewModels
{
    class MessageViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;

        private string _message = "Message to send.";
        public string Message 
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
