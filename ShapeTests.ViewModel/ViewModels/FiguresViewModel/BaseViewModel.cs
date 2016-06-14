using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    public class BaseViewModel : ViewModel
    {
        protected string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetAndRaisePropertyChanged(ref _Name, value); }
        }

        private BaseFigure _Figure;
        public BaseFigure Figure
        {
            get
            {
                return _Figure;
            }
            set
            {
                SetAndUpdateTraingleIfChanged(value);
            }
        }

        private void SetAndUpdateTraingleIfChanged(IFigure newFigure)
        {
            if (!ReferenceEquals(_Figure, newFigure))
            {
                if (_Figure != null)
                {
                    // _Figure.EntityChanged -= OnEntityChanged;
                }

                _Figure = (BaseFigure)newFigure;

                if (_Figure != null)
                {
                    //  _Figure.EntityChanged += OnTriangleChanged;
                }

                UpdateViewModel();
            }
        }

        protected virtual void UpdateViewModel()
        {
        }
    }
}