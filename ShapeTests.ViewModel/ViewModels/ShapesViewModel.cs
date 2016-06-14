using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        private readonly IFiguresRepository _FiguresRepo;
        private readonly IComputeAreaService _ComputeAreaService;
        private readonly ISubmissionService _SubmissionService;
        
        private ObservableCollection<FigureListItemViewModel> _FigureListItems;

        private FigureListItemViewModel _SelectedFigureListItemViewModel;
        private BaseViewModel _SelectedFigureeContentViewModel;

        public BaseViewModel SelectedFigureeContentViewModel
        {
            get { return _SelectedFigureeContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedFigureeContentViewModel, value); }
        }

        private double _TotalArea;

        private MvxCommand _AddFigureCommand;
        private MvxCommand _RemoveFigureCommand;
        private MvxCommand _ComputeAreaCommand;
        private MvxCommand _SubmitAreaCommand;

        public  ShapesViewModel(IFiguresRepository figureRepo,
            IComputeAreaService computeAreaService,
            ISubmissionService submissionService)
        {
            _FiguresRepo = figureRepo;
            _ComputeAreaService = computeAreaService;
            _SubmissionService = submissionService;

            //_TriangleListItems = new ObservableCollection<TriangleListItemViewModel>();

            AddFigureCommand = new MvxCommand(AddTriangle);
            RemoveFigureCommand = new MvxCommand(RemoveSelectedFigure);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        
        public ObservableCollection<FigureListItemViewModel> FigureListItems
        {
            get { return _FigureListItems; }
            set { SetAndRaisePropertyChanged(ref _FigureListItems, value); }
        }

        
        public FigureListItemViewModel SelectedFigureListItemViewModel
        {
            get { return _SelectedFigureListItemViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedFigureListItemViewModel, value); }
        }

       
        public double TotalArea
        {
            get { return _TotalArea; }
            set { SetAndRaisePropertyChanged(ref _TotalArea, value); }
        }

        public MvxCommand AddFigureCommand
        {
            get { return _AddFigureCommand; }
            set { SetAndRaisePropertyChanged(ref _AddFigureCommand, value); }
        }

        public MvxCommand RemoveFigureCommand
        {
            get { return _RemoveFigureCommand; }
            set { SetAndRaisePropertyChanged(ref _RemoveFigureCommand, value); }
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

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);
      
            if (changedArgs.PropertyName == nameof(SelectedFigureListItemViewModel))
            {
                UpdateFigureContent();
            }
        }

        public override void Start()
        {
            List<IFigure> figures = _FiguresRepo.GetFigures();          
            FigureListItems = CreateListViewModelsFromFigureList(figures);            
            SelectedFigureListItemViewModel = FigureListItems.FirstOrDefault();
            _FiguresRepo.FigureAdded += OnFigureAdded;
        }

        public void AddTriangle()
        {
            ShowViewModel<AddFigureViewModel>();
        }

        public void OnFigureAdded(object sender, FiguresEventArgs args)
        {
            FigureListItemViewModel viewModel = null;          
            viewModel = new FigureListItemViewModel() {Figure = (BaseFigure) args.Figure};
            FigureListItems.Add(viewModel);
        }

        public void RemoveSelectedFigure()
        {
            if (SelectedFigureListItemViewModel != null)
            {
                var viewModelToDelete = SelectedFigureListItemViewModel;                
                SelectedFigureeContentViewModel = null;
                _FiguresRepo.RemoveFigure(viewModelToDelete.Figure);                
                FigureListItems.Remove(viewModelToDelete);
            }
        }

        public void ComputeTotalArea()
        {
            TotalArea = _ComputeAreaService.ComputeTotalArea();
        }

        public void SubmitArea()
        {
            _SubmissionService.SubmitTotalArea(TotalArea);
        }

        private ObservableCollection<FigureListItemViewModel> CreateListViewModelsFromFigureList(List<IFigure> figures)
        {
            ObservableCollection<FigureListItemViewModel> viewModels =
                new ObservableCollection<FigureListItemViewModel>();
            foreach (var figure in figures)
            {
                FigureListItemViewModel viewModel = new FigureListItemViewModel();
                viewModel = new FigureListItemViewModel() {Figure = (BaseFigure) figure};
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        private void UpdateFigureContent()
        {
            if (SelectedFigureListItemViewModel != null)
            {
                BaseViewModel contentViewModel = null;              
                if (SelectedFigureListItemViewModel.Figure is Triangle)
                {
                    contentViewModel = new TriangleViewModel
                    {
                        Figure = _SelectedFigureListItemViewModel.Figure
                    };
                }
                else if (SelectedFigureListItemViewModel.Figure is Square)
                {
                    contentViewModel = new SquareViewModel {Figure = _SelectedFigureListItemViewModel.Figure};
                }
                else if (SelectedFigureListItemViewModel.Figure is Circle)
                {
                    contentViewModel = new CircleViewModel { Figure = _SelectedFigureListItemViewModel.Figure };
                }
                else if (SelectedFigureListItemViewModel.Figure is Rectangle)
                {
                    contentViewModel = new RectangleViewModel() { Figure = _SelectedFigureListItemViewModel.Figure };
                }
                SelectedFigureeContentViewModel = contentViewModel;
            }
            else
            {                
                SelectedFigureeContentViewModel = null;
            }
        }
    }
}