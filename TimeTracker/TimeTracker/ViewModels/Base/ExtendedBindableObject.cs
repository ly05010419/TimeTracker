﻿﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class ExtendedBindableObject:BindableObject
    {
        
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {

            if (EqualityComparer<T>.Default.Equals(storage,value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}