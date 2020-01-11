using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;

namespace Task3Shapes
{
    /// <summary> Class describing a isosceles trapezium. </summary>
    /// <seealso cref="Task3Shapes.Shape" />
    public class Trapezium : Shape
    {
        /// <summary> Gets the base A. </summary>
        /// <value> The base A of the trapezium. </value>
        public double BaseA { get; private set; }
        /// <summary> Gets the base B. </summary>
        /// <value> The base B of the trapezium. </value>
        public double BaseB { get; private set; }
        /// <summary> Gets the side. </summary>
        /// <value> The side of the trapezium. </value>
        public double Side { get; private set; }
        /// <summary> Gets the height. </summary>
        /// <value> The height of the trapezium. </value>
        public double Height { get; private set; }
        /// <summary> Gets the angle A. </summary>
        /// <value> The angle A of the trapezium. </value>
        public double AngleA { get; private set; }

        /// <summary> Initializes a new instance of the <see cref="Trapezium"/> class. </summary>
        /// <remarks> 
        /// When entering very large values for base A or/and base B or/and height ​​when calculating the area or perimeter, 
        /// a situation is possible with obtaining the result in the form of double.Infinity
        /// </remarks>
        /// <param name="baseA"> The base A of the trapezium.</param>
        /// <param name="baseB"> The base B of the trapezium.</param>
        /// <param name="height"> The height of the trapezium.</param>
        /// <exception cref="ArgumentException"> The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.
        /// or
        /// The base A should be more than base B. </exception>
        public Trapezium(double baseA, double baseB, double height)
        {
            BaseA = baseA;
            BaseB = baseB;
            Height = height;

            if (BaseA <= 0.0 || BaseB <= 0.0 || Height <= 0.0)
            {
                throw new ArgumentException("The baseA or baseB or height of the trapezium can not be equal zero or be less than zero.");
            }

            if (BaseA <= BaseB)
            {
                throw new ArgumentException("The base A should be more than base B.");
            }

            /// <summary> Calculation of the side of the trapezium. </summary>
            Side = Math.Sqrt(Math.Pow(((BaseA - BaseB) / 2.0), 2.0) + Math.Pow(Height, 2.0));

            /// <summary> Calculation of the Angle A of the trapezium. </summary>
            AngleA = Math.Asin((Height / Side)) * (180 / Math.PI);

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
        /// You can not cut such a square. Try with a smaller rectangle.
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
                    /// The radius of the inscribed circle of the original trapezium must be greater 
                    /// or equal than to the radius of the cut circle. 
                    /// <remarks> The radius of the inscribed circle is half height of the trapezium. </remarks>
                    /// </summary>
                    if ((Height / 2) < circle.Radius)
                    {
                        throw new CutException("You can not cut such a circle. Try with a smaller circle.");
                    }
                    break;
                case Rectangle rectangle:
                    /// <summary>
                    /// The base B of the original trapezium must be greater or equal than to the lenght of the ractangle
                    /// and the height must be greater or equal of the width of the ractangle.
                    /// </summary>
                    if (BaseB < rectangle.Length || Height < rectangle.Width)
                    {
                        throw new CutException("You can not cut such a rectangle. Try with a smaller rectangle.");
                    }
                    break;
                case Square square:
                    /// <summary>
                    /// The base B of the original trapezium must be greater or equal than to the side of the square
                    /// and the height must be greater or equal of the side of the square.
                    /// </summary>
                    if (BaseB < square.Side || Height < square.Side)
                    {
                        throw new CutException("You can not cut such a squre. Try with a smaller rectangle.");
                    }
                    break;
                case Trapezium trapezium:
                    /// <summary>
                    /// The base A of the original trapezium must be greater or equal than to the base A of the cut trapezium
                    /// and the height must be greater or equal of the height of the cut trapezium
                    /// and the base B must be greater or equal of the base B of the cut trapezium, but if 
                    /// the angles of inclination of the side with respect to the base B are equal 
                    /// then the base B of the cut trapezium may be larger than the base B of the original trapezium.
                    /// </summary>
                    if (BaseA < trapezium.BaseA || Height < trapezium.Height || (BaseB < trapezium.BaseB & AngleA != trapezium.AngleA))
                    {
                        throw new CutException("You can not cut such a trapezium. Try with a smaller trapezium.");
                    }
                    break;
                case Triangle triangle:
                    /// <summary>
                    /// The base A of the original trapezium must be greater or equal than to the side A of the cut triangle
                    /// and the height must be greater or equal of the height of the cut triangle.
                    /// </summary>
                    if (BaseA < triangle.SideA || Height < triangle.Height)
                    {
                        throw new CutException("You can not cut such a triangle. Try with a smaller triangle.");
                    }
                    break;
            }
        }

        /// <summary> Trapezium area calculation. </summary>
        /// <returns> The trapezium area. </returns>
        public override double GetArea()
        {
            return ((BaseA + BaseB) / 2.0) * Height;
        }

        /// <summary> Trapezium perimeter calculation. </summary>
        /// <returns> The trapezium perimeter. </returns>
        public override double GetPerimeter()
        {
            return 2.0 * Side + BaseA + BaseB;
        }

        /// <summary> Trapezium diagonale calculation. </summary>
        /// <returns> The trapezium diagonale. </returns>
        public double GetDiagonale()
        {
            return Math.Sqrt(Math.Pow(Height, 2.0) + Math.Pow(((BaseA - BaseB) / 2.0), 2.0));
        }

        /// <summary> Trapezium half perimeter calculation. </summary>
        /// <returns> The trapezium half perimeter. </returns>
        public double GetHalfPerimeterTriangle()
        {
            return (Side + GetDiagonale() + BaseA) / 2.0;
        }

        /// <summary> Calculation of the radius of the circumscribed circle of the trapezium. </summary>
        /// <returns> Radius of the circumscribed circle of the trapezium. </returns>
        public double GetCircleRadius()
        {
            return (Side * GetDiagonale() * BaseA) / 4 * Math.Sqrt(GetHalfPerimeterTriangle() *
                (GetHalfPerimeterTriangle() - Side) * (GetHalfPerimeterTriangle() - GetDiagonale()) *
                (GetHalfPerimeterTriangle() - BaseA));
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public override void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> The Tag 'Shape' </summary>
            xmlWriter.WriteStartElement("Shape");
            /// <summary> The tag 'Shape' value is 'Trapezium' </summary>
            xmlWriter.WriteValue(ToString());
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'BaseA' describe the shape. </summary>
            xmlWriter.WriteStartElement("BaseA");
            /// <summary> The tag 'BaseA' value. </summary>
            xmlWriter.WriteValue(BaseA);
            xmlWriter.WriteEndElement();
            /// <summary> The Tag 'BaseB' describe the shape. </summary>
            xmlWriter.WriteStartElement("BaseB");
            /// <summary> The tag 'BaseB' value. </summary>
            xmlWriter.WriteValue(BaseB);
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'Height' describe the shape. </summary>
            xmlWriter.WriteStartElement("Height");
            /// <summary> The tag 'Height' value. </summary>
            xmlWriter.WriteValue(Height);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public override void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string shape = "    <Shape>" + ToString() + "</Shape>";
            string baseA = "    <BaseA>" + BaseA + "</BaseA>";
            string baseB = "    <BaseB>" + BaseB + "</BaseB>";
            string height = "    <Height>" + Height + "</Height>";
            /// <summary> The tag 'Shape' with value as a string. </summary>
            streamWriter.WriteLine(shape);
            /// <summary> The tag 'BaseA' with value as a string. </summary>
            streamWriter.WriteLine(baseA);
            /// <summary> The tag 'BaseB' with value as a string. </summary>
            streamWriter.WriteLine(baseB);
            /// <summary> The tag 'Height' with value as a string. </summary>
            streamWriter.WriteLine(height);
        }

        /// <summary> Represents a shape as a string. Overriden method. </summary>
        /// <returns> A <see cref="System.String"/> that represents this instance. Return shape as string. </returns>
        public override string ToString()
        {
            return string.Format("Trapezium");
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Trapezium)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (BaseA, BaseB, Heigth))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = BaseA.GetHashCode();
            hashCode = hash * hashCode + BaseB.GetHashCode();
            hashCode = hash * hashCode + Height.GetHashCode();
            return hashCode;
        }
    }
}
