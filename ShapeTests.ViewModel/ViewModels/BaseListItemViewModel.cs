using System;
using ShapeTest.Business.Entities;

namespace ShapeTests.ViewModel.ViewModels
{
    public class BaseListItemViewModel : ViewModel
    {
        private string _FigureName;
        protected BaseFigure _Figure;

        public string FigureName
        {
            get { return _FigureName; }
            set { SetAndRaisePropertyChanged(ref _FigureName, value); }
        }

        public BaseFigure Figure
        {
            get { return _Figure; }
            set { SetAndUpdateTriangleIfChanged(value); }
        }

        private void UpdateViewModel()
        {
            FigureName = _Figure.Name;
        }

        private void SetAndUpdateTriangleIfChanged(BaseFigure newFigure)
        {

            if (!ReferenceEquals(_Figure, newFigure))
            {
                if (_Figure != null)
                {
                    _Figure.EntityChanged -= OnFigureChanged;
                }

                _Figure = newFigure;

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
