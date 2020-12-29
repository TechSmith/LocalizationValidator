using LocalizationValidatorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalizationValidatorLibTests
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestMethod1()
      {
         ResourceFinder rf = new ResourceFinder( @"C:\Blah" );
      }
   }
}
