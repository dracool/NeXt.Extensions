using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeXt.Extensions.String.Tests
{
    [TestClass, TestCategory("Slice")]
    public class SliceUnitTests
    {
        [TestMethod]
        public void PositiveIndex_ReturnsSubstring()
        {
            Assert.AreEqual("Hello World".Slice(5), "World");
        }

        [TestMethod]
        public void NegativeIndex_ReturnsFirst()
        {
            Assert.AreEqual("Hello World".Slice(-5), "Hello");
        }

        [TestMethod]
        public void OutOfBoundIndex_ThrowsArgumentOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => "Hello".Slice(5)
            );
        }

        [TestMethod]
        public void NullString_ThrowsArgumentNull()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => ((string)null).Slice(5)
            );
        }
    }
}