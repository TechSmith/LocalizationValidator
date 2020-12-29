using SystemWrapper.IO;

namespace LocalizationValidatorLib
{
   public class LocalizationValidatorManager
   {
      private readonly string _directory;
      public LocalizationValidatorManager( string directory )
      {
         _directory = directory;
      }
      
      public int ValidateResources()
      {
         ResourceExtensions resourceExtensions = new ResourceExtensions();
         ResourceFinder resourceFinder = new ResourceFinder( _directory, new DirectoryWrap(), new AllValidPaths() );
         
         foreach ( var resourceFile in resourceFinder.GetAllResourceFiles() )
         {
            if ( resourceExtensions.HasResxExtension( resourceFile ) )
            {
               ResxReader reader = new ResxReader( resourceFile, new FileWrap() );
            }
         }

         return 0;
      }
   }
}