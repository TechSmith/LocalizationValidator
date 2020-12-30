using System;
using System.Collections.Generic;
using SystemInterface.IO;

namespace LocalizationValidatorLib
{
   public class ResourceFinder
   {
      private readonly string _directoryPath;
      private readonly IDirectory _directory;
      private readonly IValidatePath _validatePath;

      public ResourceFinder( string directoryPath,
                             IDirectory directory,
                             IValidatePath validatePath )
      {
         _directoryPath = directoryPath;
         _directory = directory ?? throw new ArgumentNullException( nameof( directory ) );
         _validatePath = validatePath ?? throw new ArgumentNullException( nameof( validatePath ) );

         if (!_directory.Exists(_directoryPath))
         {
            throw new InvalidOperationException( "Directory does not exist" );
         }
      }

      public IEnumerable<string> GetAllResourceFiles()
      {
         yield break;
      }
   }
}
