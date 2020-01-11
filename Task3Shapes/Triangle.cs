using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;

namespace Task3Shapes
{
    /// <summary> Class describing an equilateral triangle. </summary>
    /// <seealso cref="Task3Shapes.Shape" />
    public class Triangle : Shape
    {
        /// <summary> Gets the side A. </summary>
        /// <value> The side A of the triangle. </value>
        public double SideA { get; private set; }

        /// <summary> Gets the side B. </summary>
        /// <value> The side B of the triangle. </value>
        public double SideB { get; private set; }

        /// <summary> Gets the side C. </summary>
        /// <value> The side C of the triangle. </value>
        public double SideC { get; private set; }

        /// <summary> Gets the height. </summary>
        /// <value> The height of the triangle. </value>
        public double Height { get; private set; }

        /// <summary> Radius of a circle inscribed in a triangle. </summary>
        private double circleRadius;

        /// <summary> Initializes a new instance of the <see cref="Triangle"/> class. </summary>
        /// <remarks> 
        /// When entering very large values for side A or/and side B or/and side C ​​when calculating the area or perimeter, 
        /// a situation is possible with obtaining the result in the form of double.Infinity
        /// </remarks>
        /// <param name="sideA"> The side A of the triangle. </param>
        /// <param name="sideB"> The side B of the triangle. </param>
        /// <param name="sideC"> The side C of the triangle. </param>
        /// <exception cref="ArgumentException"> The side A, side B, side C of the triangle can not be equal zero or be less than zero, also
        /// equilateral triangle sides should be equal. </exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            if (SideA <= 0.0 || SideB <= 0.0 || SideC <= 0.0)
            {
                throw new ArgumentException("The sideA, sideB, sideC of the triangle can not be equal zero or be less than zero.");
            }

            if (SideA != SideB || SideA != SideC || SideB != SideC)
            {
                throw new ArgumentException("Equilateral triangle sides should be equal.");
            }

            /// <summary> Calculation of the height of the triangle. </summary>
            Height = (Math.Sqrt(3.0) / 2.0) * SideA;

            /// <summary> Radius of a circle inscribed in a triangle. </summary>
            circleRadius = SideA / (2.0 * Math.Sqrt(3.0));

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
                    /// The radius of the inscribed circle of the original triangle must be greater or equal than to the radius of the cut circle. 
                    /// </summary>
                    if (circleRadius < circle.Radius)
                    {
                        throw new CutException("You can not cut such a circle. Try with a smaller circle.");
                    }
                    break;
                case Rectangle rectangle:
                    /// <summary> The angle of the equilateral triangle. </summary>
                    double angleA = 60;

                    /// <summary> 
                    /// The side A of the original triangle must be greater or equal than to the length of the cut rectangle. 
                    /// The angle A of the original triangle must be greater than or equal to the angle formed when inscribing the rectangle into the triangle. 
                    /// This is the angle A of a right triangle in which one cathet is 1/2(side A minus length of the rectangle) and the second
                    /// cathet is equal to the width of the rectangle. 
                    /// <remarks> 
                    /// The rectangle is placed in the triangle so that one of the lengths of the rectangle is on side A 
                    /// and the center point of the length of the rectangle is at the center point of side A. 
                    /// </remarks>
                    /// </summary>
                    if (SideA < rectangle.Length || angleA < (Math.Atan(rectangle.Width /
                        ((SideA - rectangle.Length) / 2.0)) * (180 / Math.PI)))
                    {
                        throw new CutException("You can not cut such a rectangle. Try with a smaller rectangle.");
                    }
                    break;
                case Square square:
                    /// <summary>
                    /// The allowable side of the square is defined as (SideA * Math.Sqrt(3.0)) / (2 + Math.Sqrt(3.0)))
                    /// </summary>
                    if ((SideA * Math.Sqrt(3.0)) / (2 + Math.Sqrt(3.0)) < square.Side)
                    {
                        throw new CutException("You can not cut such a square. Try with a smaller square.");
                    }
                    break;
                case Trapezium trapezium:
                    /// <summary>
                    /// The side A of the original triangle must be greater or equal than the base A of a trapezium
                    /// and side A may be less than the base A of a trapezium but angle A of the trapezium must be equal angle of the triangle.
                    /// </summary>
                    if (SideA < trapezium.BaseA || (SideA >= trapezium.BaseA && (60 < trapezium.AngleA)))
                    {
                        throw new CutException("You can not cut such a trapezium. Try with a smaller trapezium.");
                    }
                    break;
                case Triangle triangle:
                    /// <summary>
                    /// All sides of the original triangle and the cut triangle must be equal.
                    /// </summary>
                    if (SideA < triangle.SideA)
                    {
                        throw new CutException("You can not cut such a triangle. Try with a smaller triangle.");
                    }
                    break;
            }
        }

        /// <summary> Triangle area calculation. </summary>
        /// <returns> The triangle area. </returns>
        public override double GetArea()
        {
            return 0.5 * SideA * Height;
        }

        /// <summary> Triangle perimeter calculation. </summary>
        /// <returns> The triangle perimeter. </returns>
        public override double GetPerimeter()
        {
            return SideA + SideC + SideC;
        }

        /// <summary> Calculation of the radius of the circumscribed circle of the triangle. </summary>
        /// <returns> Radius of the circumscribed circle of the triangle. </returns>
        public double GetCircleRadius()
        {
            return SideA / Math.Sqrt(3.0);
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public override void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> The Tag 'Shape' </summary>
            xmlWriter.WriteStartElement("Shape");
            /// <summary> The tag 'Shape' value is 'Triangle' </summary>
            xmlWriter.WriteValue(ToString());
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'SideA' describe the shape. </summary>
            xmlWriter.WriteStartElement("SideA");
            /// <summary> The tag 'SideA' value. </summary>
            xmlWriter.WriteValue(SideA);
            xmlWriter.WriteEndElement();
            /// <summary> The Tag 'SideB' describe the shape. </summary>
            xmlWriter.WriteStartElement("SideB");
            /// <summary> The tag 'SideB' value. </summary>
            xmlWriter.WriteValue(SideB);
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'SideC' describe the shape. </summary>
            xmlWriter.WriteStartElement("SideC");
            /// <summary> The tag 'SideC' value. </summary>
            xmlWriter.WriteValue(SideC);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public override void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string shape = "    <Shape>" + ToString() + "</Shape>";
            string sideA = "    <SideA>" + SideA + "</SideA>";
            string sideB = "    <SideB>" + SideB + "</SideB>";
            string sideC = "    <SideC>" + SideC + "</SideC>";
            /// <summary> The tag 'Shape' with value as a string. </summary>
            streamWriter.WriteLine(shape);
            /// <summary> The tag 'SideA' with value as a string. </summary>
            streamWriter.WriteLine(sideA);
            /// <summary> The tag 'SideB' with value as a string. </summary>
            streamWriter.WriteLine(sideB);
            /// <summary> The tag 'SideC' with value as a string. </summary>
            streamWriter.WriteLine(sideC);
        }

        /// <summary> Represents a shape as a string. Overriden method. </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance. Return shape as string. </returns>
        public override string ToString()
        {
            return string.Format("Triangle");
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Triangle)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (Side A * 3))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = SideA.GetHashCode() * 3;
            hashCode = hash * hashCode + SideA.GetHashCode();
            return hashCode;
        }
    }
}