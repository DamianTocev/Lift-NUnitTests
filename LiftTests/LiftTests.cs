using Lift;

namespace LiftTests
{
    public class LiftTests
    {
        [Test]
        public void Test_FitPeopleOnTheLift_EmptyArray()
        {
            var liftSimulator = new LiftSimulator();
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(2, new int[] { }), Throws.InstanceOf<ArgumentException>());

        }

        [Test]
        public void Test_FitPeopleOnTheLift_ArrayNull()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = null;
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(2, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_FitPeopleOnTheLift_NegativeValueInputLiftState()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { -1, -1 };
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(2, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_FitPeopleOnTheLift_MoreMaxValueInputLiftState()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 5, 6, 7, 8 };
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(4, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_FitPeopleOnTheLift_PeopleZeroValue()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(0, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_FitPeopleOnTheLift_PeopleNegativeValue()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(-1, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_FitPeopleOnTheLift_Foreach_PeopleZero()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            int peopleCount = 16;
            var actualLiftState = liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState);
            var expectedLiftState = new int[] { 4, 4, 4, 4 };
            Assert.That(actualLiftState, Is.EqualTo(expectedLiftState));
        }

        [Test]
        public void Test_FitPeopleOnTheLift_Foreach_PeopleZero_Alternative()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            int peopleCount = 5;
            var actualLiftState = liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState);
            var expectedLiftState = new int[] { 4, 1, 0, 0 };
            Assert.That(actualLiftState, Is.EqualTo(expectedLiftState));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResult_NotEnoughSpace()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            int peopleCount = 17;
            var actualMessage = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);
            var expectedMessage = "There isn't enough space! 1 people in a queue!\r\n4 4 4 4";
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResult_AllPeoplePlaced()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            int peopleCount = 16;
            var actualMessage = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);
            var expectedMessage = "All people placed and the lift if full.";
            Assert.That(expectedMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResult_LeftFreeSpaces()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = new int[] { 0, 0, 0, 0 };
            int peopleCount = 8;
            var actualMessage = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);
            var expectedMessage = "The lift has 8 empty spots!\r\n4 4 0 0";
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }


    }
}