using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public class ProductNames
   {
      public IEnumerable<string> GetProductNames()
      {
         yield return "Camtasia";
         yield return "Snagit";
      }
   }
}