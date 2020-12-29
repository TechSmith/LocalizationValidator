using FluentAssertions;
using LocalizationValidatorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalizationValidatorLibTests
{
   [TestClass]
   public class ResourceExtensionsTest
   {
      [TestMethod]
      public void HasResourceExtension_ResxExtension_ReturnsTrue()
      {
         ResourceExtensions re = new ResourceExtensions();
         re.HasResourceExtension( @"C:\somefile.resx" ).Should().BeTrue();
      }
   }
}