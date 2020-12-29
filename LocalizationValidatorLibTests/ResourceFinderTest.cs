using System;
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
      public void Constructor_DirectoryDoesNotExist_ThrowsException()
      {
         Mock<IDirectory> directory = new Mock<IDirectory>();
         directory.Setup( d => d.Exists( It.IsAny<string>() ) ).Throws( new InvalidOperationException() );

         Action constructor = () => _ = new ResourceFinder( @"C:\Blah", directory.Object );

         constructor.Should().Throw<InvalidOperationException>();
      }

      [TestMethod]
      public void GetAllResourceFiles_NoFiles_ReturnsEmpty()
      {
         Mock<IDirectory> directory = new Mock<IDirectory>();
         directory.Setup( d => d.Exists( It.IsAny<string>() ) ).Returns( true );

         ResourceFinder rf = new ResourceFinder( @"C:\Blah", directory.Object );

         rf.GetAllResourceFiles().Should().BeEmpty();
      }
   }
}