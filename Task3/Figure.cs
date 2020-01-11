using System;
using System.Xml;
using System.IO;
using static Task3Shapes.ShapeException;
using Task3Shapes;

namespace Task3
{
    /// <summary> Сolors that can be used to color the figure. Implemented as enum. </summary>
    public enum Colors
    {
        /// <summary> Lack of color. </summary>
        Transparent,
        /// <summary> The white color. </summary>
        White,
        /// <summary> The green color. </summary>
        Green,
        /// <summary> The red color. </summary>
        Red,
        /// <summary> The blue color. </summary>
        Blue,
        /// <summary> The yellow color. </summary>
        Yellow,
        /// <summary> The orange color. </summary>
        Orange
        // Other colors
    }

    /// <summary> Class describing a figure. </summary>
    public class Figure : IWriteToXml
    {
        /// <summary> Gets the material. </summary>
        /// <value> The material of the figure. </value>
        public Material Material { get; private set; }

        /// <summary> Gets the shape of the figure. </summary>
        /// <value> The shape of the figure. </value>
        public Shape Shape { get; private set; }

        /// <summary> Variable indicating whether the figure was cut. </summary>
        private bool cutOut;

        /// <summary> Initializes a new instance of the <see cref="Figure"/> class. </summary>
        /// <param name="shape"> The shape of the figure. </param>
        /// <param name="material"> The material of the figure. </param>
        public Figure(Shape shape, Material material)
        {
            Shape = shape;
            Material = material;
            cutOut = false;
        }

        /// <summary> Paints a figure in a given color. </summary>
        /// <remarks> 
        /// A paper figure can only be painted once. 
        /// A film figure can not be painted.
        /// </remarks>
        /// <param name="color"> The color in which the figure will be painted. </param>
        /// <exception cref="Exception">
        /// You can paint a paper figure only once.
        /// or
        /// The film can not be painted. 
        /// </exception>
        public void Paint(Colors color)
        {
            Material.Paint(color);
        }

        /// <summary> Cuts a given shape. </summary>
        /// <param name="shape"> The required shape. </param>
        /// <param name="figure"> The original figure for cutting. </param>
        /// <returns> 
        /// If the shape can be cut, returns a new instance of the figure 
        /// with the specified parameters. </returns>
        /// <exception cref="Exception"> You can cut a figure only once. </exception>
        public Figure(Figure figure, Shape shape)
        {
            if (figure.cutOut == true)
            {
                throw new CutException("You can cut a figure only once.");
            }

            figure.Shape.CutCheck(shape);
            figure.cutOut = true;

            Shape = shape;
            Material = figure.Material;
            cutOut = false;
        }

        /// <summary> Writes figure to xml file. </summary>
        /// <param name="streamWriter"> The StreamWriter instance. </param>
        public void WriteToXml(StreamWriter streamWriter)
        {
            /// <summary> Markup creation. </summary>
            string material = "    <Material>" + Material.GetMaterialAsString() + "</Material>";
            string color = "    <Color>" + Convert.ToString(Material.Color) + "</Color>";
            /// <summary> Root tag 'Figure' </summary>
            streamWriter.WriteLine("  <Figure>");
            /// <summary> Tag 'Material' with value as a string. </summary>
            streamWriter.WriteLine(material);
            /// <summary> Tag 'Color' with value as a string </summary>
            streamWriter.WriteLine(color);
            /// <summary>  Call the Shape.WriteToXml method <see cref="Shape.WriteToXml(StreamWriter)"/> </summary>
            Shape.WriteToXml(streamWriter);
            streamWriter.WriteLine("  </Figure>");
        }

        /// <summary> Writes figure to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public void WriteToXml(XmlWriter xmlWriter)
        {
            /// <summary> Root tag 'Figure' </summary>
            xmlWriter.WriteStartElement("Figure");
            /// <summary> The Tag 'Material' </summary>
            xmlWriter.WriteStartElement("Material");
            /// <summary> The tag 'Material' value as a string. </summary>
            xmlWriter.WriteValue(Material.GetMaterialAsString());
            xmlWriter.WriteEndElement();
            /// <summary> Tag 'Color' </summary>
            xmlWriter.WriteStartElement("Color");
            /// <summary> The tag 'Color' value as a string. </summary>
            xmlWriter.WriteValue(Convert.ToString(Material.Color));
            xmlWriter.WriteEndElement();
            /// <summary>  Call the Shape.WriteToXml method <see cref="Shape.WriteToXml(XmlWriter)"/> </summary>
            Shape.WriteToXml(xmlWriter);
            xmlWriter.WriteEndElement();
        }

        /// <summary> Represents a figure as a string. Overriden method. </summary>
        /// <returns> A <see cref="System.String" /> that represents this instance. </returns>
        public override string ToString()
        {
            return string.Format("Shape: {0}, material: {1}, color: {2}", Shape, Material, Material.Color);
        }

        /// <summary> Determines whether the specified <see cref="System.Object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="System.Object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Figure)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hashCode * hash + (variable hash code (Shape, Color, Material))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = Shape.GetHashCode();
            hashCode = hash * hashCode + Material.Color.GetHashCode();
            hashCode = hash * hashCode + Material.GetHashCode();
            return hashCode;
        }
    }
}