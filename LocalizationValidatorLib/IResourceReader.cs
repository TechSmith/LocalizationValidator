﻿using System.Collections.Generic;

namespace LocalizationValidatorLib
{
   public interface IResourceReader
   {
      IEnumerable<ResourceString> GetAllResourceStrings();
   }
}