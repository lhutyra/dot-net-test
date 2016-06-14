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
    }
}