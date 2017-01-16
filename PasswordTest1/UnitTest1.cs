using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password;

namespace Password
{
    [TestClass]
    public class UnitTest1
    {
        private static PasswordValidator PasswordConstructor()
        {
            return new PasswordValidator();
        }
        private static ExternalPassword ExternalConstructor()
        {
            return new ExternalPassword();
        }
        [TestMethod]
        public void CheckLengthInternal()
        {
            bool result = PasswordConstructor().Verify("Ab1defghijk", "Internal");
            Assert.AreEqual(true, result, "Long enough");
        }
        [TestMethod, ExpectedException(typeof(Exception))]
        public void CheckLengthInternalFail()
        {
            bool result = PasswordConstructor().Verify("Ab", "Internal");
            Assert.AreEqual(false, result, "Not long enough");
        }
        [TestMethod]
        public void CheckLengthExternal()
        {
            bool result = ExternalConstructor().CheckLength("Ab1defghijk");
            Assert.AreEqual(true, result, "Long enough");
        }
        [TestMethod]
        public void CheckNullExternal()
        {
            bool result = ExternalConstructor().CheckNull("ab");
            Assert.AreEqual(true, result, "Password not null");
        }
        [TestMethod]
        public void CheckUpperCaseExternal()
        {
            bool result = ExternalConstructor().CheckUpperCase("Ab");
            Assert.AreEqual(true, result, "Contains Upper Case");
        }
        [TestMethod]
        public void CheckLowerCaseExternal()
        {
            bool result = ExternalConstructor().CheckLowerCase("hijk");
            Assert.AreEqual(true, result, "Contains Lower Case");
        }
        [TestMethod]
        public void CheckNumberExternal()
        {
            bool result = ExternalConstructor().CheckNumber("Ab1def");
            Assert.AreEqual(true, result, "Contains Number");
        }
        [TestMethod]
        public void Feature1()
        {
            bool result = PasswordConstructor().Verify("Ab1defghijk", "External");
            Assert.AreEqual(true, result, "Correct Password");
        }
        [TestMethod, ExpectedException(typeof(Exception))]
        public void Feature2()
        {
            bool result = PasswordConstructor().Verify("Ab1","External");
            Assert.AreEqual(true, result, "3 out of 5 works");
        }
        [TestMethod, ExpectedException(typeof(Exception))]
        public void Feature2Fail()
        {
            bool result = PasswordConstructor().Verify("AAA", "External");
            Assert.AreEqual(false, result, "3 out of 5 don't work");
        }

    }
}