
using TriosReconstruction.Models;

namespace TriosReconstruction.Interfaces
{
    public interface IImageTextValidator
    {
        public ValidationResult Validate(string text);
    }
}
