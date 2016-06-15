using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTest.Business.Entities;
using ShapeTests.ViewModel;
using ShapeTests.ViewModel.Helpers;
using ShapeTests.ViewModel.ViewModels;

namespace ShapeTest.ViewModel.UnitTests
{
    [TestClass]
    public class FigureListItemViewModelTests
    {
        [TestMethod]
        public void ShouldKeepInSyncSelectedFigureWithViewModel()
        {
            // Arrange
            const string expectedName = "New Triangle";           
            //Triangle testTriangle = CreateTriangle(expectedName, expectedBase, expectedHeight);
            FigureListItemViewModel viewModel = new ShapeTests.ViewModel.ViewModels.FigureListItemViewModel();
            var figure = (BaseFigure) FigureFactory.GetFigure("Triangle");

            viewModel.Figure = figure;
            

            // Assert
            viewModel.FigureName.Should().Be(expectedName);

        }
    }
}
