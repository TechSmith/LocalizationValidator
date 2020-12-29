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
         if ( filepath.EndsWith( $".{ResxFileExtension}" ) )
         {
            return true;
         }

         return false;
      }
   }
}