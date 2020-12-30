using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public interface IRule
   {
      void Run( IEnumerable<ResourceString> resourceStings, RuleReport ruleReport );
   }
}