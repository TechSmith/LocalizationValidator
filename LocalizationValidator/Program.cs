using System;
using System.Linq;
using SystemWrapper.IO;
using LocalizationValidatorLib;

namespace LocalizationValidator
{
   class Program
   {
      static void Main( string[] args )
      {
         ResourceExtensions resourceExtensions = new ResourceExtensions();
         ResourceFinder resourceFinder = new ResourceFinder( args.First(), new DirectoryWrap(), new AllValidPaths() );
         
         foreach ( var resourceFile in resourceFinder.GetAllResourceFiles() )
         {
            if ( resourceExtensions.HasResxExtension( resourceFile ) )
            {
               ResxReader reader = new ResxReader( resourceFile, new FileWrap() );
            }
         }
      }
   }

   
}
