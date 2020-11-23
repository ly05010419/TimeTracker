﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TimeTracker.Annotations;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class ViewModelBase:ExtendedBindableObject
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

         bool _isLoading;

         public bool IsLoading
         {
             get => _isLoading;
             set => SetProperty(ref _isLoading, value);
         }

         public virtual Task InitializeAsync(object navigationDate = null)
         {
             return Task.CompletedTask;
         }
    }
}