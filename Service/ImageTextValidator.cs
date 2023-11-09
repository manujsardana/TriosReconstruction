using TriosReconstruction.Interfaces;
using TriosReconstruction.Models;

namespace TriosReconstruction.Service
{
    public class ImageTextValidator : IImageTextValidator
    {
        public ValidationResult Validate(string text)
        {
            if(text.Length != 5) 
            {
                return new ValidationResult { ErrorMessage = "Image Text should be 5 characters", IsValid = false };
            }

            return new ValidationResult { IsValid = true, ErrorMessage = string.Empty };
        }
    }
}
