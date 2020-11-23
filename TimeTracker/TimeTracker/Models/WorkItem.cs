﻿using System;

namespace TimeTracker.Models
{
    public class WorkItem
    {
        public WorkItem(DateTime start,DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Total
        {
            get => Start - End;
        }

    }
}