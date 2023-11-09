using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriosReconstruction.Interfaces;
using TriosReconstruction.Service;

namespace TrisReconstruction.Tests
{
    [TestClass]
    public class ReconstructionEngineTests
    {
        [TestMethod]
        public void TestReconstruct_WhenImageTextReceived_Then_ReconstructModel()
        {
            IImageTextValidator validator = new ImageTextValidator();
            IReconstructionEngine engine = new ReconstructionEngine();
            IImageReceiver receiver = new ImageReceiver(validator, engine);
            receiver.Receive("1oene");
            receiver.Receive("ne2en");
            receiver.Receive("enoe3");
            receiver.Receive("3neoo");
            receiver.Receive("oo4ae");
            receiver.Receive("aei5i");
            receiver.Receive("i5iia");

            var model = engine.GetReconstructionModel();

            Assert.AreEqual(model, engine.GetBaseModel());
        }
    }
}