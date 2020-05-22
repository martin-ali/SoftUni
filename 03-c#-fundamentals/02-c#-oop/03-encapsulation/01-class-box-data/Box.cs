namespace _01_class_box_data
{
    using System;

    public class Box
    {
        private double height;

        private double width;

        private double length;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get => this.length;
            set
            {
                this.throwIfValueIsInvalid(value, nameof(this.Length));

                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;
            set
            {
                this.throwIfValueIsInvalid(value, nameof(this.Width));

                this.width = value;
            }
        }

        private double Height
        {
            get => this.height;
            set
            {
                this.throwIfValueIsInvalid(value, nameof(this.Height));

                this.height = value;
            }
        }

        private void throwIfValueIsInvalid(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
        }

        private double GetSurfaceArea()
        {
            var surfaceArea = (2 * this.length * this.width)
                            + (2 * this.length * this.height)
                            + (2 * this.width * this.height);

            return surfaceArea;
        }

        private double GetLateralSurfaceArea()
        {
            var lateralSurfaceArea = (2 * this.length * this.height)
                                    + (2 * this.width * this.height);

            return lateralSurfaceArea;
        }

        private double GetVolume()
        {
            var volume = this.length * this.width * this.height;

            return volume;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.GetSurfaceArea():0.00}{Environment.NewLine}"
                + $"Lateral Surface Area - {this.GetLateralSurfaceArea():0.00}{Environment.NewLine}"
                + $"Volume - {this.GetVolume():0.00}";
        }
    }
}