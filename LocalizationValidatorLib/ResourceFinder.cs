﻿using System;
using System.Collections.Generic;
using SystemInterface.IO;

namespace LocalizationValidatorLib
{
   public class ResourceFinder
   {
      private readonly string _directoryPath;
      private readonly IDirectory _directory;

      public ResourceFinder( string directoryPath,
                             IDirectory directory )
      {
         _directoryPath = directoryPath;
         _directory = directory ?? throw new ArgumentNullException( nameof( directory ) );
      }

      public IEnumerable<string> GetAllResourceFiles()
      {
         yield break;
      }
   }
}
