using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task3.FigureExceptions;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the coloring of the figure. </summary>
    [TestClass()]
    public class FigurePaintingTests
    {
        /// <summary> Сircle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// Color = Blue
        /// </arrange>
        /// <assert> Blue circle. </assert>
        [TestMethod()]
        public void CirclePainting_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            Colors color = Colors.Blue;
            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);

            // Assert
            Colors _color = Colors.Blue;
            Assert.IsTrue(_color == circle.Material.Color);
        }

        /// <summary> Сircle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// First Color = Blue
        /// Second Color = Green
        /// </arrange>
        /// <assert> Paint exception: You can paint a paper figure only once. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "You can paint a paper figure only once.")]
        public void CircleRepainting_MaterialPaper_PaintException()
        {
            // Arrange
            double radius = 2.5;
            Colors firstColor = Colors.Blue;
            Colors secondColor = Colors.Green;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(firstColor);
            circle.Paint(secondColor);
            // Assert
        }

        /// <summary> Сircle painting. </summary>
        /// <arrange> 
        /// Material = Film
        /// color = Orange
        /// </arrange>
        /// <assert> Paint exception: The film can not be painted. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The film can not be painted.")]
        public void CirclePainting_MaterialFilm_PaintException()
        {
            // Arrange
            double radius = 2.5;
            Colors color = Colors.Blue;

            // Action
            Figure circle = new Figure(new Circle(radius), new Film());
            circle.Paint(color);
            // Assert
        }

        /// <summary> Rectangle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// Color = Yellow
        /// </arrange>
        /// <assert> Yellow rectangle. </assert>
        [TestMethod()]
        public void RectanglePainting_MaterialPaper()
        {
            // Arrange
            double length = 2.5;
            double width = 2.0;
            Colors color = Colors.Yellow;
            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
            Colors _color = Colors.Yellow;
            Assert.IsTrue(_color == rectangle.Material.Color);
        }

        /// <summary> Rectangle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// First Color = Yellow
        /// Second Color = Green
        /// </arrange>
        /// <assert> Paint exception: You can paint a paper figure only once. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "You can paint a paper figure only once.")]
        public void RectangleRepainting_MaterialPaper_PaintException()
        {
            // Arrange
            double length = 2.5;
            double width = 2.0;
            Colors firstColor = Colors.Yellow;
            Colors secondColor = Colors.Green;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(firstColor);
            rectangle.Paint(secondColor);
            // Assert
        }

        /// <summary> Rectangle painting. </summary>
        /// <arrange> 
        /// Material = Film
        /// color = Red
        /// </arrange>
        /// <assert> Paint exception: The film can not be painted. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The film can not be painted.")]
        public void RectanglePainting_MaterialFilm_PaintException()
        {
            // Arrange
            double length = 2.5;
            double width = 2.0;
            Colors color = Colors.Red;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Film());
            rectangle.Paint(color);
            // Assert
        }

        /// <summary> Square painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// Color = Yellow
        /// </arrange>
        /// <assert> Yellow square. </assert>
        [TestMethod()]
        public void SquarePainting_MaterialPaper()
        {
            // Arrange
            double side = 3.1;
            Colors color = Colors.Yellow;
            // Action
            Figure square = new Figure(new Square(side), new Paper());
            square.Paint(color);

            // Assert
            Colors _color = Colors.Yellow;
            Assert.IsTrue(_color == square.Material.Color);
        }

        /// <summary> Square painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// First Color = Yellow
        /// Second Color = Green
        /// </arrange>
        /// <assert> Paint exception: You can paint a paper figure only once. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "You can paint a paper figure only once.")]
        public void SquareRepainting_MaterialPaper_PaintException()
        {
            // Arrange
            double side = 2.5;
            Colors firstColor = Colors.Yellow;
            Colors secondColor = Colors.Green;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            square.Paint(firstColor);
            square.Paint(secondColor);
            // Assert
        }

        /// <summary> Square painting. </summary>
        /// <arrange> 
        /// Material = Film
        /// color = Blue
        /// </arrange>
        /// <assert> Paint exception: The film can not be painted. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The film can not be painted.")]
        public void SquarePainting_MaterialFilm_PaintException()
        {
            // Arrange
            double side = 2.5;
            Colors color = Colors.Blue;

            // Action
            Figure square = new Figure(new Square(side), new Film());
            square.Paint(color);
            // Assert
        }

        /// <summary> Trapezium painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// Color = Green
        /// </arrange>
        /// <assert> Green trapezium. </assert>
        [TestMethod()]
        public void TrapeziumPainting_MaterialPaper()
        {
            // Arrange
            double baseA = 3.1;
            double baseB = 2.0;
            double height = 4.5;
            Colors color = Colors.Green;
            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            trapezium.Paint(color);

            // Assert
            Colors _color = Colors.Green;
            Assert.IsTrue(_color == trapezium.Material.Color);
        }

        /// <summary> Trapezium painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// First Color = Yellow
        /// Second Color = Green
        /// </arrange>
        /// <assert> Paint exception: You can paint a paper figure only once. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "You can paint a paper figure only once.")]
        public void TrapeziumRepainting_MaterialPaper_PaintException()
        {
            // Arrange
            double baseA = 3.1;
            double baseB = 2.0;
            double height = 4.5;
            Colors firstColor = Colors.Yellow;
            Colors secondColor = Colors.Green;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            trapezium.Paint(firstColor);
            trapezium.Paint(secondColor);
            // Assert
        }

        /// <summary> Trapezium painting. </summary>
        /// <arrange> 
        /// Material = Film
        /// color = Green
        /// </arrange>
        /// <assert> Paint exception: The film can not be painted. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The film can not be painted.")]
        public void TrapeziumPainting_MaterialFilm_PaintException()
        {
            // Arrange
            double baseA = 3.1;
            double baseB = 2.0;
            double height = 4.5;
            Colors color = Colors.Green;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Film());
            trapezium.Paint(color);
            // Assert
        }

        /// <summary> Triangle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// Color = Green
        /// </arrange>
        /// <assert> Green triangle. </assert>
        [TestMethod()]
        public void TrianglePainting_MaterialPaper()
        {
            // Arrange
            double sideA = 5.0;
            double sideB = 5.0;
            double sideC = 5.0;
            Colors color = Colors.Green;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            triangle.Paint(color);

            // Assert
            Colors _color = Colors.Green;
            Assert.IsTrue(_color == triangle.Material.Color);
        }

        /// <summary> Triangle painting. </summary>
        /// <arrange> 
        /// Material = Paper
        /// First Color = Yellow
        /// Second Color = Green
        /// </arrange>
        /// <assert> Paint exception: You can paint a paper figure only once. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "You can paint a paper figure only once.")]
        public void TriangleRepainting_MaterialPaper_PaintException()
        {
            // Arrange
            double sideA = 5.0;
            double sideB = 5.0;
            double sideC = 5.0;
            Colors firstColor = Colors.Yellow;
            Colors secondColor = Colors.Green;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            triangle.Paint(firstColor);
            triangle.Paint(secondColor);
            // Assert
        }

        /// <summary> Triangle painting. </summary>
        /// <arrange> 
        /// Material = Film
        /// color = Green
        /// </arrange>
        /// <assert> Paint exception: The film can not be painted. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The film can not be painted.")]
        public void TrianglePainting_MaterialFilm_PaintException()
        {
            // Arrange
            double sideA = 5.0;
            double sideB = 5.0;
            double sideC = 5.0;
            Colors color = Colors.Green;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Film());
            triangle.Paint(color);
            // Assert
        }

        /// <summary> Trying to make paper transparent. </summary>
        /// <arrange> 
        /// Material = Paper
        /// color = transparent
        /// </arrange>
        /// <assert> Paint exception: Paper cannot be transparent. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "Paper cannot be transparent.")]
        public void FigurePainting_MaterialPaperColorTransparent_PaintException()
        {
            // Arrange
            double radius = 3.0;
            Colors color = Colors.Transparent;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);
            // Assert
        }

        /// <summary> Trying to make paper white. </summary>
        /// <arrange> 
        /// Material = Paper
        /// color = white
        /// </arrange>
        /// <assert> Paint exception: The paper is already white. </assert>
        [TestMethod()]
        [ExpectedException(typeof(PaintException),
                    "The paper is already white.")]
        public void FigurePainting_MaterialPaperColorWhite_PaintException()
        {
            // Arrange
            double radius = 3.0;
            Colors color = Colors.White;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);
            // Assert
        }
    }
}