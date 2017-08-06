using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeXt.Extensions.String.Tests
{
    [TestClass, TestCategory("ToKeyValue - Single String")]
    public class ToKeyValueStringDelimiterUnitTest
    {
        [TestMethod]
        public void WithKeyWithValue_HasKeyAndValue()
        {
            var kv = "key==value".ToKeyValue("==");
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, "value");
        }

        [TestMethod]
        public void WithKeyWithoutValue_KeyIsKeyValueIsEmpty()
        {
            var kv = "key==".ToKeyValue("==");
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, string.Empty);
        }

        [TestMethod]
        public void WithoutKeyWithValue_KeyIsEmptyValueIsValue()
        {
            var kv = "==value".ToKeyValue("==");
            Assert.AreEqual(kv.key, string.Empty);
            Assert.AreEqual(kv.value, "value");
        }

        [TestMethod]
        public void WithoutDelimiter_FullStringAsKey()
        {
            var kv = "key-value".ToKeyValue("==");
            Assert.AreEqual(kv.key, "key-value");
        }


        [TestMethod]
        public void NullDelimiter_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => "key-value".ToKeyValue((string)null)
            );
        }

        [TestMethod]
        public void NullThis_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => StringExtensions.ToKeyValue(null, "-")
            );
        }
    }
}
