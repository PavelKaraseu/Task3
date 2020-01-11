using System.Xml;
using System.IO;

namespace Task3Shapes
{
    /// <summary> An abstract class for describing the shape of a figure. </summary>
    public abstract class Shape
    {
        /// <summary> Gets the area. </summary>
        /// <returns> Area of some shape. </returns>
        public abstract double GetArea();

        /// <summary> Gets the perimeter. </summary>
        /// <returns> Perimeter of some shape. </returns>
        public abstract double GetPerimeter();

        /// <summary> Checking whether it is possible to cut the desired shape from the current shape. </summary>
        /// <returns> True, if possible, false if not. </returns>
        public abstract void CutCheck(Shape shape);

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public abstract void WriteToXml(XmlWriter xmlWriter);

        /// <summary> Writes shape to xml file. </summary>
        /// <param name="streamWriter"> The streamWriter instance. </param>
        public abstract void WriteToXml(StreamWriter streamWriter);
    }
}
