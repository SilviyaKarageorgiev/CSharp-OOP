using System;
using System.Text;
using System.Xml.Schema;

namespace P01.ClassBoxData
{
    public class Box
    {

        private const string ZeroOrNegativeArgumentException = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ZeroOrNegativeArgumentException, nameof(this.Length)));
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ZeroOrNegativeArgumentException, nameof(this.Width)));
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ZeroOrNegativeArgumentException, nameof(this.Height)));
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);
            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * (this.Length * this.Height + this.Width * this.Height);
            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;
            return result;
        }

    }
}
