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
using Wosad.Concrete.ACI;
using Wosad.Concrete.ACI.Infrastructure.Entities;
using Wosad.Common.Entities;
using Wosad.Common.CalculationLogger.Interfaces;


namespace Wosad.Concrete.ACI318_11
{
    public abstract class Splice: AnalyticalElement, ISplice
    {
        public Splice(ICalcLog log): base(log)
        {

        }
        public abstract double Length { get; }
    }
}
