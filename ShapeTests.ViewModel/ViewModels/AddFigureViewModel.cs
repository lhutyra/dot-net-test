using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;

namespace ShapeTests.ViewModel.ViewModels
{
    using ShapeTest.Business.Entities;
    using ShapeTest.Business.Repositories;

    public class AddFigureViewModel : ViewModel, IPopupViewModel
    {
        private readonly IFiguresRepository _FiguresRepo;
        private readonly IFiguresTypesRepository _FiguresTypeRepo;
        private FigureTypeViewItem _selectedFigureTypeContentViewModel;
        private ObservableCollection<FigureTypeViewItem> _ListOfFiguresTypes;
        private int _OwnerId;

        private MvxCommand _AddFigureCommand;
        private MvxCommand _CancelCommand;

        public bool IsModal => true;

        public bool TopMost => true;

        public int OwnerId
        {
            get { return _OwnerId; }
            set { SetAndRaisePropertyChanged(ref _OwnerId, value); }
        }

        public MvxCommand AddFigureCommand
        {
            get { return _AddFigureCommand; }
            set { SetAndRaisePropertyChanged(ref _AddFigureCommand, value); }
        }

        public MvxCommand CancelCommand
        {
            get { return _CancelCommand; }
            set { SetAndRaisePropertyChanged(ref _CancelCommand, value); }
        }


        public AddFigureViewModel(IFiguresRepository figuresRepo, IFiguresTypesRepository figuresTypes)
        {
            _FiguresRepo = figuresRepo;
            _FiguresTypeRepo = figuresTypes;
            _ListOfFiguresTypes = CreateListViewModelsFromTypeList(_FiguresTypeRepo.GetList());
            AddFigureCommand = new MvxCommand(AddFigure);
            CancelCommand = new MvxCommand(Cancel);
            _selectedFigureTypeContentViewModel = _ListOfFiguresTypes.FirstOrDefault();
        }

        public void AddFigure()
        {
            IFigure figure = null;
            var selectedFigureType = _selectedFigureTypeContentViewModel.FigureName;
            if (selectedFigureType == "Square")
            {
                figure = new ShapeTest.Business.Entities.Square() { Name = "New Square" };
            }
            else if (_selectedFigureTypeContentViewModel.FigureName == "Triangle")
            {
                figure = new Triangle
                {
                    Name = "New Triangle"
                };
            }
            else if (_selectedFigureTypeContentViewModel.FigureName == "Circle")
            {
                figure = new Circle()
                {
                    Name = "New Circle"
                };
            }

            else if (_selectedFigureTypeContentViewModel.FigureName == "Rectangle")
            {
                figure = new Rectangle()
                {
                    Name = "New Rectangle"
                };
            }

            _FiguresRepo.AddFigure(figure);
            Close(this);
        }

        public ObservableCollection<FigureTypeViewItem> ListOfFiguresTypes
        {
            get
            {
                return _ListOfFiguresTypes;
            }
            set { SetAndRaisePropertyChanged(ref _ListOfFiguresTypes, value); }
        }

        public void Cancel()
        {
            Close(this);
        }

        private ObservableCollection<FigureTypeViewItem> CreateListViewModelsFromTypeList(List<FigureType> figuresTypes)
        {
            ObservableCollection<FigureTypeViewItem> viewModels = new ObservableCollection<FigureTypeViewItem>();
            foreach (var figureType in figuresTypes)
            {
                FigureTypeViewItem viewModel = new FigureTypeViewItem() { FigureName = figureType.FigureName };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public FigureTypeViewItem SelectedFigureTypeContentViewModel
        {
            get { return _selectedFigureTypeContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _selectedFigureTypeContentViewModel, value); }
        }
    }
}
