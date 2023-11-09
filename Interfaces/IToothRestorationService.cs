namespace TriosReconstruction.Interfaces
{
    public interface IToothRestorationService
    {
        string GetGeometryForTooth(int toothUns);

        List<int> GetTeethUNSForRestoration();
    }
}
