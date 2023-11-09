using TriosReconstruction.Models;

namespace TriosReconstruction.Interfaces
{
    public interface IReconstructionEngine
    {
        void ProcessImage(string imageText);

        string GetReconstructionModel();

        string GetBaseModel();
    }
}
