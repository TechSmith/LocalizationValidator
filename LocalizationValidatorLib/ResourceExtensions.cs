namespace LocalizationValidatorLib
{
   public class ResourceExtensions
   {
      public const string ResxFileExtension = "resx";
      
      public ResourceExtensions()
      {
         
      }
      
      public bool HasResourceExtension( string filepath )
      {
         if ( HasResxExtension( filepath ) )
         {
            return true;
         }

         return false;
      }

      public bool HasResxExtension( string filepath )
      {
         return filepath.EndsWith( $".{ResxFileExtension}" );
      }
   }
}