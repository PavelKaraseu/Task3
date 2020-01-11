using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using Task3Shapes;

namespace Task3
{
    /// <summary> Class for writing/reading XML file. </summary>
    public static class XmlWritingReading
    {
        /// <summary> Writes shapes out of the box to an xml file with XmlWriter. </summary>
        public static void WriteToXmlWithXmlWriter(IWriteToXml writeToXml, string path = @"..\..\Figures.xml")
        {
            /// <summary> Definition of settings. </summary>
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(path, settings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Figures");

            /// <summary> Markup is created for each shape. </summary>
            /// <see cref="IWriteToXml.WriteToXml(XmlWriter)"/>
            writeToXml.WriteToXml(xmlWriter);

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        /// <summary> Writes shapes out of the box to an xml file with StreamWriter. </summary>
        public static void WriteToXmlWithStreamWriter(IWriteToXml writeToXml, string path = @"..\..\Figures.xml")
        {
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("<?xml version=" + @"""1.0""" + " encoding=" + @"""utf-8""" + "?>");
            streamWriter.WriteLine("<Figures>");

            /// <summary> Markup is created for each shape. </summary>
            /// <see cref="IWriteToXml.WriteToXml(StreamWriter)"/>
            writeToXml.WriteToXml(streamWriter);
            streamWriter.WriteLine("</Figures>");
            streamWriter.Close();
        }

        /// <summary> Read shapes from xml file with XmlReader. 
        /// The values ​​are read from the tags and, depending on the shape of the figure, 
        /// an instance of the corresponding figure is created and placed in a box.
        /// </summary>
        public static void ReadFromXmlWithXmlReader(FiguresBox figuresBox, string path = @"..\..\Figures.xml")
        {
            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                xmlReaderSettings.DtdProcessing = DtdProcessing.Parse;
                try
                {
                    xmlReader.MoveToContent();
                }
                catch
                {
                    throw new Exception("Xml file does not contain figures.");
                }

                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Figure"))
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(xmlReader.ReadOuterXml());
                        /// <summary> Root node. </summary>
                        XmlNode node = xmlDocument.SelectSingleNode("Figure");
                        /// <summary> The color of the figure. Convert from string to enum view. </summary>
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(node.SelectSingleNode("Color").InnerText));
                        /// <summary> The material of the figure. Convert from string to enum view. </summary>
                        string material = Convert.ToString(node.SelectSingleNode("Material").InnerText);
                        /// <summary> Represents the shape of a figure</summary>
                        string shape = node.SelectSingleNode("Shape").InnerText;

                        /// <summary> The figure material. </summary>
                        Material figureMaterial = null;

                        if (material == "Film")
                        {
                            figureMaterial = new Film();
                        }
                        else if (material == "Paper")
                        {
                            figureMaterial = new Paper();
                        }

                        /// <summary> 
                        /// For each figure, its own parameters are extracted and the corresponding instance is created.
                        /// It is also checked whether the figure is painted.
                        /// </summary>
                        switch (shape)
                        {
                            case "Circle":
                                double radius = Convert.ToDouble(node.SelectSingleNode("Radius").InnerText);
                                Figure circle = new Figure(new Circle(radius), figureMaterial);
                                if (color != Colors.Transparent && color != Colors.White)
                                {
                                    circle.Paint(color);
                                }
                                figuresBox.AddFigure(circle);
                                break;
                            case "Rectangle":
                                double length = Convert.ToDouble(node.SelectSingleNode("Length").InnerText);
                                double width = Convert.ToDouble(node.SelectSingleNode("Width").InnerText);
                                Figure rectangle = new Figure(new Rectangle(length, width), figureMaterial);
                                if (color != Colors.Transparent && color != Colors.White)
                                {
                                    rectangle.Paint(color);
                                }
                                figuresBox.AddFigure(rectangle);
                                break;
                            case "Square":
                                double side = Convert.ToDouble(node.SelectSingleNode("Side").InnerText);
                                Figure square = new Figure(new Square(side), figureMaterial);
                                if (color != Colors.Transparent && color != Colors.White)
                                {
                                    square.Paint(color);
                                }
                                figuresBox.AddFigure(square);
                                break;
                            case "Trapezium":
                                double baseA = Convert.ToDouble(node.SelectSingleNode("BaseA").InnerText);
                                double baseB = Convert.ToDouble(node.SelectSingleNode("BaseB").InnerText);
                                double height = Convert.ToDouble(node.SelectSingleNode("Height").InnerText);
                                Figure trapeze = new Figure(new Trapezium(baseA, baseB, height), figureMaterial);
                                if (color != Colors.Transparent && color != Colors.White)
                                {
                                    trapeze.Paint(color);
                                }
                                figuresBox.AddFigure(trapeze);
                                break;
                            case "Triangle":
                                double sideA = Convert.ToDouble(node.SelectSingleNode("SideA").InnerText);
                                double sideB = Convert.ToDouble(node.SelectSingleNode("SideB").InnerText);
                                double sideC = Convert.ToDouble(node.SelectSingleNode("SideC").InnerText);
                                Figure triangle = new Figure(new Triangle(sideA, sideB, sideC), figureMaterial);
                                if (color != Colors.Transparent && color != Colors.White)
                                {
                                    triangle.Paint(color);
                                }
                                figuresBox.AddFigure(triangle);
                                break;
                        }
                    }
                }
            }
            /// <summary> Сleaning the file after putting the figures in the box. </summary>
            XmlWriter xmlWriter = XmlWriter.Create(path);
            xmlWriter.Close();
        }

        /// <summary> Read shapes from xml file with StreamReader.
        /// The values ​​are read from the tags and, depending on the shape of the figure, 
        /// an instance of the corresponding figure is created and placed in a box.
        /// </summary>
        public static void ReadFromXmlWithStreamReader(FiguresBox figuresBox, string path = @"..\..\Figures.xml")
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                /// <summary> String from xml file. </summary>
                string line;
                /// <summary> Tag name which contains the necessary data. </summary>
                string TagName = "Material";
                /// <summary> An auxiliary list that will store the contents of tags. </summary>
                List<string> tempFigureList = new List<string>();

                while ((line = streamReader.ReadLine()) != null)
                {
                    /// <summary> Using a regular expression, the contents of the tag named 'TagName' is retrieved. </summary>
                    string value = new Regex(string.Format(@"<{0}>(.*?)</{0}>", TagName), RegexOptions.IgnoreCase).Match(line).Groups[1].Value;

                    if (value != "" && TagName == "Material")
                    {
                        /// <summary> The contents of the tag 'Material' </summary>
                        tempFigureList.Add(value);
                        TagName = "Color";
                        value = "";
                    }
                    if (value != "" && TagName == "Color")
                    {
                        /// <summary> The contents of the tag 'Color' </summary>
                        tempFigureList.Add(value);
                        TagName = "Shape";
                        value = "";
                    }
                    if (value != "" && TagName == "Shape")
                    {
                        /// <summary> The contents of the tag 'Shape' </summary>
                        tempFigureList.Add(value);
                        string s = tempFigureList[2];
                        /// <summary> The name of the next tag is determined by the shape of the figure. </summary>
                        switch (s)
                        {
                            case "Circle":
                                TagName = "Radius";
                                value = "";
                                break;
                            case "Rectangle":
                                TagName = "Length";
                                value = "";
                                break;
                            case "Square":
                                TagName = "Side";
                                value = "";
                                break;
                            case "Trapezium":
                                TagName = "BaseA";
                                value = "";
                                break;
                            case "Triangle":
                                TagName = "SideA";
                                value = "";
                                break;
                        }
                    }

                    /// <summary> 
                    /// After receiving the radius of the circle, a new instance is built and placed in the box. 
                    /// The auxiliary list is cleared. 
                    /// </summary>
                    if (value != "" && TagName == "Radius")
                    {
                        tempFigureList.Add(value);
                        string material = Convert.ToString(tempFigureList[0]);
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(tempFigureList[1]));
                        double radius = Convert.ToDouble(tempFigureList[3]);
                        Figure figure = new Figure(new Circle(radius), NewMaterial(material));
                        if (color != Colors.Transparent && color != Colors.White)
                        {
                            figure.Paint(color);
                        }
                        figuresBox.AddFigure(figure);
                        TagName = "Material";
                        tempFigureList.Clear();
                        value = "";
                    }

                    /// <summary> Getting the length of the rectangle. </summary>
                    if (value != "" && TagName == "Length")
                    {
                        tempFigureList.Add(value);
                        TagName = "Width";
                        value = "";
                    }

                    /// <summary> 
                    /// After receiving the length and width of the rectangle, a new instance is built and placed in the box. 
                    /// The auxiliary list is cleared. 
                    /// </summary>
                    if (value != "" && TagName == "Width")
                    {
                        tempFigureList.Add(value);
                        string material = Convert.ToString(tempFigureList[0]);
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(tempFigureList[1]));
                        double length = Convert.ToDouble(tempFigureList[3]);
                        double width = Convert.ToDouble(tempFigureList[4]);
                        Figure figure = new Figure(new Rectangle(length, width), NewMaterial(material));
                        if (color != Colors.Transparent && color != Colors.White)
                        {
                            figure.Paint(color);
                        }
                        figuresBox.AddFigure(figure);
                        TagName = "Material";
                        tempFigureList.Clear();
                        value = "";
                    }

                    /// <summary> 
                    /// After receiving the side of the square, a new instance is built and placed in the box. 
                    /// The auxiliary list is cleared. 
                    /// </summary>
                    if (value != "" && TagName == "Side")
                    {
                        tempFigureList.Add(value);
                        string material = Convert.ToString(tempFigureList[0]);
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(tempFigureList[1]));
                        double side = Convert.ToDouble(tempFigureList[3]);
                        Figure figure = new Figure(new Square(side), NewMaterial(material));
                        if (color != Colors.Transparent && color != Colors.White)
                        {
                            figure.Paint(color);
                        }
                        figuresBox.AddFigure(figure);
                        TagName = "Material";
                        tempFigureList.Clear();
                        value = "";
                    }

                    /// <summary> Getting the base A of the trapezium. </summary>
                    if (value != "" && TagName == "BaseA")
                    {
                        tempFigureList.Add(value);
                        TagName = "BaseB";
                        value = "";
                    }

                    /// <summary> Getting the base B of the trapezium. </summary>
                    if (value != "" && TagName == "BaseB")
                    {
                        tempFigureList.Add(value);
                        TagName = "Height";
                        value = "";
                    }

                    /// <summary> 
                    /// After receiving the base A, base B and height of the trapezium, a new instance is built and placed in the box. 
                    /// The auxiliary list is cleared. 
                    /// </summary>
                    if (value != "" && TagName == "Height")
                    {
                        tempFigureList.Add(value);
                        string material = Convert.ToString(tempFigureList[0]);
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(tempFigureList[1]));
                        double baseA = Convert.ToDouble(tempFigureList[3]);
                        double baseB = Convert.ToDouble(tempFigureList[4]);
                        double height = Convert.ToDouble(tempFigureList[5]);
                        Figure figure = new Figure(new Trapezium(baseA, baseB, height), NewMaterial(material));
                        if (color != Colors.Transparent && color != Colors.White)
                        {
                            figure.Paint(color);
                        }
                        figuresBox.AddFigure(figure);
                        TagName = "Material";
                        tempFigureList.Clear();
                        value = "";
                    }

                    /// <summary> Getting the side A of the triangle. </summary>
                    if (value != "" && TagName == "SideA")
                    {
                        tempFigureList.Add(value);
                        TagName = "SideB";
                        value = "";
                    }

                    /// <summary> Getting the side B of the triangle. </summary>
                    if (value != "" && TagName == "SideB")
                    {
                        tempFigureList.Add(value);
                        TagName = "SideC";
                        value = "";
                    }

                    /// <summary> 
                    /// After receiving the side A, side B and side C of the triangle, a new instance is built and placed in the box. 
                    /// The auxiliary list is cleared. 
                    /// </summary>
                    if (value != "" && TagName == "SideC")
                    {
                        tempFigureList.Add(value);
                        string material = Convert.ToString(tempFigureList[0]);
                        Colors color = (Colors)Enum.Parse(typeof(Colors), Convert.ToString(tempFigureList[1]));
                        double sideA = Convert.ToDouble(tempFigureList[3]);
                        double sideB = Convert.ToDouble(tempFigureList[4]);
                        double sideC = Convert.ToDouble(tempFigureList[5]);
                        Figure figure = new Figure(new Triangle(sideA, sideB, sideC), NewMaterial(material));
                        if (color != Colors.Transparent && color != Colors.White)
                        {
                            figure.Paint(color);
                        }
                        figuresBox.AddFigure(figure);
                        TagName = "Material";
                        tempFigureList.Clear();
                        value = "";
                    }
                }
            }
            /// <summary> Сleaning the file after putting the figures in the box. </summary>
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.Close();
        }

        /// <summary> Creates new material. </summary>
        /// <param name="materialName"> Name of the material. </param>
        /// <returns> The <see cref="Material"/>. </returns>
        /// <exception cref="Exception"> There is no such material. </exception>
        private static Material NewMaterial(string materialName)
        {
            Material figureMaterial = null;
            if (materialName == "Film")
            {
                figureMaterial = new Film();
                return figureMaterial;
            }
            else if (materialName == "Paper")
            {
                figureMaterial = new Paper();
                return figureMaterial;
            }
            else
            {
                throw new Exception("There is no such material.");
            }
        }
    }
}