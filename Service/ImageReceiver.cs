using TriosReconstruction.Interfaces;
using TriosReconstruction.Models;

namespace TriosReconstruction.Service
{
    public class ImageReceiver : IImageReceiver
    {
        private readonly IImageTextValidator _imageTextValidatior;
        private readonly IReconstructionEngine _engine;

        public ImageReceiver(IImageTextValidator imageTextValidator, IReconstructionEngine engine) 
        { 
            _imageTextValidatior = imageTextValidator;
            _engine = engine;
        }

        public ImageReceiveResult Receive(string imageText)
        {
            var validatiomResult = _imageTextValidatior.Validate(imageText);
            if(validatiomResult.IsValid)
            {
                _engine.ProcessImage(imageText);
                return new ImageReceiveResult {  ImageReceiveStatus = ImageReceiveStatus.OK, ErrorMessage = string.Empty};
            }
            else
            {
               return new ImageReceiveResult { ErrorMessage = validatiomResult.ErrorMessage, ImageReceiveStatus = ImageReceiveStatus.Error };
            }
        }
    }
}
