using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismThreadingTest.Core;

namespace PrismThreadingTest.Modules.B.ViewModels
{
    class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages 
        { 
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator ea)
        {
            ea.GetEvent<MessageSentEvent>().Subscribe(MessageRecieved);
        }

        private void MessageRecieved(string parameter)
        {
            Messages.Add(parameter);
        }

    }
}
