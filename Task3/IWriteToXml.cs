using System.Xml;
using System.IO;
namespace Task3
{
    /// <summary> Write to xml. </summary>
    public interface IWriteToXml
    {
        /// <summary> Writes to XML for XmlWriter. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        void WriteToXml(XmlWriter xmlWriter);
        /// <summary> Writes to XML for StreamWriter. </summary>
        /// <param name="streamWriter"> The StreamWriter instance. </param>
        void WriteToXml(StreamWriter streamWriter);
    }
}