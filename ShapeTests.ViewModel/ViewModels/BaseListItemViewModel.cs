using System;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    public class BaseListItemViewModel : ViewModel
    {
        private string _Name;
        private FigureBaseEntity _Figure;

        public string Name
        {
            get { return _Name; }
            set { SetAndRaisePropertyChanged(ref _Name, value); }
        }

        public FigureBaseEntity Figure
        {
            get { return _Figure; }
            set { SetAndUpdateTriangleIfChanged(value); }
        }

        private void UpdateViewModel()
        {
            _Name = _Figure.Name;
        }

        private void SetAndUpdateTriangleIfChanged(FigureBaseEntity newTriangle)
        {
            if (!ReferenceEquals(_Figure, newTriangle))
            {
                if (_Figure != null)
                {
                    _Figure.EntityChanged -= OnFigureChanged;
                }

                _Figure = newTriangle;

                if (_Figure != null)
                {
                    _Figure.EntityChanged += OnFigureChanged;
                }

                UpdateViewModel();
            }
        }

        private void OnFigureChanged(object sender, EventArgs args)
        {
            UpdateViewModel();
        }
    }
}
