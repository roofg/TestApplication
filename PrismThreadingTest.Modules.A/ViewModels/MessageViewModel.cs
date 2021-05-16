using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismThreadingTest.Core;
using System.Windows;
using System.Windows.Threading;

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

        private string _message2 = "Not set.";
        public string Message2
        {
            get { return _message2; }
            set { SetProperty(ref _message2, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }
        public DelegateCommand TriggerAsyncUpdateCommand { get; private set; }
        public DelegateCommand DispatchedCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
            TriggerAsyncUpdateCommand = new DelegateCommand(TriggerAsyncUpdate);
            DispatchedCommand = new DelegateCommand(DispatchedUpdate);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }

        private int counter=0;
        //private void TriggerAsyncUpdate()
        //{
        //    counter++;

        //    System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}. Before splitting worker thread from Mainthread.");

        //    Task taskA = Task.Run(() =>
        //    {
        //        System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}.");

        //        // Set Binding in viewmodel from seperate thread.
        //        Message2 = $"Async update counter: {counter}.";
        //    });

        //    Task.WaitAll(taskA);
        //    System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}. Worker finished from Mainthread.");
        //}

        private void TriggerAsyncUpdate()
        {
            counter++;

            System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}. Before splitting worker thread from Mainthread.");

            Task taskA = Task.Run(() =>
            {
                System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}. Triggering gui update.");

                // Set Binding in viewmodel from seperate thread.

                //string transportString = new string("Testing");
                //Application.Current.Dispatcher.BeginInvoke(DispatchedCommand);
                Message2 = $"Async update counter: {counter}.";
            });

            Task.WaitAll(taskA);
            System.Diagnostics.Debug.WriteLine($"ThreadId {Thread.CurrentThread.ManagedThreadId}. Worker finished from Mainthread.");
        }

        private void DispatchedUpdate()
        {
            Message2 = "Dispatcherupdate";
        }
    }
}
