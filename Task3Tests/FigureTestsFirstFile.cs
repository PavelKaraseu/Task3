using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the creation of figures. Partial class. </summary>
    /// <remarks> Includes tests to create a circle, rectangle, square. </remarks>
    [TestClass()]
    public partial class FigureTests
    {
        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = 0.0;
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsZeroMaterialFilm_ArgumentException()
        {
            // Arrange
            double radius = 0.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Film());

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = 0.0;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsZeroMaterialPaper_ArgumentException()
        {
            // Arrange
            double radius = 0.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = 0.0;
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsZeroMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double radius = 0.0;
            Colors color = Colors.Red;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = -0.1;
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsNegativeMaterialFilm_ArgumentException()
        {
            // Arrange
            double radius = -0.1;

            // Action
            Figure circle = new Figure(new Circle(radius), new Film());

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = -1.5;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsNegativeMaterialPaper_ArgumentException()
        {
            // Arrange
            double radius = -1.5;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = -3.0;
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Argument exception: The radius of the circle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The radius of the circle can not be equal zero or be less than zero.")]
        public void CreateCircle_RadiusIsNegativeMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double radius = -3.0;
            Colors color = Colors.Red;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);

            // Assert
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = positive value;
        /// Material = Film;
        /// </arrange>
        /// <assert> Figure circle with parameters: radius = 3.0, material = film </assert>
        [TestMethod()]
        public void CreateCircle_RadiusIsPositiveMaterialFilm()
        {
            // Arrange
            double radius = 3.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Film());

            // Assert
            double _radius = 3.0;
            double area = Math.PI * (_radius * _radius);
            Film film = new Film();
            Colors color = Colors.Transparent;

            Assert.IsTrue(area == circle.Shape.GetArea() && film.Equals(circle.Material) && color == circle.Material.Color);
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = positive value;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Figure circle with parameters: radius = 5.5, material = paper </assert>
        [TestMethod()]
        public void CreateCircle_RadiusIsPositiveMaterialPaper()
        {
            // Arrange
            double radius = 5.5;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());

            // Assert
            double _radius = 5.5;
            double area = Math.PI * (_radius * _radius);
            Paper paper = new Paper();
            Colors color = Colors.White;

            Assert.IsTrue(area == circle.Shape.GetArea() && paper.Equals(circle.Material) && color == circle.Material.Color);
        }

        /// <summary> Create circle. </summary>
        /// <arrange> 
        /// Radius = positive value;
        /// Material = Paper;
        /// Color = Blue;
        /// </arrange>
        /// <assert> Figure circle with parameters: radius = 12.1, material = paper, color = blue </assert>
        [TestMethod()]
        public void CreateCircle_RadiusIsPositiveMaterialPaperPainted()
        {
            // Arrange
            double radius = 12.1;
            Colors color = Colors.Blue;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            circle.Paint(color);

            // Assert
            double _radius = 12.1;
            double area = Math.PI * (_radius * _radius);
            Paper paper = new Paper();
            Colors _color = Colors.Blue;

            Assert.IsTrue(area == circle.Shape.GetArea() && paper.Equals(circle.Material) && _color == circle.Material.Color);
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 0.0;
        /// width = 0.0
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LenghtAndWidthIsZeroMaterialFilm_ArgumentException()
        {
            // Arrange
            double length = 0.0;
            double width = 0.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Film());

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 0.0;
        /// width = 0.0
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LenghtAndWidthIsZeroMaterialPaper_ArgumentException()
        {
            // Arrange
            double length = 0.0;
            double width = 0.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 0.0;
        /// width = 0.0
        /// Material = Paper;
        /// Color = Yellow;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LenghtAndWidthIsZeroMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double length = 0.0;
            double width = 0.0;
            Colors color = Colors.Yellow;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = -3.0;
        /// width = 2.0
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LengthOrWidthIsNegativeMaterialFilm_ArgumentException()
        {
            // Arrange
            double length = -3.0;
            double width = 2.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Film());

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 3.0;
        /// width = -2.0
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LengthOrWidthIsNegativeMaterialPaper_ArgumentException()
        {
            // Arrange
            double length = 3.0;
            double width = -2.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 3.0;
        /// width = -2.0
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Argument exception: The length or width of the rectangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length or width of the rectangle can not be equal zero or be less than zero.")]
        public void CreateRectangle_LengthOrWidthIsNegativeMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double length = 3.0;
            double width = -2.0;
            Colors color = Colors.Red;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 3.0;
        /// width = 3.0
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Argument exception: The length and width of the rectangle can not be equal and length should be more than width. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length and width of the rectangle can not be equal and length should be more than width.")]
        public void CreateRectangle_LengthAndWidthIsEqual_ArgumentException()
        {
            // Arrange
            double length = 3.0;
            double width = 3.0;
            Colors color = Colors.Red;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 3.0;
        /// width = 4.0
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Argument exception: The length and width of the rectangle can not be equal and length should be more than width. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The length and width of the rectangle can not be equal and length should be more than width.")]
        public void CreateRectangle_WidthGreaterThanLength_ArgumentException()
        {
            // Arrange
            double length = 3.0;
            double width = 4.0;
            Colors color = Colors.Red;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 4.0;
        /// width = 3.0
        /// Material = Film;
        /// </arrange>
        /// <assert> Figure rectangle with parameters: area = 12.0, material = film </assert>
        [TestMethod()]
        public void CreateRectangle_LengthAndWidthIsPositiveMaterialFilm_ArgumentException()
        {
            // Arrange
            double length = 4.0;
            double width = 3.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Film());

            // Assert
            double _length = 4.0;
            double _width = 3.0;
            double area = _length * _width;
            Film film = new Film();

            Assert.IsTrue(area == rectangle.Shape.GetArea() && film.Equals(rectangle.Material));
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 4.0;
        /// width = 3.0
        /// Material = Paper;
        /// </arrange>
        /// <assert> Figure rectangle with parameters: area = 12.0, material = paper </assert>
        [TestMethod()]
        public void CreateRectangle_LengthAndWidthIsPositiveMaterialPaper_ArgumentException()
        {
            // Arrange
            double length = 4.0;
            double width = 3.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());

            // Assert
            double _length = 4.0;
            double _width = 3.0;
            double area = _length * _width;
            Paper paper = new Paper();

            Assert.IsTrue(area == rectangle.Shape.GetArea() && paper.Equals(rectangle.Material));
        }

        /// <summary> Create rectangle. </summary>
        /// <arrange> 
        /// length = 5.0;
        /// width = 3.0
        /// Material = Paper;
        /// Color = Blue;
        /// </arrange>
        /// <assert> Figure rectangle with parameters: area = 15.0, material = paper, color = blue </assert>
        [TestMethod()]
        public void CreateRectangle_LengthAndWidthIsPositiveMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double length = 5.0;
            double width = 3.0;
            Colors color = Colors.Blue;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            rectangle.Paint(color);

            // Assert
            double _length = 5.0;
            double _width = 3.0;
            double area = _length * _width;
            Paper paper = new Paper();
            Colors _color = Colors.Blue;


            Assert.IsTrue(area == rectangle.Shape.GetArea() && paper.Equals(rectangle.Material) && _color == rectangle.Material.Color);
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 0.0;
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsZeroMaterialFilm_ArgumentException()
        {
            // Arrange
            double side = 0.0;

            // Action
            Figure square = new Figure(new Square(side), new Film());

            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 0.0;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsZeroMaterialPaper_ArgumentException()
        {
            // Arrange
            double side = 0.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());

            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 0.0;
        /// Material = Paper;
        /// Color = Orange;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsZeroMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double side = 0.0;
            Colors color = Colors.Orange;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            square.Paint(color);

            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = -5.0;
        /// Material = Film;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsNegativeMaterialFilm_ArgumentException()
        {
            // Arrange
            double side = -5.0;

            // Action
            Figure square = new Figure(new Square(side), new Film());

            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = -3.2;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsNegativeMaterialPaper_ArgumentException()
        {
            // Arrange
            double side = -5.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());

            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = -0.1;
        /// Material = Paper;
        /// Color = Green;
        /// </arrange>
        /// <assert> Argument exception: The side of the square can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The side of the square can not be equal zero or be less than zero.")]
        public void CreateSquare_SideIsNegativeMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double side = -0.1;
            Colors color = Colors.Green;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            square.Paint(color);
            // Assert
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 2.5;
        /// Material = Film;
        /// </arrange>
        /// <assert> Figure square with parameters: area = 6.25, material = film </assert>
        [TestMethod()]
        public void CreateSquare_SideIsPositiveMaterialFilm_ArgumentException()
        {
            // Arrange
            double side = 2.5;

            // Action
            Figure square = new Figure(new Square(side), new Film());

            // Assert
            double _side = 2.5;
            double area = _side * _side;
            Film film = new Film();
            Colors _color = Colors.Transparent;

            Assert.IsTrue(area == square.Shape.GetArea() && film.Equals(square.Material) && _color == square.Material.Color);
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 0.1;
        /// Material = Paper;
        /// </arrange>
        /// <assert> Figure square with parameters: area = 0.01, material = paper </assert>
        [TestMethod()]
        public void CreateSquare_SideIsPositiveMaterialPaper_ArgumentException()
        {
            // Arrange
            double side = 0.1;

            // Action
            Figure square = new Figure(new Square(side), new Paper());

            // Assert
            double _side = 0.1;
            double area = _side * _side;
            Paper paper = new Paper();
            Colors _color = Colors.White;

            Assert.IsTrue(area == square.Shape.GetArea() && paper.Equals(square.Material) && _color == square.Material.Color);
        }

        /// <summary> Create square. </summary>
        /// <arrange> 
        /// Side = 12.1;
        /// Material = Paper;
        /// Color = Red;
        /// </arrange>
        /// <assert> Figure square with parameters: area = 146.41, material = paper, color = red </assert>
        [TestMethod()]
        public void CreateSquare_SideIsPositiveMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double side = 12.1;
            Colors color = Colors.Red;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            square.Paint(color);

            // Assert
            double _side = 12.1;
            double area = _side * _side;
            Paper paper = new Paper();
            Colors _color = Colors.Red;

            Assert.IsTrue(area == square.Shape.GetArea() && paper.Equals(square.Material) && _color == square.Material.Color);
        }
    }
}