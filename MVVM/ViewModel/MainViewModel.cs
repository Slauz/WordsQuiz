﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordsQuizWPF.Core;

namespace WordsQuizWPF.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; private set; }

        private BaseViewModel currentView;
        public BaseViewModel CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value; 
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            CurrentView = new MenuViewModel(); 
        }
    }
}
