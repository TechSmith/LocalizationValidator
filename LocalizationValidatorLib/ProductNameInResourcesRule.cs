using System;
using System.Collections.Generic;
using System.Linq;

namespace LocalizationValidatorLib
{
   public class ProductNameInResourcesRule : IRule
   {
      private readonly ProductNames _productNames;
      public ProductNameInResourcesRule()
      {
         _productNames = new ProductNames();
      }
      
      public void Run( IEnumerable<ResourceString> resourceStings, RuleReport ruleReport )
      {
         foreach ( var resourceString in resourceStings )
         {
            if ( HasProductName( resourceString.Text ) )
            {
               ruleReport.AddFailure();
            }
         }
      }

      private bool HasProductName( string resourceString )
      {
         return _productNames.GetProductNames().Any( name => resourceString.Contains( name ) );
      }
   }
}