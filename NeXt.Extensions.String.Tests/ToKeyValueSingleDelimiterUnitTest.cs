using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeXt.Extensions.String.Tests
{
    [TestClass, TestCategory("ToKeyValue - Single Char")]
    public class ToKeyValueSingleDelimiterUnitTest
    {
        [TestMethod]
        public void WithKeyWithValue_HasKeyAndValue()
        {
            var kv = "key=value".ToKeyValue('=');
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, "value");
        }

        [TestMethod]
        public void WithKeyWithoutValue_KeyIsKeyValueIsEmpty()
        {
            var kv = "key=".ToKeyValue('=');
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, string.Empty);
        }
        
        [TestMethod]
        public void WithoutKeyWithValue_KeyIsEmptyValueIsValue()
        {
            var kv = "=value".ToKeyValue('=');
            Assert.AreEqual(kv.key, string.Empty);
            Assert.AreEqual(kv.value, "value");
        }

        [TestMethod]
        public void WithoutDelimiter_KeyIsStrintValueIsEmpty()
        {
            var kv = "key-value".ToKeyValue('=');
            Assert.AreEqual(kv.key, "key-value");
            Assert.AreEqual(kv.value, string.Empty);
        }

        [TestMethod]
        public void NullThis_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => StringExtensions.ToKeyValue(null, '-')
            );
        }
    }
}
