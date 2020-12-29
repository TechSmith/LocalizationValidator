using System;
using System.Linq;
using SystemWrapper.IO;
using LocalizationValidatorLib;

namespace LocalizationValidator
{
   class Program
   {
      static int Main( string[] args )
      {
         LocalizationValidatorManager manager = new LocalizationValidatorManager( args.First(), new RuleManager() );
         
         return manager.ValidateResources();
      }
   }

   
}
