using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsbnConvertUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ISBN13からISBN10への変換_1()
        {
            var result = Softbuild.Data.Isbn.IsbnConverter.ConvertToISBN10("9784758072908");
            Assert.IsTrue(result == "4758072906");
        }

        [TestMethod]
        public void ISBN13からISBN10への変換_2()
        {
            var result = Softbuild.Data.Isbn.IsbnConverter.ConvertToISBN10("9784063769371");
            Assert.IsTrue(result == "4063769372");
        }


        [TestMethod]
        public void ISBN10からISBN13への変換_1()
        {
            var result = Softbuild.Data.Isbn.IsbnConverter.ConvertToISBN13("4758072906");
            Assert.IsTrue(result == "9784758072908");
        }

        [TestMethod]
        public void ISBN10からISBN13への変換_2()
        {
            var result = Softbuild.Data.Isbn.IsbnConverter.ConvertToISBN13("4063769372");
            Assert.IsTrue(result == "9784063769371");
        }
    }
}
