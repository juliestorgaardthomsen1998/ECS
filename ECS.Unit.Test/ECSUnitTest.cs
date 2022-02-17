using NUnit.Framework;
using ECS.TestForUsabillity;

namespace ECS.Unit.Test
{
    public class ECSUnitTest
    {
        private TestForUsabillity.ECS uut;
        private FakeTempSensor fakeTempSensor;
        private FakeHeater fakeHeater;

        [SetUp]
        public void Setup()
        {
            fakeTempSensor = new FakeTempSensor();
            fakeHeater = new FakeHeater();
            uut = new TestForUsabillity.ECS(23,fakeTempSensor,fakeHeater);
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(-5)]
        [TestCase(20)]
        [TestCase(22)]
        public void TestHeaterIsOn(int temp)
        {
            //Arrange
            fakeTempSensor.Gen = temp;

            //Act
            uut.Regulate();

            //Assert
            Assert.That(fakeHeater.Status, Is.EqualTo(true));
        }

        [TestCase(23)]
        [TestCase(24)]
        [TestCase(45)]
        public void TestHeaterIsOff(int temp)
        {
            //Arrange
            fakeTempSensor.Gen = temp;

            //Act
            uut.Regulate();

            //Assert
            Assert.That(fakeHeater.Status, Is.EqualTo(false));
        }

        [TestCase(3)]
        [TestCase(17)]
        [TestCase(45)]
        public void TestSetAndGetThresHold(int thr)
        {
            //Act
            uut.SetThreshold(thr);

            //Assert
            Assert.That(thr, Is.EqualTo(uut.GetThreshold()));

        }

        [TestCase(3)]
        [TestCase(17)]
        [TestCase(45)]
        public void TestGetCurTemp(int temp)
        {
            // Arrange
            fakeTempSensor.Gen = temp;

            //Act
            int testTemp = uut.GetCurTemp();

            //Assert
            Assert.That(temp, Is.EqualTo(testTemp));

        }

        [Test]
        public void TestRunSelfTest()
        {
            //Act
            bool test = uut.RunSelfTest();

            //Assert
            Assert.That(test, Is.EqualTo(true));
        }

        //SLut prut finale
    }
}