﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TimeTracker.ViewModels.Button
{
    public class ButtonModel:ExtendedBindableObject
    {
        
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text,value);
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible,value);
        }

        private bool _isEnable;

        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isVisible,value);
        }

        private ICommand _command;

        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command,value);
        }

        public ButtonModel(string title,ICommand command,bool isVisible = true,bool isEnable = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnable = isEnable;
        }
        
        
        public ButtonModel(string title,Action action,bool isVisible = true,bool isEnable = true)
        {
            Text = title;
            Command = new Command(action);
            IsVisible = isVisible;
            IsEnable = isEnable;
        }

    }
}