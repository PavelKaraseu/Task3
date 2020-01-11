using System;
using System.Xml;
using System.IO;

namespace Task3
{
    /// <summary> Singleton class describing a box with figures. Box is designed for 20 figures </summary>
    public class FiguresBox : IWriteToXml
    {
        /// <summary> The figures box as array. </summary>
        private static Figure[] figures = new Figure[20];

        /// <summary> Prevents a default instance of the <see cref="FiguresBox"/> class from being created. </summary>
        private FiguresBox() { }
        /// <summary> Singleton object stored in a static field. </summary>
        private static FiguresBox instance;
        /// <summary> Access to an instance of a Singleton. </summary>
        public static FiguresBox GetInstance()
        {
            if (instance == null)
            {
                instance = new FiguresBox();
            }
            return instance;
        }

        /// <summary> Clear the figures box. </summary>
        public void ClearBox()
        {
            for (int i = 0; i < figures.Length; i++)
            {
                figures[i] = null;
            }
        }

        /// <summary> Adds the figure. </summary>
        /// <remarks> Unable to add a figure with the same characteristics. </remarks>
        /// <param name="figure"> The figure. </param>
        /// <exception cref="Exception">
        /// The figure with such characteristics already exists.
        /// or
        /// The box is full. Remove figures and try again. 
        /// </exception>
        public void AddFigure(Figure figure)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null)
                {
                    if (figure.Shape.ToString() == figures[i].Shape.ToString() & figure.Material.GetMaterialAsString() ==
                    figures[i].Material.GetMaterialAsString() & figure.Material.Color == figures[i].Material.Color)
                    {
                        throw new Exception("The figure with such characteristics already exists.");
                    }
                }
            }
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] == null)
                {
                    figures[i] = figure;
                    return;
                }
            }
            throw new Exception("The box is full. Remove figures and try again.");
        }

        /// <summary> Shows the figure by number. </summary>
        /// <param name="number"> The number of a figure. </param>
        /// <returns> Figure by number. </returns>
        /// <exception cref="Exception"> Figures with this number do not exist. </exception>
        public Figure ShowFigureByNumber(int number)
        {
            if (number < figures.Length)
            {
                return figures[number];
            }
            else
            {
                throw new Exception("Figures with this number do not exist.");
            }
        }

        /// <summary> Removes the figure by number. </summary>
        /// <param name="number"> The number of a figure. </param>
        /// <exception cref="Exception"> Figures with this number do not exist. </exception>
        public void RemoveFigureByNumber(int number)
        {
            if (number < figures.Length && figures[number] != null)
            {
                figures[number] = null;
            }
            else
            {
                throw new Exception("Figures with this number do not exist.");
            }
        }

        /// <summary> Removes all circles. </summary>
        public void RemoveAllCircles()
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null)
                {
                    if (figures[i].Shape.ToString() == "Circle")
                    {
                        figures[i] = null;
                    }
                }
            }
        }

        /// <summary> Removes all film figures. </summary>
        public void RemoveAllFilmFigures()
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null)
                {
                    if (figures[i].Material.GetMaterialAsString() == "Film")
                    {
                        figures[i] = null;
                    }
                }
            }
        }

        /// <summary> Replaces the figure by number. </summary>
        /// <param name="figure"> Replacement figure. </param>
        /// <param name="number"> Number of the replaced figure. </param>
        /// <exception cref="Exception"> Figures with this number do not exist. </exception>
        public void ReplaceFigureByNumber(Figure figure, int number)
        {
            if (number < figures.Length)
            {
                figures[number] = figure;
            }
            else
            {
                throw new Exception("Figures with this number do not exist.");
            }
        }

        /// <summary> Finds the equivalent figure. </summary>
        /// <param name="figure"> Sample figure. </param>
        /// <returns> Equivalent figure if found. </returns>
        /// <exception cref="Exception"> Equivalent figure not found. </exception>
        public Figure FindEquivalentFigure(Figure figure)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null)
                {
                    if (figure.Shape.ToString() == figures[i].Shape.ToString() & figure.Material.GetMaterialAsString() ==
                    figures[i].Material.GetMaterialAsString() & figure.Material.Color == figures[i].Material.Color)
                    {
                        return figures[i];
                    }
                }
            }
            throw new Exception("Equivalent figure not found");
        }

        /// <summary> Shows the quantity figures. </summary>
        /// <returns> Quantity figures. </returns>
        public int ShowQuantityFigures()
        {
            int quantity = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null)
                {
                    quantity++;
                }
            }
            return quantity;
        }

        /// <summary> Gets the total area of the figures in the box. </summary>
        /// <returns> Total area. </returns>
        public double GetTotalArea()
        {
            double area = 0.0;
            foreach (var figure in figures)
            {
                if (figure != null)
                {
                    area = area + figure.Shape.GetArea();
                }
            }
            return area;
        }

        /// <summary> Gets the total perimeter of the figures in the box. </summary>
        /// <returns> Total perimeter. </returns>
        public double GetTotalPerimeter()
        {
            double perimeter = 0.0;
            foreach (var figure in figures)
            {
                if (figure != null)
                {
                    perimeter = perimeter + figure.Shape.GetPerimeter();
                }
            }
            return perimeter;
        }

        /// <summary> Interface IWriteToXml implementation. </summary>
        /// <param name="xmlWriter"> The XmlWriter instance. </param>
        public void WriteToXml(XmlWriter xmlWriter)
        {
            foreach (var figure in figures)
            {
                if (figure != null)
                {
                    figure.WriteToXml(xmlWriter);
                }
            }
            ClearBox();
        }

        /// <summary> Interface IWriteToXml implementation. </summary>
        /// <param name="streamWriter"> The StreamWriter instance. </param>
        public void WriteToXml(StreamWriter streamWriter)
        {
            foreach (var figure in figures)
            {
                if (figure != null)
                {
                    figure.WriteToXml(streamWriter);
                }
            }
            ClearBox();
        }
    }
}