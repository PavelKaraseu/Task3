using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3Shapes;

namespace Task3.Tests
{
    /// <summary> Class testing the figure box. </summary>
    [TestClass()]
    public class FiguresBoxTests
    {
        /// <summary> FigureBox instance. </summary>
        FiguresBox figuresBox = FiguresBox.GetInstance();

        /// <summary> Add figure. </summary>
        /// <arrange> 
        /// Instance of figure
        /// </arrange>
        /// <assert> Figure added to box. </assert>
        [TestMethod()]
        public void FiguresBox_AddFigure()
        {
            // Arrange
            Figure circle = new Figure(new Circle(2.0), new Paper());

            // Action
            figuresBox.ClearBox();
            figuresBox.AddFigure(circle);

            // Assert
            int quantityFigures = figuresBox.ShowQuantityFigures();
            Assert.IsTrue(quantityFigures != 0);
        }

        /// <summary> Add more than 20 figures. </summary>
        /// <arrange> 
        /// Instance of figure
        /// </arrange>
        /// <assert> Exception: The box is full. Remove figures and try again. </assert>
        [TestMethod()]
        [ExpectedException(typeof(Exception),
                    "The box is full. Remove figures and try again.")]
        public void FiguresBox_AddFigureMoreThan20_Exception()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure square = new Figure(new Square(3.0), new Paper());
            Figure square1 = new Figure(new Square(3.0), new Film());
            Figure square2 = new Figure(new Square(3.0), new Paper());
            square2.Paint(Colors.Blue);
            Figure square3 = new Figure(new Square(3.0), new Paper());
            square3.Paint(Colors.Red);
            Figure square4 = new Figure(new Square(3.0), new Paper());
            square4.Paint(Colors.Green);
            Figure square5 = new Figure(new Square(3.0), new Paper());
            square5.Paint(Colors.Yellow);
            Figure square6 = new Figure(new Square(3.0), new Paper());
            square6.Paint(Colors.Orange);
            //Figure circle = new Figure(new Circle(2.0), Materials.Paper);
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure circle2 = new Figure(new Circle(2.0), new Paper());
            circle2.Paint(Colors.Blue);
            Figure circle3 = new Figure(new Circle(2.0), new Paper());
            circle3.Paint(Colors.Green);
            Figure circle4 = new Figure(new Circle(2.0), new Paper());
            circle4.Paint(Colors.Red);
            Figure circle5 = new Figure(new Circle(2.0), new Paper());
            circle5.Paint(Colors.Yellow);
            Figure circle6 = new Figure(new Circle(2.0), new Paper());
            circle6.Paint(Colors.Orange);
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Paper());
            Figure rectangle1 = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure rectangle2 = new Figure(new Rectangle(2.0, 1.0), new Paper());
            rectangle2.Paint(Colors.Blue);
            Figure rectangle3 = new Figure(new Rectangle(2.0, 1.0), new Paper());
            rectangle3.Paint(Colors.Red);
            Figure rectangle4 = new Figure(new Rectangle(2.0, 1.0), new Paper());
            rectangle4.Paint(Colors.Yellow);
            Figure rectangle5 = new Figure(new Rectangle(2.0, 1.0), new Paper());
            rectangle5.Paint(Colors.Orange);
            Figure rectangle6 = new Figure(new Rectangle(2.0, 1.0), new Paper());
            rectangle6.Paint(Colors.Green);
            Figure trapezium = new Figure(new Trapezium(2.0, 1.0, 1.0), new Paper());
            Figure trapezium1 = new Figure(new Trapezium(2.0, 1.0, 1.0), new Film());
            Figure triangle = new Figure(new Triangle(2.0, 2.0, 2.0), new Paper());

            // Action
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(circle2);
            figuresBox.AddFigure(circle3);
            figuresBox.AddFigure(circle4);
            figuresBox.AddFigure(circle5);
            figuresBox.AddFigure(circle6);
            figuresBox.AddFigure(square);
            figuresBox.AddFigure(square1);
            figuresBox.AddFigure(square2);
            figuresBox.AddFigure(square3);
            figuresBox.AddFigure(square4);
            figuresBox.AddFigure(square5);
            figuresBox.AddFigure(square6);
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(rectangle1);
            figuresBox.AddFigure(rectangle2);
            figuresBox.AddFigure(rectangle3);
            figuresBox.AddFigure(rectangle4);
            figuresBox.AddFigure(rectangle5);
            figuresBox.AddFigure(rectangle6);
            figuresBox.AddFigure(trapezium);
            figuresBox.AddFigure(trapezium1);

            // Assert
        }

        /// <summary> Add a figure to a box that already exists </summary>
        /// <arrange> 
        /// Instance of figure
        /// </arrange>
        /// <assert> Exception: The figure with such characteristics already exists. </assert>
        [TestMethod()]
        [ExpectedException(typeof(Exception),
                    "The figure with such characteristics already exists.")]
        public void FiguresBox_AddFigureWithSameCharacteristics_Exception()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure square = new Figure(new Square(3.0), new Paper());
            Figure square1 = new Figure(new Square(3.0), new Paper());
            // Action
            figuresBox.AddFigure(square);
            figuresBox.AddFigure(square1);

            // Assert
        }

        /// <summary> Show figure by number. </summary>
        /// <arrange> 
        /// Instance of figure
        /// </arrange>
        /// <assert> Figure by number </assert>
        [TestMethod()]
        public void FiguresBox_ShowFigureByNumber()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure circle = new Figure(new Circle(2.0), new Paper());

            // Action
            figuresBox.AddFigure(circle);

            // Assert
            Figure circle1 = figuresBox.ShowFigureByNumber(0);
            Assert.IsTrue(circle.Shape.GetArea() == circle1.Shape.GetArea() && circle.Material == circle1.Material);
        }

        /// <summary> Remove figure by number. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Remove figure by number </assert>
        [TestMethod()]
        public void FiguresBox_RemoveFigureByNumber()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure circle = new Figure(new Circle(2.0), new Paper());
            Figure square = new Figure(new Square(3.2), new Film());

            // Action
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            Figure number0 = figuresBox.ShowFigureByNumber(0);
            Figure number1 = figuresBox.ShowFigureByNumber(1);
            figuresBox.RemoveFigureByNumber(0);
            Figure number2 = figuresBox.ShowFigureByNumber(1);
            // Assert
            int quantityFigures = figuresBox.ShowQuantityFigures();
            Assert.IsTrue(quantityFigures == 1 && number2.Shape.ToString() == "Square");
        }

        /// <summary> Remove nonexistent figure. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Exception: Figures with this number do not exist. </assert>
        [TestMethod()]
        [ExpectedException(typeof(Exception),
                    "Figures with this number do not exist.")]
        public void FiguresBox_RemoveFigureByNumber_Exception()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure circle = new Figure(new Circle(2.0), new Paper());
            Figure square = new Figure(new Square(3.2), new Film());

            // Action
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            Figure number0 = figuresBox.ShowFigureByNumber(0);
            Figure number1 = figuresBox.ShowFigureByNumber(1);
            figuresBox.RemoveFigureByNumber(5);
            Figure number2 = figuresBox.ShowFigureByNumber(0);
            // Assert
        }

        /// <summary> Remove all circles. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Remove all circles </assert>
        [TestMethod()]
        public void FiguresBox_RemoveAllCircles()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure circle = new Figure(new Circle(2.0), new Paper());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure circle2 = new Figure(new Circle(2.0), new Paper());
            circle2.Paint(Colors.Green);
            Figure square = new Figure(new Square(3.2), new Film());

            // Action
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(circle2);
            figuresBox.AddFigure(square);
            figuresBox.RemoveAllCircles();
            Figure figure = figuresBox.ShowFigureByNumber(0);
            // Assert
            int quantityFigures = figuresBox.ShowQuantityFigures();
            Assert.IsTrue(quantityFigures == 1 && figure == null);
        }

        /// <summary> Remove all film figures. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Remove all film figures. </assert>
        [TestMethod()]
        public void FiguresBox_RemoveAllFilmFigure()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(square);
            figuresBox.RemoveAllFilmFigures();
            Figure figure = figuresBox.ShowFigureByNumber(0);
            // Assert
            int quantityFigures = figuresBox.ShowQuantityFigures();
            Assert.IsTrue(quantityFigures == 1 && figure == null);
        }

        /// <summary> Replace figure by number. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Replace figure by number. </assert>
        [TestMethod()]
        public void FiguresBox_ReplaceFigureByNumber()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(square);
            figuresBox.ReplaceFigureByNumber(new Figure(new Triangle(2.0, 2.0, 2.0), new Paper()), 1);
            Figure figure = figuresBox.ShowFigureByNumber(1);
            // Assert
            int quantityFigures = figuresBox.ShowQuantityFigures();
            Assert.IsTrue(figure.Shape.ToString() == "Triangle");
        }

        /// <summary> Find equivalent figure. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Find equivalent figure. </assert>
        [TestMethod()]
        public void FiguresBox_FindEquivalentFigure()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(square);
            Figure figure = figuresBox.FindEquivalentFigure(new Figure(new Circle(3.0), new Film()));
            // Assert
            Assert.IsTrue(figure.Shape.ToString() == "Circle");
        }

        /// <summary> Find equivalent figure. No equivalent figure found </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Exception: Equivalent figure not found </assert>
        [TestMethod()]
        [ExpectedException(typeof(Exception),
                    "Equivalent figure not found.")]
        public void FiguresBox_FindEquivalentFigure_Exception()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(square);
            Figure figure = figuresBox.FindEquivalentFigure(new Figure(new Trapezium(3.0, 2.0, 1.5), new Film()));
            // Assert
        }

        /// <summary> Show quantity figures. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Quantity figures. </assert>
        [TestMethod()]
        public void FiguresBox_ShowQuantityFigures()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle1 = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle1);
            figuresBox.AddFigure(square);
            int quantityFigures = figuresBox.ShowQuantityFigures();
            // Assert
            Assert.IsTrue(quantityFigures == 3);
        }

        /// <summary> Get total area. </summary>
        /// <arrange> 
        /// Instance of figures
        /// </arrange>
        /// <assert> Total area. </assert>
        [TestMethod()]
        public void FiguresBox_GetTotalArea()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            double area1 = rectangle.Shape.GetArea();
            double area2 = circle.Shape.GetArea();
            double area3 = square.Shape.GetArea();
            double totalArea = figuresBox.GetTotalArea();
            // Assert
            Assert.IsTrue(totalArea == (area1 + area2 + area3));
        }

        /// <summary> Get total perimeter. </summary>
        /// <arrange> 
        /// Instances of figures.
        /// </arrange>
        /// <assert> Total perimeter. </assert>
        [TestMethod()]
        public void FiguresBox_GetTotalPerimeter()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle = new Figure(new Circle(2.0), new Film());
            Figure square = new Figure(new Square(3.2), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            double perimeter1 = rectangle.Shape.GetPerimeter();
            double perimeter2 = circle.Shape.GetPerimeter();
            double perimeter3 = square.Shape.GetPerimeter();
            double totalPerimeter = figuresBox.GetTotalPerimeter();
            // Assert
            Assert.IsTrue(totalPerimeter == (perimeter1 + perimeter2 + perimeter3));
        }

        /// <summary> Write to Xml with XmlWriter and read from Xml with streamReader. </summary>
        /// <arrange> 
        /// Instances of figures.
        /// </arrange>
        /// <assert> Read/Write. </assert>
        [TestMethod()]
        public void FiguresBox_WriteXmlWriter_ReadStreamReader()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle = new Figure(new Circle(2.0), new Paper());
            circle.Paint(Colors.Red);
            Figure square = new Figure(new Square(3.2), new Paper());
            Figure triangle = new Figure(new Triangle(2.2, 2.2, 2.2), new Paper());
            triangle.Paint(Colors.Blue);
            Figure trapezium = new Figure(new Trapezium(3.0, 2.0, 1.5), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            figuresBox.AddFigure(triangle);
            figuresBox.AddFigure(trapezium);
            XmlWritingReading.WriteToXmlWithXmlWriter(figuresBox);
            int afterWriting = figuresBox.ShowQuantityFigures();
            XmlWritingReading.ReadFromXmlWithStreamReader(figuresBox);
            int afterReading = figuresBox.ShowQuantityFigures();
            // Assert
            Assert.IsTrue(afterWriting == 0 && afterReading == 5 &&
                figuresBox.ShowFigureByNumber(0).Shape.ToString() == "Rectangle" &&
                figuresBox.ShowFigureByNumber(3).Shape.ToString() == "Triangle");
        }

        /// <summary> Write to Xml with StreamWriter and read from Xml with XmlReader. </summary>
        /// <arrange> 
        /// Instances of figures.
        /// </arrange>
        /// <assert> Read/Write. </assert>
        [TestMethod()]
        public void FiguresBox_WriteStreamWriter_ReadXmlReader()
        {
            // Arrange
            figuresBox.ClearBox();
            Figure rectangle = new Figure(new Rectangle(2.0, 1.0), new Film());
            Figure circle = new Figure(new Circle(2.0), new Paper());
            circle.Paint(Colors.Red);
            Figure square = new Figure(new Square(3.2), new Paper());
            Figure triangle = new Figure(new Triangle(2.2, 2.2, 2.2), new Paper());
            triangle.Paint(Colors.Blue);
            Figure trapezium = new Figure(new Trapezium(3.0, 2.0, 1.5), new Paper());

            // Action
            figuresBox.AddFigure(rectangle);
            figuresBox.AddFigure(circle);
            figuresBox.AddFigure(square);
            figuresBox.AddFigure(triangle);
            figuresBox.AddFigure(trapezium);
            XmlWritingReading.WriteToXmlWithStreamWriter(figuresBox);
            int afterWriting = figuresBox.ShowQuantityFigures();
            XmlWritingReading.ReadFromXmlWithXmlReader(figuresBox);
            int afterReading = figuresBox.ShowQuantityFigures();
            // Assert
            Assert.IsTrue(afterWriting == 0 && afterReading == 5 &&
                figuresBox.ShowFigureByNumber(0).Shape.ToString() == "Rectangle" &&
                figuresBox.ShowFigureByNumber(3).Shape.ToString() == "Triangle");
        }
    }
}