namespace LocalizationValidatorLib
{
   public class AllValidPaths : IValidatePath
   {
      public bool ConsiderDirectory( string directory )
      {
         return true;
      }
   }
}