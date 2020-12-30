using System;
using SystemWrapper.IO;

namespace LocalizationValidatorLib
{
   public class LocalizationValidatorManager
   {
      private readonly string _directory;
      private readonly RuleManager _ruleManager;
      public LocalizationValidatorManager( string directory, RuleManager ruleManager )
      {
         _directory = directory;
         _ruleManager = ruleManager ?? throw new ArgumentNullException( nameof( ruleManager ) );
      }
      
      public int ValidateResources()
      {
         ResourceFinder resourceFinder = new ResourceFinder( _directory, new DirectoryWrap(), new AllValidPaths() );
         
         foreach ( var resourceFile in resourceFinder.GetAllResourceFiles() )
         {
            IResourceReader reader = GetResourceReader( resourceFile );
            
            var resourceStrings = reader.GetAllResourceStrings();

            if ( _ruleManager.RunRulesOnStrings( resourceStrings ) == false )
            {
               //Add failure and continue
            }
         }

         return 0;
      }

      private IResourceReader GetResourceReader( string resourceFile )
      {
         ResourceExtensions resourceExtensions = new ResourceExtensions();
         if ( resourceExtensions.HasResxExtension( resourceFile ) )
         {
            ResxReader reader = new ResxReader( resourceFile, new FileWrap() );
            return reader;
         }
         
         // Unknown type?
         throw new InvalidOperationException( "Not yet known how to read this resource file" );
      }
   }
}