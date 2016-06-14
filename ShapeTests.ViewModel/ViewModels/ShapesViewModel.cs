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

        //private ObservableCollection<TriangleListItemViewModel> _TriangleListItems;
        private ObservableCollection<FigureListItemViewModel> _FigureListItems;

        //private TriangleListItemViewModel _SelectedTriangleListItemViewModel;
        private FigureListItemViewModel _SelectedFigureListItemViewModel;
        private BaseViewModel _SelectedFigureeContentViewModel;
        //private TriangleViewModel _SelectedTriangleContentViewModel;

        public BaseViewModel SelectedFigureeContentViewModel
        {
            get { return _SelectedFigureeContentViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedFigureeContentViewModel, value); }
        }

        private double _TotalArea;

        private MvxCommand _AddFigureCommand;
        private MvxCommand _RemoveTriangleCommand;
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
            RemoveTriangleCommand = new MvxCommand(RemoveSelectedTriangle);
            ComputeAreaCommand = new MvxCommand(ComputeTotalArea);
            SubmitAreaCommand = new MvxCommand(SubmitArea);
        }

        //public ObservableCollection<TriangleListItemViewModel> TriangleListItems
        //{
        //    get { return _TriangleListItems; }
        //    set { SetAndRaisePropertyChanged(ref _TriangleListItems, value); }
        //}

        public ObservableCollection<FigureListItemViewModel> FigureListItems
        {
            get { return _FigureListItems; }
            set { SetAndRaisePropertyChanged(ref _FigureListItems, value); }
        }

        //public TriangleListItemViewModel SelectedTriangleListItemViewModel
        //{
        //    get { return _SelectedTriangleListItemViewModel; }
        //    set { SetAndRaisePropertyChanged(ref _SelectedTriangleListItemViewModel, value); }
        //}

        public FigureListItemViewModel SelectedFigureListItemViewModel
        {
            get { return _SelectedFigureListItemViewModel; }
            set { SetAndRaisePropertyChanged(ref _SelectedFigureListItemViewModel, value); }
        }

        //public TriangleViewModel SelectedTriangleContentViewModel
        //{
        //    get { return _SelectedTriangleContentViewModel; }
        //    set { SetAndRaisePropertyChanged(ref _SelectedTriangleContentViewModel, value); }
        //}

        //public TriangleListItemViewModel SelectedFigureListItemViewModel
        //{
        //    get { return _SelectedTriangleListItemViewModel; }
        //    set { SetAndRaisePropertyChanged(ref _SelectedTriangleListItemViewModel, value); }
        //}

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

        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            base.RaisePropertyChanged(changedArgs);

            //if (changedArgs.PropertyName == nameof(SelectedTriangleListItemViewModel))
            //{
            //    UpdateFigureleContent();
            //}

            if (changedArgs.PropertyName == nameof(SelectedFigureListItemViewModel))
            {
                UpdateFigureContent();
            }


        }

        public override void Start()
        {
            List<IFigure> figures = _FiguresRepo.GetFigures();
            //TriangleListItems = CreateListViewModelsFromTriangeList(triangles);
            FigureListItems = CreateListViewModelsFromFigureList(figures);
            //SelectedTriangleListItemViewModel = TriangleListItems.FirstOrDefault();
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
            //if (args.Figure is Triangle)
            //{
            //    viewModel = new FigureListItemViewModel() { Figure = (Triangle)args.Figure};
            //}
            //else if (args.Figure is Square)
            //{
            //    viewModel = new FigureListItemViewModel() { Figure = (Square)args.Figure };
            //}
            //FigureListItemViewModel<Triangle> viewModel
            viewModel = new FigureListItemViewModel() {Figure = (BaseFigure) args.Figure};
            FigureListItems.Add(viewModel);
        }

        public void RemoveSelectedTriangle()
        {
            if (SelectedFigureListItemViewModel != null)
            {
                var viewModelToDelete = SelectedFigureListItemViewModel;
                //SelectedTriangleContentViewModel = null;
                SelectedFigureeContentViewModel = null;
                _FiguresRepo.RemoveFigure(viewModelToDelete.Figure);
                //TriangleListItems.Remove(viewModelToDelete);
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

        //private ObservableCollection<FigureListItemViewModel> CreateListViewModelsFromTriangeList(List<IFigure> triangles)
        //{
        //    ObservableCollection<FigureListItemViewModel> viewModels = new ObservableCollection<FigureListItemViewModel>();
        //    foreach (var triangle in triangles)
        //    {
        //        FigureListItemViewModel viewModel = new FigureListItemViewModel();
        //        F viewModel = new TriangleListItemViewModel { Triangle = (Triangle)triangle };
        //        viewModels.Add(viewModel);
        //    }
        //    return viewModels;
        //}

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
                //contentViewModel = new TriangleViewModel
                //{
                //    Figure = _SelectedTriangleListItemViewModel.Triangle
                //};
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



                //   SelectedTriangleContentViewModel = contentViewModel;
                SelectedFigureeContentViewModel = contentViewModel;
            }
            else
            {
                //SelectedTriangleListItemViewModel = null;
                SelectedFigureeContentViewModel = null;
            }
        }
    }
}