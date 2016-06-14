using System;
using System.ComponentModel;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class TriangleViewModel : BaseViewModel
    {
        private double _Base;
        private double _Height;

 
        public double Base
        {
            get { return _Base; }
            set { SetAndRaisePropertyChanged(ref _Base, value); }
        }

        public double Height
        {
            get { return _Height; }
            set { SetAndRaisePropertyChanged(ref _Height, value); }
        }



        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Figure.Name = Name;
            }
            else if (changedArgs.PropertyName == nameof(Base))
            {
                ((Triangle)Figure).Base = Base;
            }
            else if (changedArgs.PropertyName == nameof(Height))
            {
                //Triangle.Height = Height;
                ((Triangle)Figure).Height = Height;
            }
        }



        //private void OnTriangleChanged(object sender, EventArgs args)
        //{
        //    UpdateViewModel();
        //}

        protected override void UpdateViewModel()
        {
            Name = Figure.Name;
            Base = ((Triangle)Figure).Base;
            Height = ((Triangle)Figure).Height;
        }
    }
}

