using System.ComponentModel;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class RectangleViewModel : BaseViewModel
    {
        private double _Length;
        public double Length
        {
            get { return _Length; }
            set { SetAndRaisePropertyChanged(ref _Length, value); }
        }

        private double _Width;
        public double Width
        {
            get { return _Width; }
            set { SetAndRaisePropertyChanged(ref _Width, value); }
        }

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
            if (changedArgs.PropertyName == nameof(Name))
            {
                Figure.Name = Name;
            }
            else if (changedArgs.PropertyName == nameof(_Width))
            {
                ((Rectangle)Figure).Width = Width;
            }
            else if (changedArgs.PropertyName == nameof(_Length))
            {
                ((Rectangle)Figure).Length = Length;
            }
        }

        protected override void UpdateViewModel()
        {
            Name = Figure.Name;
            Length = ((Rectangle)Figure).Length;
            Width = ((Rectangle)Figure).Width;
        }
    }
}