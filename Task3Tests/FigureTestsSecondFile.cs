using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the creation of figures. Partial class. </summary>
    /// <remarks> Includes tests to create a trapezium, a triangle. </remarks>
    public partial class FigureTests
    {
        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 0.0
        /// baseB = 2.0
        /// heigth = 3.0
        /// Material = Film
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsZeroMaterialFilm_ArgumentException()
        {
            // Arrange
            double baseA = 0.0;
            double baseB = 2.0;
            double heigth = 3.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Film());

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 2.0
        /// baseB = 0.0
        /// heigth = 3.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsZeroMaterialPaper_ArgumentException()
        {
            // Arrange
            double baseA = 2.0;
            double baseB = 0.0;
            double heigth = 3.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 3.0
        /// baseB = 2.0
        /// heigth = 0.0
        /// Material = Paper
        /// Color = Blue
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsZeroMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double heigth = 0.0;

            Colors color = Colors.Blue;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());
            trapezium.Paint(color);

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = -3.0
        /// baseB = 2.0
        /// heigth = 5.0
        /// Material = Film
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsNegativeMaterialFilm_ArgumentException()
        {
            // Arrange
            double baseA = -3.0;
            double baseB = 2.0;
            double heigth = 5.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Film());

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 3.0
        /// baseB = -2.0
        /// heigth = 5.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsNegativeMaterialPaper_ArgumentException()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = -2.0;
            double heigth = 5.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 3.0
        /// baseB = 2.0
        /// heigth = -5.0
        /// Material = Paper
        /// Color = Yellow
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.")]
        public void CreateTrapezium_BaseAorBaseBorHeightIsNegativeMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double heigth = -5.0;

            Colors color = Colors.Yellow;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());
            trapezium.Paint(color);

            // Assert
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 3.0
        /// baseB = 2.0
        /// heigth = 5.0
        /// Material = Film
        /// </arrange>
        /// <assert> Figure isosceles trapezium with parameters: area = 12.5, material = film </assert>
        [TestMethod()]
        public void CreateTrapezium_BaseAandBaseBandHeightIsPositiveMaterialFilm()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double heigth = 5.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Film());

            // Assert
            double _baseA = 3.0;
            double _baseB = 2.0;
            double _height = 5.0;
            double area = ((_baseA + _baseB) / 2.0) * _height;
            Film film = new Film();
            Colors color = Colors.Transparent;

            Assert.IsTrue(area == trapezium.Shape.GetArea() && film.Equals(trapezium.Material) && color == trapezium.Material.Color);
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 4.0
        /// baseB = 1.0
        /// heigth = 2.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Figure isosceles trapezium with parameters: area = 5, material = paper </assert>
        [TestMethod()]
        public void CreateTrapezium_BaseAandBaseBandHeightIsPositiveMaterialPaper()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double heigth = 5.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());

            // Assert
            double _baseA = 3.0;
            double _baseB = 2.0;
            double _height = 5.0;
            double area = ((_baseA + _baseB) / 2.0) * _height;
            Paper paper = new Paper();
            Colors color = Colors.White;

            Assert.IsTrue(area == trapezium.Shape.GetArea() && paper.Equals(trapezium.Material) && color == trapezium.Material.Color);
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 4.0
        /// baseB = 1.0
        /// heigth = 2.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Figure isosceles trapezium with parameters: area = 5, material = paper, color = orange </assert>
        [TestMethod()]
        public void CreateTrapezium_BaseAandBaseBandHeightIsPositiveMaterialPaperPaited()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double heigth = 5.0;

            Colors color = Colors.Orange;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Paper());
            trapezium.Paint(color);

            // Assert
            double _baseA = 3.0;
            double _baseB = 2.0;
            double _height = 5.0;
            double area = ((_baseA + _baseB) / 2.0) * _height;
            Paper paper = new Paper();
            Colors _color = Colors.Orange;

            Assert.IsTrue(area == trapezium.Shape.GetArea() && paper.Equals(trapezium.Material) && _color == trapezium.Material.Color);
        }

        /// <summary> Create isosceles trapezium. </summary>
        /// <arrange> 
        /// baseA = 2.0
        /// baseB = 3.0
        /// heigth = 5.0
        /// Material = Film
        /// </arrange>
        /// <assert> Argument exception: The baseA or baseB or height of the trapezium can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The base A should be more than base B.")]
        public void CreateTrapezium_BaseBGreaterThanBaseA_ArgumentException()
        {
            // Arrange
            double baseA = 2.0;
            double baseB = 3.0;
            double heigth = 5.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, heigth), new Film());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 0.0
        /// sideB = 2.0
        /// sideC = 2.0
        /// Material = Film
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsZeroMaterialFilm_ArgumentException()
        {
            // Arrange
            double sideA = 0.0;
            double sideB = 2.0;
            double sideC = 2.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Film());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 2.0
        /// sideB = 0.0
        /// sideC = 2.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsZeroMaterialPaper_ArgumentException()
        {
            // Arrange
            double sideA = 2.0;
            double sideB = 0.0;
            double sideC = 2.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 2.0
        /// sideB = 2.0
        /// sideC = 0.0
        /// Material = Paper
        /// Color = Green
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsZeroMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = 0.0;

            Colors color = Colors.Green;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            triangle.Paint(color);

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = -2.0
        /// sideB = 2.0
        /// sideC = 2.0
        /// Material = Film
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsNegativeMaterialFilm_ArgumentException()
        {
            // Arrange
            double sideA = -2.0;
            double sideB = 2.0;
            double sideC = 2.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Film());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 2.0
        /// sideB = -2.0
        /// sideC = 2.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsNegativeMaterialPaper_ArgumentException()
        {
            // Arrange
            double sideA = 2.0;
            double sideB = -2.0;
            double sideC = 2.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 2.0
        /// sideB = 2.0
        /// sideC = -2.0
        /// Material = Paper
        /// Color = Blue
        /// </arrange>
        /// <assert> Argument exception: The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
            "The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.")]
        public void CreateTriangle_SideAorSideBorSideCIsNegativeMaterialPaperPainted_ArgumentException()
        {
            // Arrange
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = -2.0;

            Colors color = Colors.Blue;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            triangle.Paint(color);

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 2.0
        /// sideB = 2.0
        /// sideC = 1.0
        /// Material = Paper
        /// Color = Blue
        /// </arrange>
        /// <assert> Argument exception: Equilateral triangle sides should be equal. </assert>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Equilateral triangle sides should be equal.")]
        public void CreateTriangle_SidesAreNotEqual_ArgumentException()
        {
            // Arrange
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = 1.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Film());

            // Assert
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 3.0
        /// sideB = 3.0
        /// sideC = 3.0
        /// Material = Film
        /// </arrange>
        /// <assert> Figure equilateral triangle with parameters: area = 3.8971.. , material = film </assert>
        [TestMethod()]
        public void CreateTriangle_SidesIsPositiveMaterialFilm()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Film());

            // Assert
            double _sideA = 3.0;
            // double _sideB = _sideA = _sideC 3.0;
            // double _sideC = _sideB = _sideC 3.0;
            double _height = (Math.Sqrt(3.0) / 2.0) * _sideA;
            double area = (_sideA / 2.0) * _height;
            Film film = new Film();
            Colors color = Colors.Transparent;

            Assert.IsTrue(area == triangle.Shape.GetArea() && film.Equals(triangle.Material) && color == triangle.Material.Color);
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 3.0
        /// sideB = 3.0
        /// sideC = 3.0
        /// Material = Paper
        /// </arrange>
        /// <assert> Figure equilateral triangle with parameters: area = 3.8971.. , material = paper </assert>
        [TestMethod()]
        public void CreateTriangle_SidesIsPositiveMaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());

            // Assert
            double _sideA = 3.0;
            // double _sideB = _sideA = _sideC 3.0;
            // double _sideC = _sideB = _sideC 3.0;
            double _height = (Math.Sqrt(3.0) / 2.0) * _sideA;
            double area = (_sideA / 2.0) * _height;
            Paper paper = new Paper();
            Colors color = Colors.White;

            Assert.IsTrue(area == triangle.Shape.GetArea() && paper.Equals(triangle.Material) && color == triangle.Material.Color);
        }

        /// <summary> Create equilateral triangle. </summary>
        /// <arrange> 
        /// sideA = 3.0
        /// sideB = 3.0
        /// sideC = 3.0
        /// Material = Paper
        /// Color = Orange
        /// </arrange>
        /// <assert> Figure equilateral triangle with parameters: area = 3.8971.. , material = paper </assert>
        [TestMethod()]
        public void CreateTriangle_SidesIsPositiveMaterialPaperPainted()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;

            Colors color = Colors.Orange;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            triangle.Paint(color);

            // Assert
            double _sideA = 3.0;
            // double _sideB = _sideA = _sideC 3.0;
            // double _sideC = _sideB = _sideC 3.0;
            double _height = (Math.Sqrt(3.0) / 2.0) * _sideA;
            double area = (_sideA / 2.0) * _height;
            Paper paper = new Paper();
            Colors _color = Colors.Orange;

            Assert.IsTrue(area == triangle.Shape.GetArea() && paper.Equals(triangle.Material) && _color == triangle.Material.Color);
        }
    }
}