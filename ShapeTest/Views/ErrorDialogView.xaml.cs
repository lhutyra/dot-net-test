using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.Wpf.Views
{
    public partial class ErrorDialogView
    {
        public ErrorDialogView()
        {
            InitializeComponent();
        }

        public new ErrorDialogViewModel ViewModel
        {
            get { return (ErrorDialogViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}
