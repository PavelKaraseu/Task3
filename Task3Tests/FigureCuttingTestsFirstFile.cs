using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Task3Shapes.ShapeException;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the cutting of the figure. Partial class. </summary>
    [TestClass()]
    public partial class FigureCuttingTests
    {
        /// <summary> Сircle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a circle with radius = 1.5
        /// </arrange>
        /// <assert> Cut circle </assert>
        [TestMethod()]
        public void CircleCutting_CircleFromCircle_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            double _radius = 1.5;

            // Action
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Figure circle2 = new Figure(circle1, new Circle(_radius));

            // Assert
            Figure circle3 = new Figure(new Circle(_radius), new Paper());
            Assert.IsTrue(circle3.Shape.GetArea() == circle2.Shape.GetArea() && circle3.Material.Equals(circle2.Material));
        }

        /// <summary> Сircle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a circle with radius = 3.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a circle. Try with a smaller circle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a circle. Try with a smaller circle.")]
        public void CircleCutting_CircleFromCircle_CutException()
        {
            // Arrange
            double radius = 2.5;
            double _radius = 3.5;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            new Figure(circle, new Circle(_radius));

            // Assert
        }

        /// <summary> Rectangle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a rectangle with length = 2.0 and width = 1.5
        /// </arrange>
        /// <assert> Cut rectangle </assert>
        [TestMethod()]
        public void CircleCutting_RectangleFromCircle_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            double length = 2.0;
            double width = 1.5;

            // Action
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Figure rectangle1 = new Figure(circle1, new Rectangle(length, width));

            // Assert
            Figure rectangle2 = new Figure(new Rectangle(length, width), new Paper());
            Assert.IsTrue(rectangle1.Shape.GetArea() == rectangle2.Shape.GetArea() && rectangle1.Material.Equals(rectangle2.Material));
        }

        /// <summary> Rectangle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 0.5
        /// The cut figure is a rectangle with length = 2.0 and width = 1.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a rectangle. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a rectangle. Try with a smaller rectangle.")]
        public void CircleCutting_RectangleFromCircle_CutException()
        {
            // Arrange
            double radius = 0.5;
            double length = 2.0;
            double width = 1.5;

            // Action
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            new Figure(circle1, new Rectangle(length, width));

            // Assert
        }

        /// <summary> Square from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a square with side = 2.0
        /// </arrange>
        /// <assert> Cut square </assert>
        [TestMethod()]
        public void CircleCutting_SquareFromCircle_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            double side = 2.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            Figure square = new Figure(circle, new Square(side));

            // Assert
            Figure square1 = new Figure(new Square(side), new Paper());
            Assert.IsTrue(square.Shape.GetArea() == square1.Shape.GetArea() && square.Material.Equals(square1.Material));
        }

        /// <summary> Square from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 0.5
        /// The cut figure is a square with side = 2.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a square. Try with a smaller square. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a square. Try with a smaller square.")]
        public void CircleCutting_SquareFromCircle_CutException()
        {
            // Arrange
            double radius = 0.5;
            double side = 2.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            new Figure(circle, new Square(side));

            // Assert
        }

        /// <summary> Trapezium from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a trapezium with baseA = 2.0 and baseB = 1.2 and height = 1.5
        /// </arrange>
        /// <assert> Cut trapezium </assert>
        [TestMethod()]
        public void CircleCutting_TrapeziumFromCircle_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            double baseA = 2.0;
            double baseB = 1.2;
            double height = 1.5;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            Figure trapezium = new Figure(circle, new Trapezium(baseA, baseB, height));

            // Assert
            Figure trapezium1 = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Assert.IsTrue(trapezium.Shape.GetArea() == trapezium1.Shape.GetArea() && trapezium.Material.Equals(trapezium1.Material));
        }

        /// <summary> Trapezium from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 0.5
        /// The cut figure is a trapezium with baseA = 2.0 and baseB = 1.2 and height = 2.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a trapezium. Try with a smaller trapezium. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a trapezium. Try with a smaller trapezium.")]
        public void CircleCutting_TrapeziumFromCircle_CutException()
        {
            // Arrange
            double radius = 0.5;
            double baseA = 2.0;
            double baseB = 1.2;
            double height = 2.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            new Figure(circle, new Trapezium(baseA, baseB, height));

            // Assert
        }

        /// <summary> Triangle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 2.5
        /// The cut figure is a triangle with sideA = 2.0 and sideB = 2.0 ande SideC = 2.0
        /// </arrange>
        /// <assert> Cut triangle </assert>
        [TestMethod()]
        public void CircleCutting_TriangleFromCircle_MaterialPaper()
        {
            // Arrange
            double radius = 2.5;
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = 2.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            Figure triangle = new Figure(circle, new Triangle(sideA, sideC, sideB));

            // Assert
            Figure triangle1 = new Figure(new Triangle(sideA, sideC, sideB), new Paper());
            Assert.IsTrue(triangle.Shape.GetArea() == triangle1.Shape.GetArea() && triangle.Material.Equals(triangle1.Material));
        }

        /// <summary> Triangle from circle. </summary>
        /// <arrange> 
        /// The original figure is a circle with radius = 1.0
        /// The cut figure is a triangle with sideA = 2.0 and sideB = 2.0 ande SideC = 2.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a triangle. Try with a smaller triangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a triangle. Try with a smaller triangle.")]
        public void CircleCutting_TriangleFromCircle_CutException()
        {
            // Arrange
            double radius = 1.0;
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = 2.0;

            // Action
            Figure circle = new Figure(new Circle(radius), new Paper());
            new Figure(circle, new Triangle(sideA, sideC, sideB));

            // Assert
        }

        /// <summary> Сircle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 3.5 and width = 2.0
        /// The cut figure is a circle with radius = 1.0
        /// </arrange>
        /// <assert> Cut circle </assert>
        [TestMethod()]
        public void RectangleCutting_CircleFromRectangle_MaterialPaper()
        {
            // Arrange
            double length = 3.5;
            double width = 2.0;
            double radius = 1.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            Figure circle = new Figure(rectangle, new Circle(radius));

            // Assert
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Assert.IsTrue(circle.Shape.GetArea() == circle1.Shape.GetArea() && circle.Material.Equals(circle1.Material));
        }

        /// <summary> Сircle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 3.5 and width = 2.0 
        /// The cut figure is a circle with radius = 3.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a circle. Try with a smaller circle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a circle. Try with a smaller circle.")]
        public void RectangleCutting_CircleFromRectangle_CutException()
        {
            // Arrange
            double length = 3.5;
            double width = 2.0;
            double radius = 3.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            new Figure(rectangle, new Circle(radius));

            // Assert
        }

        /// <summary> Rectangle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 3.5 and width = 2.0
        /// The cut figure is a rectagle width length = 2.0 and width = 1.0
        /// </arrange>
        /// <assert> Cut rectangle </assert>
        [TestMethod()]
        public void RectangleCutting_RectangleFromRectangle_MaterialPaper()
        {
            // Arrange
            double length = 3.5;
            double width = 2.0;
            double _length = 2.0;
            double _width = 1.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            Figure rectangle1 = new Figure(rectangle, new Rectangle(_length, _width));

            // Assert
            Figure rectangle2 = new Figure(new Rectangle(_length, _width), new Paper());
            Assert.IsTrue(rectangle1.Shape.GetArea() == rectangle2.Shape.GetArea() && rectangle1.Material.Equals(rectangle2.Material));
        }

        /// <summary> Rectangle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 1.5 and width = 1.0
        /// The cut figure is a rectangle with length = 3.0 and width = 2.5
        /// </arrange>
        /// <assert> Cut exception: ou can not cut such a rectangle. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a rectangle. Try with a smaller rectangle.")]
        public void RectangleCutting_RectangleFromRectangle_CutException()
        {
            // Arrange
            double length = 1.5;
            double width = 1.0;
            double _length = 3.0;
            double _width = 2.5;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            new Figure(rectangle, new Rectangle(_length, _width));

            // Assert
        }

        /// <summary> Square from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 3.5 and width = 2.0
        /// The cut figure is a square with side = 1.8
        /// </arrange>
        /// <assert> Cut square </assert>
        [TestMethod()]
        public void RectangleCutting_SquareFromRectangle_MaterialPaper()
        {
            // Arrange
            double length = 3.5;
            double width = 2.0;
            double side = 1.8;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            Figure square = new Figure(rectangle, new Square(side));

            // Assert
            Figure square1 = new Figure(new Square(side), new Paper());
            Assert.IsTrue(square.Shape.GetArea() == square1.Shape.GetArea() && square.Material.Equals(square1.Material));
        }

        /// <summary> Square from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 1.5 and width = 1.0
        /// The cut figure is a square with side = 4.2
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a square. Try with a smaller square. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a square. Try with a smaller square.")]
        public void RectangleCutting_SquareFromRectangle_CutException()
        {
            // Arrange
            double length = 1.5;
            double width = 1.0;
            double side = 4.2;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            new Figure(rectangle, new Square(side));

            // Assert
        }

        /// <summary> Trapezium from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 4.5 and width = 3.5
        /// The cut figure is a trapezium with baseA = 2.0 and baseB = 1.5 and height = 3.0
        /// </arrange>
        /// <assert> Cut trapezium </assert>
        [TestMethod()]
        public void RectangleCutting_TrapeziumFromRectangle_MaterialPaper()
        {
            // Arrange
            double length = 4.5;
            double width = 3.5;
            double baseA = 2.0;
            double baseB = 1.5;
            double height = 3.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            Figure trapezium = new Figure(rectangle, new Trapezium(baseA, baseB, height));

            // Assert
            Figure trapezium1 = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Assert.IsTrue(trapezium.Shape.GetArea() == trapezium1.Shape.GetArea() && trapezium.Material.Equals(trapezium1.Material));
        }

        /// <summary> Trapezium from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 1.5 and width = 1.0
        /// The cut figure is a trapezium with baseA = 2.0 and baseB = 1.5 and height = 3.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a trapezium. Try with a smaller trapezium. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a trapezium. Try with a smaller trapezium.")]
        public void RectangleCutting_TrapeziumFromRectangle_CutException()
        {
            // Arrange
            double length = 1.5;
            double width = 1.0;
            double baseA = 2.0;
            double baseB = 1.5;
            double height = 3.0;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            new Figure(rectangle, new Trapezium(baseA, baseB, height));

            // Assert
        }

        /// <summary> Triangle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 4.5 and width = 3.5
        /// The cut figure is a triangle with sideA = 1.5 and sideB = 1.5 and sideC = 1.5
        /// </arrange>
        /// <assert> Cut triangle </assert>
        [TestMethod()]
        public void RectangleCutting_TriangleFromRectangle_MaterialPaper()
        {
            // Arrange
            double length = 4.5;
            double width = 3.5;
            double sideA = 1.5;
            double sideB = 1.5;
            double sideC = 1.5;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            Figure triangle = new Figure(rectangle, new Triangle(sideA, sideB, sideC));

            // Assert
            Figure triangle1 = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Assert.IsTrue(triangle.Shape.GetArea() == triangle1.Shape.GetArea() && triangle.Material.Equals(triangle1.Material));
        }

        /// <summary> Triangle from rectangle. </summary>
        /// <arrange> 
        /// The original figure is a rectangle with length = 1.2 and width = 1.0
        /// The cut figure is a triangle with sideA = 1.5 and sideB = 1.5 and sideC = 1.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a triangle. Try with a smaller triangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a triangle. Try with a smaller triangle.")]
        public void RectangleCutting_TriangleFromRectangle_CutException()
        {
            // Arrange
            double length = 1.2;
            double width = 1.0;
            double sideA = 1.5;
            double sideB = 1.5;
            double sideC = 1.5;

            // Action
            Figure rectangle = new Figure(new Rectangle(length, width), new Paper());
            new Figure(rectangle, new Triangle(sideA, sideB, sideC));

            // Assert
        }

        /// <summary> Circle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 5.5
        /// The cut figure is a circle with radius = 1.75
        /// </arrange>
        /// <assert> Cut circle </assert>
        [TestMethod()]
        public void SquareCutting_CircleFromSquare_MaterialPaper()
        {
            // Arrange
            double side = 5.5;
            double radius = 1.75;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            Figure circle = new Figure(square, new Circle(radius));

            // Assert
            Figure circle1 = new Figure(new Circle(radius), new Paper());
            Assert.IsTrue(circle.Shape.GetArea() == circle1.Shape.GetArea() && circle.Material.Equals(circle1.Material));
        }

        /// <summary> Circle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 2.2
        /// The cut figure is a circle with radius = 1.6
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a circle. Try with a smaller circle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a circle. Try with a smaller circle.")]
        public void SquareCutting_CircleFromSquare_CutException()
        {
            // Arrange
            double side = 2.2;
            double radius = 1.6;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            new Figure(square, new Circle(radius));

            // Assert
        }

        /// <summary> Rectangle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 4.5
        /// The cut figure is a rectangle with length = 2.5 and width = 2.0
        /// </arrange>
        /// <assert> Cut rectangle </assert>
        [TestMethod()]
        public void SquareCutting_RectangleFromSquare_MaterialPaper()
        {
            // Arrange
            double side = 4.5;
            double length = 2.5;
            double width = 2.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            Figure rectangle = new Figure(square, new Rectangle(length, width));

            // Assert
            Figure rectangle1 = new Figure(new Rectangle(length, width), new Paper());
            Assert.IsTrue(rectangle.Shape.GetArea() == rectangle1.Shape.GetArea() && rectangle.Material.Equals(rectangle1.Material));
        }

        /// <summary> Rectangle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 2.5
        /// The cut figure is a rectangle with length = 3.0 and width = 1.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a rectangle. Try with a smaller rectangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a rectangle. Try with a smaller rectangle.")]
        public void SquareCutting_RectangleFromSquare_CutException()
        {
            // Arrange
            double side = 2.5;
            double length = 3.0;
            double width = 1.5;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            new Figure(square, new Rectangle(length, width));

            // Assert
        }

        /// <summary> Square from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 4.5
        /// The cut figure is a square with side = 3.5
        /// </arrange>
        /// <assert> Cut square </assert>
        [TestMethod()]
        public void SquareCutting_SquareFromSquare_MaterialPaper()
        {
            // Arrange
            double side = 4.5;
            double _side = 3.5;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            Figure square1 = new Figure(square, new Square(_side));

            // Assert
            Figure square2 = new Figure(new Square(_side), new Paper());
            Assert.IsTrue(square1.Shape.GetArea() == square2.Shape.GetArea() && square1.Material.Equals(square2.Material));
        }

        /// <summary> Square from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 2.5
        /// The cut figure is a square with side = 3.5
        /// </arrange>
        /// <assert> Cut exception: "You can not cut such a square. Try with a smaller square. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a square. Try with a smaller square.")]
        public void SquareCutting_SquareFromSquare_CutException()
        {
            // Arrange
            double side = 2.5;
            double _side = 3.5;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            new Figure(square, new Square(_side));

            // Assert
        }

        /// <summary> Trapezium from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 3.5
        /// The cut figure is a trapezium with baseA = 2.0 and baseB = 1.5 and height = 2.0
        /// </arrange>
        /// <assert> Cut trapezium </assert>
        [TestMethod()]
        public void SquareCutting_TrapeziumFromSquare_MaterialPaper()
        {
            // Arrange
            double side = 3.5;
            double baseA = 2.0;
            double baseB = 1.5;
            double height = 2.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            Figure trapezium = new Figure(square, new Trapezium(baseA, baseB, height));

            // Assert
            Figure trapezium1 = new Figure(new Trapezium(baseA, baseB, height), new Paper());
            Assert.IsTrue(trapezium.Shape.GetArea() == trapezium1.Shape.GetArea() && trapezium.Material.Equals(trapezium1.Material));
        }

        /// <summary> Trapezium from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 2.5
        /// The cut figure is a trapezium with baseA = 3.0 and baseB = 1.5 and height = 2.0
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a trapezium. Try with a smaller trapezium. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a trapezium. Try with a smaller trapezium.")]
        public void SquareCutting_TrapeziumFromSquare_CutException()
        {
            // Arrange
            double side = 2.5;
            double baseA = 3.0;
            double baseB = 1.5;
            double height = 2.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            new Figure(square, new Trapezium(baseA, baseB, height));

            // Assert
        }

        /// <summary> Triangle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 10.5
        /// The cut figure is a triangle with sideA = 2.0 and sideB = 2.0 and sideC = 2.0
        /// </arrange>
        /// <assert> Cut triangle </assert>
        [TestMethod()]
        public void SquareCutting_TriangleFromSquare_MaterialPaper()
        {
            // Arrange
            double side = 10.5;
            double sideA = 2.0;
            double sideB = 2.0;
            double sideC = 2.0;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            Figure triangle = new Figure(square, new Triangle(sideA, sideB, sideC));

            // Assert
            Figure triangle1 = new Figure(new Triangle(sideA, sideB, sideC), new Paper());
            Assert.IsTrue(triangle.Shape.GetArea() == triangle1.Shape.GetArea() && triangle.Material.Equals(triangle1.Material));
        }

        /// <summary> Triangle from square. </summary>
        /// <arrange> 
        /// The original figure is a square with side = 1.5
        /// The cut figure is a triangle with sideA = 2.5 and sideB = 2.5 and sideC = 2.5
        /// </arrange>
        /// <assert> Cut exception: You can not cut such a triangle. Try with a smaller triangle. </assert>
        [TestMethod()]
        [ExpectedException(typeof(CutException),
                    "You can not cut such a triangle. Try with a smaller triangle.")]
        public void SquareCutting_TriangleFromSquare_CutException()
        {
            // Arrange
            double side = 1.5;
            double sideA = 2.5;
            double sideB = 2.5;
            double sideC = 2.5;

            // Action
            Figure square = new Figure(new Square(side), new Paper());
            new Figure(square, new Triangle(sideA, sideB, sideC));

            // Assert
        }
    }
}