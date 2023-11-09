using TriosReconstruction.Models;

namespace TriosReconstruction.Interfaces
{
    public interface IImageReceiver
    {
        ImageReceiveResult Receive(string imageText);
    }
}
