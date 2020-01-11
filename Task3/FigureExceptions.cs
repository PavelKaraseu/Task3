using System;

namespace Task3
{
    /// <summary> Custom exception class for figures </summary>
    public class FigureExceptions
    {
        /// <summary> An exception that occurs when painting a figure. </summary>
        /// <seealso cref="System.Exception" />
        public class PaintException : Exception
        {
            /// <summary> Initializes a new instance of the <see cref="PaintException"/> class. </summary>
            /// <param name="message"> The message that describes the error. </param>
            public PaintException(string message) : base(message)
            {

            }
        }
    }
}