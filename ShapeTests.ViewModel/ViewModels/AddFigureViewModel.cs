using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    public class AddFigureViewModel : ViewModel
    {
        private readonly IFiguresRepository _FiguresRepo;

        private int _OwnerId;

        private MvxCommand _AddTriangleCommand;
        private MvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

        public int OwnerId
        {
            get { return _OwnerId; }
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        public MvxCommand AddTriangleCommand
        {
            get { return _AddTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _AddTriangleCommand, value); }
        }

        public MvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value); }
        }


        public AddFigureViewModel(IFiguresRepository figuresRepo)
        {
            _FiguresRepo = figuresRepo;
            AddTriangleCommand = new MvxCommand(AddFigure);
            CancelCommand = new MvxCommand(Cancel);
        }

        public void AddFigure()
        {
            FigureBaseEntity triangle = new Triangle
            {
                Name = "New IFigure"
            };

            _FiguresRepo.AddFigure(triangle);
            Close(this);
        }

        public void Cancel()
        {
            Close(this);
        }
    }
}