namespace MassSpecSim
{
    public class PeakDefinition
    {
        public double Position { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public PeakDefinition(double position, double height, double width)
        {
            Position = position;
            Height = height;
            Width = width;
        }
    }
}
