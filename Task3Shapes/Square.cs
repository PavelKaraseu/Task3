using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;

namespace Task3Shapes
{
    /// <summary> Class describing a square. </summary>
    /// <seealso cref="Task3Shapes.Shape" />
    public class Square : Shape
    {
        /// <summary> Gets the side. </summary>
        /// <value> The side of the square. </value>
        public double Side { get; private set; }

        /// <summary> Initializes a new instance of the <see cref="Square"/> class. </summary>
        /// <remarks> 
        /// When entering very large values for side ​​when calculating the area or perimeter, a situation is possible 
        /// with obtaining the result in the form of double.Infinity
        /// </remarks>
        /// <param name="side"> The side of the square. </param>
        /// <exception cref="ArgumentException"> The side of the square can not be equal zero or be less than zero. </exception>
        public Square(double side)
        {
            Side = side;

            if (Side <= 0.0)
            {
                throw new ArgumentException("The side of the square can not be equal zero or be less than zero.");
            }
        }

        /// <summary> Checking whether it is possible to cut the desired shape from the current shape. </summary>
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
                    /// The side of the original square must be greater or equal than to the diameter of the cut circle. 
                    /// </summary>
                    if (Side < (circle.Radius * 2.0))
                    {
                        throw new CutException("You can not cut such a circle. Try with a smaller circle.");
                    }
                    break;
                case Rectangle rectangle:
                    /// <summary> 
                    /// The side of the original square must be greater or equal than to the length of the cut rectangle. 
                    /// </summary>
                    if (Side < rectangle.Length)
                    {
                        throw new CutException("You can not cut such a rectangle. Try with a smaller rectangle.");
                    }
                    break;
                case Square square:
                    /// <summary> 
                    /// The side of the original square must be greater or equal than to the side of the cut square. 
                    /// </summary>
                    if (Side < square.Side)
                    {
                        throw new CutException("You can not cut such a square. Try with a smaller square.");
                    }
                    break;
                case Trapezium trapezium:
                    /// <summary> 
                    /// The side of the original square must be greater or equal than 
                    /// to the base A and height of the cut trapezium. 
                    /// </summary>
                    if (Side < trapezium.BaseA || Side < trapezium.Height)
                    {
                        throw new CutException("You can not cut such a trapezium. Try with a smaller trapezium.");
                    }
                    break;
                case Triangle triangle:
                    /// <summary> 
                    /// The side of the original square must be greater or equal than 
                    /// to the side A and height of the cut triangle. 
                    /// </summary>
                    if (Side < triangle.SideA || Side < triangle.Height)
                    {
                        throw new CutException("You can not cut such a triangle. Try with a smaller triangle.");
                    }
                    break;
            }
        }

        /// <summary> Square area calculation. </summary>
        /// <returns> The square area. </returns>
        public override double GetArea()
        {
            return Side * Side;
        }

        /// <summary> Square perimeter calculation. </summary>
        /// <returns> The square perimeter. </returns>
        public override double GetPerimeter()
        {
            return 4.0 * Side;
        }

        /// <summary> Calculation of the radius of the circumscribed circle of the square. </summary>
        /// <returns> Radius of the circumscribed circle of the square. </returns>
        public double GetCircleRadius()
        {
            return Side / Math.Sqrt(2.0);
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public override void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> Tag 'Shape' </summary>
            xmlWriter.WriteStartElement("Shape");
            /// <summary> The tag 'Shape' value is 'Square' </summary>
            xmlWriter.WriteValue(ToString());
            xmlWriter.WriteEndElement();
            /// <summary> The Tag 'Side' describe the shape. </summary>
            xmlWriter.WriteStartElement("Side");
            /// <summary> The tag 'Side' value. </summary>
            xmlWriter.WriteValue(Side);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public override void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string shape = "    <Shape>" + ToString() + "</Shape>";
            string side = "    <Side>" + Side + "</Side>";
            /// <summary> The tag 'Shape' with value as a string. </summary>
            streamWriter.WriteLine(shape);
            /// <summary> The tag 'Side' with value as a string. </summary>
            streamWriter.WriteLine(side);
        }

        /// <summary> Represents a shape as a string. Overriden method. </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance. Return shape as string. </returns>
        public override string ToString()
        {
            return string.Format("Square");
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Square)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (Side))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = Side.GetHashCode();
            hashCode = hash * hashCode + Side.GetHashCode();
            return hashCode;
        }
    }
}