#region Copyright
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
using Wosad.Loads.ASCE7.Entities;

namespace Wosad.Loads.ASCE.ASCE7_10.WindLoads
{
    class Damping
    {
        public double GetDampingRatioBeta(WindMaterialDampingType MaterialDampingType)
        {
            switch (MaterialDampingType)
            {
                case WindMaterialDampingType.Steel:
                    return 0.01;
                case WindMaterialDampingType.Concrete:
                    return 0.01;
                default:
                    return 0.01;

            }
        }
    }
}
