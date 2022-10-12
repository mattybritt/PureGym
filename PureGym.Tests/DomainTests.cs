using NUnit.Framework;
using PureGym.Domain;

namespace PureGym.Tests
{
    public class DomainTests
    {
        [Test]
        public void Slot_should_have_valid_id()
        {
            var sut = new Slot(new System.DateTime(2022, 10, 12), new HourOfDay(3), SlotHourPeriod.Three, new AreaId("23"));
            Assert.AreEqual(sut.GetIdentifier(),"20221012_3_3_23");

            sut = new Slot(new System.DateTime(2021, 11, 13), new HourOfDay(6), SlotHourPeriod.Four, new AreaId("24"));
            Assert.AreEqual(sut.GetIdentifier(),"20211113_6_4_24");
        }
    }
}