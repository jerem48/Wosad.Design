﻿#region Copyright
   /*Copyright (C) 2015 Wosad Inc

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */
#endregion
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wosad.Common.Section.Exceptions
{
    public class FailedToCalculateSectionPropertiesException: ApplicationException
    {
        public FailedToCalculateSectionPropertiesException(Type RequiredSectionType)
        {
            typeString = RequiredSectionType.Name;
        }

       public FailedToCalculateSectionPropertiesException(string TypesDesired)
        {
            typeString = TypesDesired;
        }

        string typeString;

        public override string Message
        {
            get
            {
                return string.Format("Failed to calculate section properties for section of type {0}", typeString);
            }
        }
    }
}