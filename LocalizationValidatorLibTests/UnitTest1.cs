using FluentAssertions;
using LocalizationValidatorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SystemInterface.IO;

namespace LocalizationValidatorLibTests
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public void TestMethod1()
      {
         Mock<IDirectory> directory = new Mock<IDirectory>();

         ResourceFinder rf = new ResourceFinder( @"C:\Blah", directory.Object );

         rf.GetAllResourceFiles().Should().BeEmpty();
      }
   }
}
