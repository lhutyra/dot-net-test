using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.Wpf.Views
{
    public partial class AddTriangleView
    {
        public AddTriangleView()
        {
            InitializeComponent();
        }

        public new AddFigureViewModel ViewModel
        {
            get { return (AddFigureViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
