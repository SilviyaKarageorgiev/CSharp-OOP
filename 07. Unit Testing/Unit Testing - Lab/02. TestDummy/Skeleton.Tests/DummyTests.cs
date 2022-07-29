using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
        }

        [Test]
        public void DeadDummyCanGiveExpirience()
        {
            Dummy dummy = new Dummy(0, 10);
            int result = dummy.GiveExperience();

            Assert.AreEqual(result, 10);
        }

        [Test]
        public void AliveDummyCanGiveExpirience()
        {
            Dummy dummy = new Dummy(10, 10);
            
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}