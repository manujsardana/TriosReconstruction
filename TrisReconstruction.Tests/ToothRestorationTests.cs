using TriosReconstruction.Interfaces;
using TriosReconstruction.Service;

namespace TriosReconstruction.Tests
{
    [TestClass]
    public class ToothRestorationTests
    {
        private IToothRestorationService _service;
        private IImageReceiver receiver;

        [TestInitialize]
        public void PrepareReceiver()
        {
            IImageTextValidator validator = new ImageTextValidator();
            IReconstructionEngine engine = new ReconstructionEngine();
            receiver = new ImageReceiver(validator, engine);
            _service = new ToothRestorationService(engine);
        }

        [TestMethod]
        public void TestRestroation_WhenGeometryForToothExists_Then_ReturnGeometry()
        {
            receiver.Receive("1oene");
            receiver.Receive("ne2en");
            receiver.Receive("enoe3");
            receiver.Receive("3neoo");
            receiver.Receive("oo4ae");
            receiver.Receive("aei5i");
            receiver.Receive("i5iia");
            var geometry = _service.GetGeometryForTooth(2);

            Assert.AreEqual(geometry, "2enoe");
        }

        [TestMethod]
        public void TestRestroation_WhenGeometryForToothDoesNotExists_Then_ReturnGeometry()
        {
            receiver.Receive("1oene");
            receiver.Receive("ne2en");
            receiver.Receive("enoe3");
            receiver.Receive("3neoo");
            receiver.Receive("oo4ae");
            receiver.Receive("aei5i");
            receiver.Receive("i5iia");
            var geometry = _service.GetGeometryForTooth(6);

            Assert.AreEqual(geometry, "Geometry Does Not Exists");
        }

        [TestMethod]
        public void TestRestroation_WhenModelReconstured_Then_ReturnTeethForRestoration()
        {
            receiver.Receive("1ofne");
            receiver.Receive("ne2en");
            receiver.Receive("enoe3");
            receiver.Receive("3neoo");
            receiver.Receive("oo4ae");
            receiver.Receive("aei5i");
            receiver.Receive("i5iia");
            var teethForRestoration = _service.GetTeethUNSForRestoration();

            Assert.AreEqual(teethForRestoration[0], 1);
        }
    }
}
