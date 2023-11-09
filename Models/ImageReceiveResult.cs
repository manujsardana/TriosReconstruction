namespace TriosReconstruction.Models
{
    public class ImageReceiveResult
    {
        public ImageReceiveStatus ImageReceiveStatus { get; set; }

        public string ErrorMessage { get; set; }
    }

    public enum ImageReceiveStatus
    {
        OK,
        Error
    }
}
