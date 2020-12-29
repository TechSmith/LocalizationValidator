using System;
using System.Collections.Generic;
using System.Resources;
using SystemInterface.IO;

namespace LocalizationValidatorLib
{
   public class ResxReader : IResourceReader
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

      public IEnumerable<string> GetAllResourceStrings()
      {
         yield break;
      }
   }
}