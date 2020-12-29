using System;
using SystemInterface.IO;

namespace LocalizationValidatorLib
{
   public class ResxReader
   {
      private readonly string _resxFilePath;
      private readonly IFile _file;
      public ResxReader( string resxFilePath, IFile file )
      {
         _resxFilePath = resxFilePath;
         _file = file;

         if ( !_file.Exists( _resxFilePath ) )
         {
            throw new InvalidOperationException( $"File {_resxFilePath} does not exist" );
         }
      }
   }
}