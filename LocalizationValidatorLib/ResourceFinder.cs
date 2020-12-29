using System;
using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public class ResourceFinder
   {
      private readonly string _directory;
      public ResourceFinder( string directory )
      {
         _directory = directory;
      }

      public IEnumerable<string> GetAllResourceFiles()
      {
         yield break;
      }
   }
}
