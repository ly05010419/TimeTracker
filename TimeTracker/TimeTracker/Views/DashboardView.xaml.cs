﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardView : TabbedPage
    {
        public DashboardView()
        {
            InitializeComponent();
        }
    }
}