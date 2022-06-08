﻿using PropertyChanged;
using System.ComponentModel;

namespace TreeView
{
    //FodyPropertyChanged Should be Used when we are using PropertyChanged.

    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };
    }
}