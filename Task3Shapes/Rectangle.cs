using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;

namespace Task3Shapes
{
    /// <summary> Class describing a rectangle. </summary>
    /// <seealso cref="Task3Shapes.Shape" />
    public class Rectangle : Shape
    {
        /// <summary> Gets the length. </summary>
        /// <value> The length of the rectangle. </value>
        public double Length { get; private set; }

        /// <summary> Gets the width. </summary>
        /// <value> The width of the rectangle. </value>
        public double Width { get; private set; }

        /// <summary> Initializes a new instance of the <see cref="Rectangle"/> class. </summary>
        /// <remarks> 
        /// When entering very large values for length or/and width ​​when calculating the area or perimeter, a situation is possible 
        /// with obtaining the result in the form of double.Infinity
        /// </remarks>
        /// <param name="length"> The length of the rectangle. </param>
        /// <param name="width"> The width of the rectangle. </param>
        /// <exception cref="ArgumentException">
        /// The length and width of the rectangle can not be equal and lenght should be more than width.
        /// or
        /// The length or width of the rectangle can not be equal zero or be less than zero.
        /// </exception>
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;

            if (Length <= Width)
            {
                throw new ArgumentException("The length and width of the rectangle can not be equal and" +
                    "length should be more than width.");
            }

            if (Length <= 0.0 || Width <= 0.0)
            {
                throw new ArgumentException("The length or width of the rectangle can not be equal zero or be less than zero.");
            }
        }

        /// <summary> Checking whether it is possible to cut the desired shape from the current shape. </summary>
        /// <remarks> 
        /// When checking the possibility of cutting, the figure is superimposed on the original 
        /// and is in a static state. 
        /// </remarks>
        /// <param name="shape"> Desired shape. </param>
        /// <exception cref="Exception">
        /// You can not cut such a circle. Try with a smaller circle.
        /// or
        /// You can not cut such a rectangle. Try with a smaller rectangle.
        /// or
        /// You can not cut such a square. Try with a smaller square.
        /// or
        /// You can not cut such a trapezium. Try with a smaller trapezium.
        /// or
        /// You can not cut such a triangle. Try with a smaller triangle.
        /// </exception>
        public override void CutCheck(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    /// <summary> 
                    /// The width of the original rectangle must be greater or equal than to the diameter of the cut circle. 
                    /// </summary>
                    if (Width < (circle.Radius * 2.0))
                    {
                        throw new CutException("You can not cut such a circle. Try with a smaller circle.");
                    }
                    break;
                case Rectangle rectangle:
                    /// <summary> 
                    /// The length of the original rectangle must be greater or equal than to the lenght of the cut rectangle. 
                    /// The width of the original rectangle must be greater or equal than to the width of the cut rectangle. 
                    /// </summary>
                    if (Length < rectangle.Length || Width < rectangle.Width)
                    {
                        throw new CutException("You can not cut such a rectangle. Try with a smaller rectangle.");
                    }
                    break;
                case Square square:
                    /// <summary> 
                    /// The width of the original rectangle must be greater or equal than to the side of the cut square. 
                    /// </summary>
                    if (Width < square.Side)
                    {
                        throw new CutException("You can not cut such a square. Try with a smaller square.");
                    }
                    break;
                case Trapezium trapezium:
                    /// <summary> 
                    /// The length of the original rectangle must be greater or equal than to the base A of the cut trapezium. 
                    /// The width of the original rectangle must be greater or equal than to the height of the cut trapezium. 
                    /// </summary>
                    if (Length < trapezium.BaseA || Width < trapezium.Height)
                    {
                        throw new CutException("You can not cut such a trapezium. Try with a smaller trapezium.");
                    }
                    break;
                case Triangle triangle:
                    /// <summary> 
                    /// The length of the original rectangle must be greater or equal than to the side A of the cut triangle. 
                    /// The width of the original rectangle must be greater or equal than to the height of the cut triangle. 
                    /// </summary>
                    if (Length < triangle.SideA || Width < triangle.Height)
                    {
                        throw new CutException("You can not cut such a triangle. Try with a smaller triangle.");
                    }
                    break;
            }
        }

        /// <summary> Rectangle area calculation. </summary>
        /// <returns> The rectangle area. </returns>
        public override double GetArea()
        {
            return Length * Width;
        }

        /// <summary> Rectangle perimeter calculation. </summary>
        /// <returns> The rectangle perimeter. </returns>
        public override double GetPerimeter()
        {
            return 2.0 * (Length + Width);
        }

        /// <summary> Calculation of the radius of the circumscribed circle of the rectangle. </summary>
        /// <returns> Radius of the circumscribed circle of the rectangle. </returns>
        public double GetCircleRadius()
        {
            return Math.Sqrt(Math.Pow(Length, 2.0) + Math.Pow(Width, 2.0)) / 2.0;
        }

        /// <summary>  Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public override void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> The Tag 'Shape' </summary>
            xmlWriter.WriteStartElement("Shape");
            /// <summary> The tag 'Shape' value is 'Rectangle' </summary>
            xmlWriter.WriteValue(ToString());
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'Length' describe the shape. </summary>
            xmlWriter.WriteStartElement("Length");
            /// <summary> The tag 'Length' value. </summary>
            xmlWriter.WriteValue(Length);
            xmlWriter.WriteEndElement();
            /// <summary> The Tag 'Width' describe the shape. </summary>
            xmlWriter.WriteStartElement("Width");
            /// <summary> The tag 'Width' value. </summary>
            xmlWriter.WriteValue(Width);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public override void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string shape = "    <Shape>" + ToString() + "</Shape>";
            string length = "    <Length>" + Length + "</Length>";
            string width = "    <Width>" + Width + "</Width>";
            /// <summary> The Tag 'Shape' with value as a string. </summary>
            streamWriter.WriteLine(shape);
            /// <summary> The tag 'Length' with value as a string. </summary>
            streamWriter.WriteLine(length);
            /// <summary> The tag 'Width' with value as a string. </summary>
            streamWriter.WriteLine(width);
        }

        /// <summary> Represents a shape as a string. Overriden method. </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance. Return shape as string. </returns>
        public override string ToString()
        {
            return string.Format("Rectangle");
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (Length, Width))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = Length.GetHashCode();
            hashCode = hash * hashCode + Width.GetHashCode();
            return hashCode;
        }
    }
}
