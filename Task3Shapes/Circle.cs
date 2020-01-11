using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;

namespace Task3Shapes
{
    /// <summary> Class describing a circle. </summary>
    /// <seealso cref="Task3Shapes.Shape" />
    public class Circle : Shape
    {
        /// <summary> Gets the radius. </summary>
        /// <value> The radius of the circle. </value>
        public double Radius { get; private set; }

        /// <summary> Initializes a new instance of the <see cref="Circle"/> class. </summary>
        /// <remarks> 
        /// When entering very large values for radius ​​when calculating the area or perimeter, a situation is possible 
        /// with obtaining the result in the form of double.Infinity
        /// </remarks>
        /// <param name="radius"> The radius of the circle. </param>
        /// <exception cref="ArgumentException"> The radius of the circle can not be equal zero or be less than zero. </exception>
        public Circle(double radius)
        {
            Radius = radius;

            if (radius <= 0.0)
            {
                throw new ArgumentException("The radius of the circle can not be equal zero or be less than zero.");
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
                    /// The radius of the original circle must be greater or equal than to the radius of the cut circle. 
                    /// </summary>
                    if (Radius < circle.Radius)
                    {
                        throw new CutException("You can not cut such a circle. Try with a smaller circle.");
                    }
                    break;
                case Rectangle rectangle:
                    /// <summary>
                    /// The radius of the original circle must be greater or equal than to the radius of the circle 
                    /// described around the rectangle.
                    /// </summary>
                    if (Radius < rectangle.GetCircleRadius())
                    {
                        throw new CutException("You can not cut such a rectangle. Try with a smaller rectangle.");
                    }
                    break;
                case Square square:
                    /// <summary>
                    /// The radius of the original circle must be greater or equal than to the radius of the circle 
                    /// described around the square.
                    /// </summary>
                    if (Radius < square.GetCircleRadius())
                    {
                        throw new CutException("You can not cut such a square. Try with a smaller square.");
                    }
                    break;
                case Trapezium trapezium:
                    /// <summary>
                    /// The radius of the original circle must be greater or equal than to the radius of the circle 
                    /// described around the isosceles trapezium.
                    /// </summary>
                    if (Radius < trapezium.GetCircleRadius())
                    {
                        throw new CutException("You can not cut such a trapezium. Try with a smaller trapezium.");
                    }
                    break;
                case Triangle triangle:
                    /// <summary>
                    /// The radius of the original circle must be greater or equal than to the radius of the circle 
                    /// described around the equilateral triangle.
                    /// </summary>
                    if (Radius < triangle.GetCircleRadius())
                    {
                        throw new CutException("You can not cut such a triangle. Try with a smaller triangle.");
                    }
                    break;
            }
        }

        /// <summary> Сircle area calculation. </summary>
        /// <returns> The circle area. </returns>
        public override double GetArea()
        {
            return Math.PI * (Radius * Radius);
        }

        /// <summary> Сircle perimeter calculation. </summary>
        /// <returns> The circle perimeter. </returns>
        public override double GetPerimeter()
        {
            return 2.0 * Math.PI * Radius;
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public override void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> The Tag 'Shape' </summary>
            xmlWriter.WriteStartElement("Shape");
            /// <summary> The tag 'Shape' value is 'Circle' </summary>
            xmlWriter.WriteValue(ToString());
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'Radius' describe the shape. </summary>
            xmlWriter.WriteStartElement("Radius");
            /// <summary> The tag 'Radius' value. </summary>
            xmlWriter.WriteValue(Radius);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public override void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string shape = "    <Shape>" + ToString() + "</Shape>";
            string radius = "    <Radius>" + Radius + "</Radius>";
            /// <summary> The Tag 'Shape' with value as a string. </summary>
            streamWriter.WriteLine(shape);
            /// <summary> The Tag 'Radius' describe the shape with value as a string. </summary>
            streamWriter.WriteLine(radius);
        }

        /// <summary> Represents a shape as a string. Overriden method. </summary>
        /// <returns> A <see cref="System.String"/> that represents this instance. Return shape as string. </returns>
        public override string ToString()
        {
            return string.Format("Circle");
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Circle)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (Radius))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = Radius.GetHashCode();
            hashCode = hash * hashCode + Radius.GetHashCode();
            return hashCode;
        }
    }
}
