using System.ComponentModel;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class SquareViewModel : BaseViewModel
    {

        private double _SideLength;
       
        public double SideLength
        {
            get { return _SideLength; }
            set { SetAndRaisePropertyChanged(ref _SideLength, value); }
        }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Figure.Name = Name;
            }

            else if (changedArgs.PropertyName == nameof(_SideLength))
            {
                ((Square)Figure).SideLength = SideLength;
            }
        }
       
        protected override void UpdateViewModel()
        {
            Name = Figure.Name;
            SideLength = ((Square)Figure).SideLength;
        }
    }
}
