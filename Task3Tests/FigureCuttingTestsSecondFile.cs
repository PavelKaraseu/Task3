using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task3Shapes.ShapeException;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the cutting of the figure. Partial class. </summary>
    public partial class FigureCuttingTests
    {
        /// <summary> Сircle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 3.0 and baseB = 2.0 and height = 1.5
        /// The cut figure is a circle with radius = 1.2
        /// </arrange>
        /// <assert> Cut circle </assert>
        [TestMethod()]
        public void TrapeziumCutting_CircleFromTrapezium_MaterialPaper()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double height = 1.5;
            double radius = 0.75;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Figure circle = new Figure(trapezium, new Circle(radius));

            // Assert
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Assert.IsTrue(circle.Shape.GetArea() == circle1.Shape.GetArea() && circle.Material.Equals(circle1.Material));
        }

        /// <summary> Сircle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 3.0 and baseB = 2.0 and height = 1.5
        /// The cut figure is a circle with radius = 3.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a circle. Try with a smaller circle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a circle. Try with a smaller circle.")]
        public void TrapeziumCutting_CircleFromTrapezium_CutException()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double height = 1.5;
            double radius = 3.5;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            new Figure(trapezium, new Circle(radius));

            // Assert
        }

        /// <summary> Rectangle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 3.0 and baseB = 2.0 and height = 1.5
        /// The cut figure is a rectangle with length = 1.5 and width = 1.2
        /// </arrange>
        /// <assert> Cut rectangle </assert>
        [TestMethod()]
        public void TrapeziumCutting_RectangleFromTrapezium_MaterialPaper()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double height = 1.5;
            double length = 1.5;
            double width = 1.2;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Figure rectangle = new Figure(trapezium, new Rectangle(length, width));

            // Assert
            Figure rectangle1 = new Figure(new Rectangle(length, width), new Paper());
            Assert.IsTrue(rectangle.Shape.GetArea() == rectangle1.Shape.GetArea() && rectangle.Material.Equals(rectangle1.Material));
        }

        /// <summary> Rectangle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 3.0 and baseB = 2.0 and height = 1.5
        /// The cut figure is a rectangle with length = 3.5 and width = 2.2
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a rectangle. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a rectangle. Try with a smaller rectangle.")]
        public void TrapeziumCutting_RectangleFromTrapezium_CutException()
        {
            // Arrange
            double baseA = 3.0;
            double baseB = 2.0;
            double height = 1.5;
            double length = 3.5;
            double width = 2.2;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            new Figure(trapezium, new Rectangle(length, width));

            // Assert
        }

        /// <summary> Square from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 2.0
        /// The cut figure is a square with side = 1.5
        /// </arrange>
        /// <assert> Cut square </assert>
        [TestMethod()]
        public void TrapeziumCutting_SquareFromTrapezium_MaterialPaper()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 2.0;
            double side = 1.5;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Figure square = new Figure(trapezium, new Square(side));

            // Assert
            Figure square1 = new Figure(new Square(side), new Paper());
            Assert.IsTrue(square.Shape.GetArea() == square1.Shape.GetArea() && square.Material.Equals(square1.Material));
        }

        /// <summary> Square from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 2.0
        /// The cut figure is a square with side = 5.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a squre. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a squre. Try with a smaller rectangle.")]
        public void TrapeziumCutting_SquareFromTrapezium_CutException()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 2.0;
            double side = 5.5;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            new Figure(trapezium, new Square(side));

            // Assert
        }

        /// <summary> Trapezium from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 2.0
        /// The cut figure is a trapezium with with baseA = 3.0 and baseB = 1.0 and height = 2.0
        /// </arrange>
        /// <assert> Cut trapezium </assert>
        [TestMethod()]
        public void TrapeziumCutting_TrapeziumFromTrapezium_MaterialPaper()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 2.0;
            double _baseA = 3.0;
            double _baseB = 1.0;
            double _height = 2.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Figure trapezium1 = new Figure(trapezium, new Trapezium(_baseA, _baseB, _height));

            // Assert
            Figure trapezium2 = new Figure(new Trapezium(_baseA, _baseB, _height), new Paper());
            Assert.IsTrue(trapezium1.Shape.GetArea() == trapezium2.Shape.GetArea() && trapezium1.Material.Equals(trapezium2.Material));
        }

        /// <summary> Trapezium from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 2.0
        /// The cut figure is a trapezium with with baseA = 5.0 and baseB = 1.0 and height = 2.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a trapezium. Try with a smaller trapezium. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a trapezium. Try with a smaller trapezium.")]
        public void TrapeziumCutting_TrapeziumFromTrapezium_CutException()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 2.0;
            double _baseA = 5.0;
            double _baseB = 1.0;
            double _height = 2.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            new Figure(trapezium, new Trapezium(_baseA, _baseB, _height));

            // Assert
        }

        /// <summary> Triangle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 3.0
        /// The cut figure is a triangle with with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// </arrange>
        /// <assert> Cut triangle </assert>
        [TestMethod()]
        public void TrapeziumCutting_TriangleFromTrapezium_MaterialPaper()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 3.0;
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Figure triangle = new Figure(trapezium, new Triangle(sideA, sideB, sideC));

            // Assert
            Figure triangle1 = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Assert.IsTrue(triangle.Shape.GetArea() == triangle1.Shape.GetArea() && triangle.Material.Equals(triangle1.Material));
        }

        /// <summary> Triangle from trapezium. </summary>
        /// <arrange> 
        /// The original figure is a trapezium with baseA = 4.0 and baseB = 3.0 and height = 3.0
        /// The cut figure is a triangle with with sideA = 4.0 and sideB = 4.0 and sideC = 4.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a triangle. Try with a smaller triangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a triangle. Try with a smaller triangle.")]
        public void TrapeziumCutting_TriangleFromTrapezium_CutException()
        {
            // Arrange
            double baseA = 4.0;
            double baseB = 3.0;
            double height = 3.0;
            double sideA = 4.0;
            double sideB = 4.0;
            double sideC = 4.0;

            // Action
            Figure trapezium = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            new Figure(trapezium, new Triangle(sideA, sideB, sideC));

            // Assert
        }

        /// <summary> Circle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a circle with radius = 0.75
        /// </arrange>
        /// <assert> Cut circle </assert>
        [TestMethod()]
        public void TriangleCutting_CircleFromTriangle_MaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double radius = 0.75;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Figure circle = new Figure(triangle, new Circle(radius));

            // Assert
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Assert.IsTrue(circle.Shape.GetArea() == circle1.Shape.GetArea() && circle.Material.Equals(circle1.Material));
        }

        /// <summary> Circle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a circle with radius = 3.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a circle. Try with a smaller circle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a circle. Try with a smaller circle.")]
        public void TriangleCutting_CircleFromTriangle_CutException()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double radius = 3.0;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            new Figure(triangle, new Circle(radius));

            // Assert
        }

        /// <summary> Rectangle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a rectangle with length = 2.0 and width = 0.866
        /// </arrange>
        /// <assert> Cut rectangle </assert>
        [TestMethod()]
        public void TriangleCutting_RectangleFromTriangle_MaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double length = 2.0;
            double width = 0.866;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Figure rectangle = new Figure(triangle, new Rectangle(length, width));

            // Assert
            Figure rectangle1 = new Figure(new Rectangle(length, width), new Paper());
            Assert.IsTrue(rectangle.Shape.GetArea() == rectangle1.Shape.GetArea() && rectangle.Material.Equals(rectangle1.Material));
        }

        /// <summary> Rectangle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a rectangle with length = 4.0 and width = 1.2
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a rectangle. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a rectangle. Try with a smaller rectangle.")]
        public void TriangleCutting_RectangleFromTriangle_CutException()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double length = 4.0;
            double width = 1.2;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            new Figure(triangle, new Rectangle(length, width));

            // Assert
        }

        /// <summary> Square from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a square with side = 1.5
        /// </arrange>
        /// <assert> Cut square </assert>
        [TestMethod()]
        public void TriangleCutting_SquareFromTriangle_MaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double side = 1.2;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Figure square = new Figure(triangle, new Square(side));

            // Assert
            Figure square1 = new Figure(new Square(side), new Paper());
            Assert.IsTrue(square.Shape.GetArea() == square1.Shape.GetArea() && square.Material.Equals(square1.Material));
        }

        /// <summary> Square from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a square with side = 1.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a square. Try with a smaller square. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a square. Try with a smaller square.")]
        public void TriangleCutting_SquareleFromTriangle_CutException()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double side = 1.5;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            new Figure(triangle, new Square(side));

            // Assert
        }

        /// <summary> Trapezium from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a trapezium with baseA = 3.0 and baseB = 1.5 and height = 1.5
        /// </arrange>
        /// <assert> Cut trapezium </assert>
        [TestMethod()]
        public void TriangleCutting_TrapeziumFromTriangle_MaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double baseA = 3.0;
            double baseB = 1.5;
            double height = 1.2;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Figure trapezium = new Figure(triangle, new Trapezium(baseA, baseB, height));

            // Assert
            Figure trapezium1 = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Assert.IsTrue(trapezium.Shape.GetArea() == trapezium1.Shape.GetArea() && trapezium.Material.Equals(trapezium1.Material));
        }

        /// <summary> Trapezium from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a trapezium with baseA = 3.0 and baseB = 2.5 and height = 3.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a trapezium. Try with a smaller trapezium. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a trapezium. Try with a smaller trapezium.")]
        public void TriangleCutting_TrapeziumFromTriangle_CutException()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double baseA = 3.0;
            double baseB = 2.5;
            double height = 3.5;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            new Figure(triangle, new Trapezium(baseA, baseB, height));

            // Assert
        }

        /// <summary> Triangle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a triangle with sideA = 2.5 and sideB = 2.5 and sideC = 2.5
        /// </arrange>
        /// <assert> Cut triangle </assert>
        [TestMethod()]
        public void TriangleCutting_TriangleFromTriangle_MaterialPaper()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double _sideA = 2.5;
            double _sideB = 2.5;
            double _sideC = 2.5;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Figure triangle1 = new Figure(triangle, new Triangle(_sideA, _sideB, _sideC));

            // Assert
            Figure triangle2 = new Figure(new Triangle(_sideA, _sideB, _sideC), new Paper());
            Assert.IsTrue(triangle1.Shape.GetArea() == triangle2.Shape.GetArea() && triangle1.Material.Equals(triangle2.Material));
        }

        /// <summary> Triangle from triangle. </summary>
        /// <arrange> 
        /// The original figure is a triangle with sideA = 3.0 and sideB = 3.0 and sideC = 3.0
        /// The cut figure is a triangle with sideA = 3.5 and sideB = 3.5 and sideC = 3.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a triangle. Try with a smaller triangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a triangle. Try with a smaller triangle.")]
        public void TriangleCutting_TriangleFromTriangle_CutException()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 3.0;
            double sideC = 3.0;
            double _sideA = 3.5;
            double _sideB = 3.5;
            double _sideC = 3.5;

            // Action
            Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            new Figure(triangle, new Triangle(_sideA, _sideB, _sideC));

            // Assert
        }
    }
}