using static Task3.FigureExceptions;

namespace Task3
{
    /// <summary> An abstract class for describing the material of a figure. </summary>
    public abstract class Material
    {
        /// <summary> Gets or sets the color of the material. </summary>
        /// <value> The color of the material. </value>
        public Colors Color { get; protected set; }

        /// <summary> Gets or sets a value indicating whether this <see cref="Material"/> is painted. </summary>
        /// <value> <c>true</c> if painted; otherwise, <c>false</c>. </value>
        public bool Painted { get; protected set; }

        /// <summary> Paints the specified color of the material. </summary>
        /// <param name="color"> The color of the material. </param>
        public abstract void Paint(Colors color);

        /// <summary> Gets the material as string. </summary>
        /// <returns> The material as string. </returns>
        public abstract string GetMaterialAsString();
    }


    /// <summary> Class describing paper material. </summary>
    /// <seealso cref="Material" />
    public class Paper : Material
    {

        /// <summary> Initializes a new instance of the <see cref="Paper"/> class. </summary>
        /// <remarks> The default color for paper is White. </remarks>
        public Paper()
        {
            Color = Colors.White;
        }

        /// <summary> Paints the specified color of the material. </summary>
        /// <param name="color"> The requaired color of the material. </param>
        /// <exception cref="PaintException"> You can paint a paper figure only once.
        /// or
        /// The paper can not be transparent.
        /// or
        /// The paper is already white. </exception>
        public override void Paint(Colors color)
        {
            if (Painted == true)
            {
                throw new PaintException("You can paint a paper figure only once.");
            }

            switch (color)
            {
                case Colors.Transparent:
                    throw new PaintException("The paper can not be transparent.");
                case Colors.White:
                    throw new PaintException("The paper is already white.");
            }

            this.Color = color;
            Painted = true;
        }

        /// <summary> Gets the material as string. </summary>
        /// <returns> The material as string. </returns>
        public override string GetMaterialAsString()
        {
            return "Paper";
        }

        /// <summary> Determines whether the specified <see cref="object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Paper)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hash * hashCode + (variable hash code (Color))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = 0;
            hashCode = hash * hashCode + Color.GetHashCode();
            return hashCode;
        }
    }

    /// <summary> Class describing film material. </summary>
    /// <seealso cref="Task3.Material" />
    public class Film : Material
    {
        /// <summary> Initializes a new instance of the <see cref="Film"/> class. </summary>
        /// <remarks> The default color for film is Transparent. </remarks>
        public Film()
        {
            Color = Colors.Transparent;
        }

        /// <summary> Paints the specified color of the material. </summary>
        /// <param name="color"> The requaired color of the material. </param>
        /// <exception cref="PaintException"> The film can not be painted. </exception>
        public override void Paint(Colors color)
        {
            throw new PaintException("The film can not be painted.");
        }

        /// <summary> Gets the material as string. </summary>
        /// <returns> The material as string. </returns>
        public override string GetMaterialAsString()
        {
            return "Film";
        }

        /// <summary> Determines whether the specified <see cref="object"/>, is equal to this instance. Overriden method. </summary>
        /// <param name="obj"> The <see cref="object"/> to compare with this instance. </param>
        /// <returns>
        ///     <c> true </c> If the specified <see cref="object"/> is equal to this instance; otherwise, <c> false </c>. 
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Film)
            {
                return true;
            }
            return base.Equals(obj);
        }

        /// <summary> Hash code for this instance. Overridden method. </summary>
        /// <returns> 
        /// New algorithm hashCode = hash * hashCode + (variable hash code (Color))
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 3;
            int hashCode = 0;
            hashCode = hash * hashCode + Color.GetHashCode();
            return hashCode;
        }
    }
}