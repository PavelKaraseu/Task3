using System;

namespace Task3Shapes
{
    /// <summary> Custom exception class for shapes. </summary>
    public class ShapeException
    {
        /// <summary> An exception that occurs when cutting a figure. </summary>
        /// <seealso cref="Exception" />
        public class CutException : Exception
        {
            /// <summary> Initializes a new instance of the <see cref="CutException"/> class. </summary>
            /// <param name="message"> The message that describes the error. </param>
            public CutException(string message) : base(message)
            {

            }
        }
    }
}
