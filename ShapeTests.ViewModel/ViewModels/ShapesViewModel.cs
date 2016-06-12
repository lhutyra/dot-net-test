using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ShapeTest.Business.Entities;
using ShapeTest.Business.Repositories;
using ShapeTest.Business.Services;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTests.ViewModel
{
    public class ShapesViewModel : ViewModel
    {
        private readonly IFiguresRepository _FiguresesRepo;
        private readonly IFiguresTypesRepository _FiguresesTypeRepo;
        private readonly IComputeAreaService _ComputeAreaService;
        private readonly ISubmissionService _SubmissionService;
        

        private ObservableCollection<BaseListItemViewModel> _FigureListItems;
        private ObservableCollection<FigureTypeViewItem> _ListOfFiguresTypes;

        private BaseListItemViewModel _selectedFigureListItemViewModel;

        private FigureTypeViewItem _selectedFigureTypeContentViewModel;



        private BaseListItemViewModel _selectedFigureContentViewModel;

        private double _TotalArea;

        private MvxCommand _AddFigureCommand;
        private MvxCommand _RemoveTriangleCommand;
        private MvxCommand _ComputeAreaCommand;
        private MvxCommand _SubmitAreaCommand;

        public ShapesViewModel(IFiguresRepository figureListRepository,
                               IComputeAreaService computeAreaService,
                               ISubmissionService submissionService,IFiguresTypesRepository figuresRepository)
        {
            _FiguresesRepo = figureListRepository;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;
            _FiguresesTypeRepo = figuresRepository;
            _FigureListItems = new ObservableCollection<BaseListItemViewModel>();

            _AddFigureCommand = new MvxCommand(AddFigure);
            RemoveTriangleCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

         
        public ObservableCollection<FigureTypeViewItem> ListOfFiguresTypes
        {
            get
            {                
                return _ListOfFiguresTypes;
            }
            set { SetAndRaisePropertyChanged(ref _ListOfFiguresTypes, value); }
        }

        public ObservableCollection<BaseListItemViewModel> FigureListItems
        {
            get { return _FigureListItems; }
            set { SetAndRaisePropertyChanged(ref _FigureListItems, value); }
        }

        public BaseListItemViewModel SelectedFigureListItemViewModel
        {
            get { return _selectedFigureListItemViewModel; }
            set { SetAndRaisePropertyChanged(ref _selectedFigureListItemViewModel, value); }
        }

        public FigureTypeViewItem SelectedFigureTypeContentViewModel
        {
            get { return _selectedFigureTypeContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _selectedFigureTypeContentViewModel, value); }
        }        

        public BaseListItemViewModel SelectedFigureContentViewModel
        {
            get { return _selectedFigureContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _selectedFigureContentViewModel, value); }
        }

        public double TotalArea
        {
            get { return _TotalArea; }
            set { SetAndRaisePropertyChanged(ref _TotalArea, value); }
        }

        public MvxCommand AddTriangleCommand
        {
            get { return _AddFigureCommand; }
            set { SetAndRaisePropertyChanged(ref _AddFigureCommand, value); }
        }

        public MvxCommand RemoveTriangleCommand
        {
            get { return _RemoveTriangleCommand; }
            set { SetAndRaisePropertyChanged(ref _RemoveTriangleCommand, value); }
        }

        public MvxCommand ComputeAreaCommand
        {
            get { return _ComputeAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _ComputeAreaCommand, value); }
        }

        public MvxCommand SubmitAreaCommand
        {
            get { return _SubmitAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _SubmitAreaCommand, value); }
        }

        public MvxCommand IsButtonEnabled
        {
            get { return _SubmitAreaCommand; }
            set { SetAndRaisePropertyChanged(ref _SubmitAreaCommand, value); }
        }



        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);

            if (changedArgs.PropertyName == nameof(SelectedFigureListItemViewModel))
            {
                UpdateTriangleContent();
            }
        }

        public override void Start()
        {
            List<FigureBaseEntity> figures = _FiguresesRepo.GetFigures();
            List<FigureType> figuresType = _FiguresesTypeRepo.GetList();
            FigureListItems = CreateListViewModelsFromFigureList(figures);
            ListOfFiguresTypes = CreateListViewModelsFromFigureTypeList(figuresType);
            SelectedFigureListItemViewModel = FigureListItems.FirstOrDefault();
            SelectedFigureTypeContentViewModel = ListOfFiguresTypes.FirstOrDefault();
            _FiguresesRepo.FigureAdded += OnFigureAdded;
        }

        public void AddFigure()
        {
            ShowViewModel<AddTriangleViewModel>();
        }

        public void OnFigureAdded(object sender, FiguresEventArgs args)
        {
            BaseListItemViewModel viewModel = new BaseListItemViewModel() { Figure = args.Figure };
            FigureListItems.Add(viewModel);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedFigureListItemViewModel != null)
            {
                var viewModelToDelete = SelectedFigureListItemViewModel;
                SelectedFigureContentViewModel = null;
                _FiguresesRepo.RemoveFigure(viewModelToDelete.Figure);
                FigureListItems.Remove(viewModelToDelete);
            }
        }

        public void ComputeTotalArea()
        {
            TotalArea = _ComputeAreaService.ComputeTotalArea();
        }

        public async void SubmitArea()
        {
            await Task.Factory.StartNew(() =>
                   {
                       try
                       {
                           _SubmissionService.SubmitTotalArea(TotalArea);
                       }
                       catch
                       {
                           ShowViewModel<AddTriangleViewModel>();
                       }

                   });
        }

        private ObservableCollection<BaseListItemViewModel> CreateListViewModelsFromFigureList(List<FigureBaseEntity> figures)
        {
            ObservableCollection<BaseListItemViewModel> viewModels = new ObservableCollection<BaseListItemViewModel>();
            foreach (var figure in figures)
            {
                BaseListItemViewModel viewModel = new BaseListItemViewModel { Figure = figure };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        private ObservableCollection<FigureTypeViewItem> CreateListViewModelsFromFigureTypeList(List<FigureType> figures)
        {
            ObservableCollection<FigureTypeViewItem> viewModels = new ObservableCollection<FigureTypeViewItem>();
            foreach (var figure in figures)
            {
                FigureTypeViewItem viewModel = new FigureTypeViewItem() { FigureName = figure.FigureName };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        private void UpdateTriangleContent()
        {
            if (SelectedFigureListItemViewModel != null)
            {
                BaseListItemViewModel contentViewModel = new BaseListItemViewModel
                {
                    Figure = _selectedFigureListItemViewModel.Figure
                };
                SelectedFigureContentViewModel = contentViewModel;
            }
            else
            {
                SelectedFigureListItemViewModel = null;
            }
        }
    }
}
