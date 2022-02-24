using NUnit.Framework;
using ECS.TestForUsabillity;
using NSubstitute;

namespace ECS.Unit.Test
{
    public class ECSUnitTest
    {
        private TestForUsabillity.ECS uut;
        //private FakeTempSensor fakeTempSensor;
        //private FakeHeater fakeHeater;
        private IHeater heater;
        private ITempSensor tempSensor;

        [SetUp]
        public void Setup()
        {
            heater = Substitute.For<IHeater>();
            tempSensor = Substitute.For<ITempSensor>();
            //fakeTempSensor = new FakeTempSensor();
            //fakeHeater = new FakeHeater();
            uut = new TestForUsabillity.ECS(23,tempSensor,heater);
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(-5)]
        [TestCase(20)]
        [TestCase(22)]
        public void TestHeaterIsOn(int temp)
        {
            tempSensor.GetTemp().Returns(temp);
            uut.Regulate();
            heater.Received(1).TurnOn();
            ////Arrange
            //fakeTempSensor.Gen = temp;

            ////Act
            //uut.Regulate();

            ////Assert
            //Assert.That(fakeHeater.Status, Is.EqualTo(true));
        }

        [TestCase(23)]
        [TestCase(24)]
        [TestCase(45)]
        public void TestHeaterIsOff(int temp)
        {
            ////Arrange
            //fakeTempSensor.Gen = temp;
            ////Act
            //uut.Regulate();
            ////Assert
            //Assert.That(fakeHeater.Status, Is.EqualTo(false));

            tempSensor.GetTemp().Returns(temp);
            uut.Regulate();
            heater.Received(1).TurnOff();
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
            //// Arrange
            //fakeTempSensor.Gen = temp;

            ////Act
            //int testTemp = uut.GetCurTemp();

            ////Assert
            //Assert.That(temp, Is.EqualTo(testTemp));

        }

        [Test]
        public void TestRunSelfTest()
        {
            tempSensor.RunSelfTest().Returns(false);
            heater.RunSelfTest().Returns(true);
            Assert.IsFalse(uut.RunSelfTest());
            ////Act
            //bool test = uut.RunSelfTest();

            ////Assert
            //Assert.That(test, Is.EqualTo(true));
        }

        //SLut prut finale
    }
}