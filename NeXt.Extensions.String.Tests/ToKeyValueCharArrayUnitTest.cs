using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeXt.Extensions.String.Tests
{
    [TestClass, TestCategory("ToKeyValue - CharArray")]
    public class ToKeyValueCharArrayUnitTest
    {
        [TestMethod]
        public void WithKeyAndValue_HasKeyAndValue()
        {
            var kv = "key:value=".ToKeyValue('=', ':');
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, "value=");
        }

        [TestMethod]
        public void WithKeyWithoutValue__KeyIsKeyValueIsEmpty()
        {
            var kv = "key:".ToKeyValue('=', ':');
            Assert.AreEqual(kv.key, "key");
            Assert.AreEqual(kv.value, string.Empty);
        }

        [TestMethod]
        public void WithoutKeyWithValue_FullStringAsValueKeyIsEmpty()
        {
            var kv = ":value".ToKeyValue('=', ':');
            Assert.AreEqual(kv.key, string.Empty);
            Assert.AreEqual(kv.value, "value");
        }

        [TestMethod]
        public void WithoutDelimiter_FullStringAsKeyValueIsEmpty()
        {
            var kv = "key-value".ToKeyValue('=', ':');
            Assert.AreEqual(kv.key, "key-value");
            Assert.AreEqual(kv.value, string.Empty);
        }

        [TestMethod]
        public void NullDelimiter_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => "key-value".ToKeyValue((char[])null)
            );
        }

        [TestMethod]
        public void NullThis_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => StringExtensions.ToKeyValue(null, '=', ':')
            );
        }
    }
}