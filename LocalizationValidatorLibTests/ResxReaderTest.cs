using SystemInterface.IO;
using LocalizationValidatorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LocalizationValidatorLibTests
{
   [TestClass]
   public class ResxReaderTest
   {
      [TestMethod]
      public void Constructor_ResxContents_ReadsResx()
      {
          const string exampleResxText = @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <resheader name=""resmimetype"">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name=""version"">
    <value>2.0</value>
  </resheader>
  <resheader name=""reader"">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name=""writer"">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name=""ExampleData"" xml:space=""preserve"">
    <value>Boring English Text</value>
  </data>
</root>";
         
         Mock<IFile> mockFile = new Mock<IFile>();
         mockFile.Setup( f => f.Exists( It.IsAny<string>() )  ).Returns( true );
         mockFile.Setup( f => f.ReadAllText( It.IsAny<string>() ) ).Returns( exampleResxText );
         ResxReader reader = new ResxReader( @"C:\something.resx", mockFile.Object );
      }
   }
}