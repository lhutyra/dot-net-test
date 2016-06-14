using System.ComponentModel;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class CircleViewModel : BaseViewModel
    {
        private double _Radius;

        public double Radius
        {
            get { return _Radius; }
            set { SetAndRaisePropertyChanged(ref _Radius, value); }
        }
        
        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Figure.Name = Name;
            }
            else if (changedArgs.PropertyName == nameof(Radius))
            {
                ((Circle)Figure).Radius = Radius;
            }
        }

        protected override void UpdateViewModel()
        {
            Name = Figure.Name;
            Radius = ((Circle)Figure).Radius;
        }
    }
}