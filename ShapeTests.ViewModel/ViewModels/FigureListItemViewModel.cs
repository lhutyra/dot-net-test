using System;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    public class FigureListItemViewModel : ViewModel
    {
        private string _FigureName;
        private FigureBaseEntity _Figure;

        public string FigureName
        {
            get { return _FigureName; }
            set { SetAndRaisePropertyChanged(ref _FigureName, value); }
        }

        public FigureBaseEntity Figure
        {
            get { return _Figure; }
            set { SetAndUpdateTriangleIfChanged(value); }
        }

        private void UpdateViewModel()
        {
            FigureName = _Figure.Name;
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