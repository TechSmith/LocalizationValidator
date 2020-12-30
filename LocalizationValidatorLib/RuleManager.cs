using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public class RuleManager
   {
      private readonly List<IRule> _rulesToRun;
      public RuleManager()
      {
         _rulesToRun = new List<IRule>();
         _rulesToRun.Add( new ProductNameInResourcesRule() );
      }
      public bool RunRulesOnStrings( IEnumerable<ResourceString> resourceStrings )
      {
         RuleReport ruleReport = new RuleReport();
         
         foreach ( var ruleToRun in _rulesToRun )
         {
            ruleToRun.Run( resourceStrings, ruleReport );
         }
         
         return ruleReport.AnyFailures();
      }
   }
}