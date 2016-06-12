using System;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    public class ErrorDialogViewModel : ViewModel
    {
        private int _OwnerId;
        
        private MvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

        public int OwnerId
        {
            get { return _OwnerId; }
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }      

        public MvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value); }
        }


        public ErrorDialogViewModel()
        {                  
            CancelCommand = new MvxCommand(Cancel);
        }
       
        public void Cancel()
        {
            Close(this);
        }
    }
}