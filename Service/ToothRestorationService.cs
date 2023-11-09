using TriosReconstruction.Interfaces;

namespace TriosReconstruction.Service
{
    public class ToothRestorationService : IToothRestorationService
    {
        private readonly IReconstructionEngine _engine;

        public ToothRestorationService(IReconstructionEngine engine) 
        {
            _engine = engine;
        }

        public string GetGeometryForTooth(int toothUns)
        {
            List<char> geometry = new();
            var reconstructionModel = _engine.GetReconstructionModel();

            int startIndex = reconstructionModel.IndexOf(toothUns.ToString());

            if (startIndex == -1) return "Geometry Does Not Exists";

            for(int i = startIndex; i < reconstructionModel.Length; i++)
            {
                if(i == startIndex)
                    geometry.Add(reconstructionModel[i]);
                else
                {
                    char c = reconstructionModel[i];
                    if (int.TryParse(c.ToString(), out int _))
                        break;
                    else
                        geometry.Add(c);
                }
            }

            return new string(geometry.ToArray());
        }

        public List<int> GetTeethUNSForRestoration()
        {
            List<int> toothForRestoration = new();
            var reconstructionModel = _engine.GetReconstructionModel();
            var baseReconstuructionModel = _engine.GetBaseModel();
            int toothUNS = -1;
            for(int i =0; i < baseReconstuructionModel.Length; i++)
            {
                
                var charBase = baseReconstuructionModel[i];
                var charModel = reconstructionModel[i];
                if (int.TryParse(charBase.ToString(), out int t))
                {
                    toothUNS = t;
                    continue;
                }
                else
                {
                    if(charBase != charModel)
                    {
                        toothForRestoration.Add(toothUNS);
                    }
                }
            }

            return toothForRestoration;
        }
    }
}
