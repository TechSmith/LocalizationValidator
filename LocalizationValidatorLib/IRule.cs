using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public interface IRule
   {
      void Run( IEnumerable<string> resourceStings, RuleReport ruleReport );
   }
}