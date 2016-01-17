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
using Wosad.Common.Entities;
using Wosad.Common.Reports; 
using Wosad.Common.CalculationLogger.Interfaces; 
using Wosad.Common.CalculationLogger;
//using p = Wosad.Concrete.ACI318_11.DevelopmentCompressionParagraphs;
//using f = Wosad.Concrete.ACI318_11.DevelopmentCompressionFormulas;
//using v = Wosad.Concrete.ACI318_11.DevelopmentCompressionValues;
//using d = Wosad.Concrete.ACI318_11.DevelopmentCompressionDescriptions;
using dv = Wosad.Concrete.ACI318_11.DevelopmentValues;
using gv = Wosad.Concrete.ACI318_11.GeneralValues;
using gd = Wosad.Concrete.ACI318_11.GeneralDescriptions;
using gf = Wosad.Concrete.ACI318_11.GeneralFormulas;

namespace Wosad.Concrete.ACI318_11
{

 
    public partial class DevelopmentCompression:Development
    {

           
        private double GetBasicCompressionDevelopmentLength()
        {
            double ldc;
            double fy = Rebar.Material.YieldStress;
            double fc = Concrete.SpecifiedCompressiveStrength;
            double db = Rebar.Diameter;
            double sqrt_fc = GetSqrt_fc();
            double lambda = Concrete.Lambda;
            lambda = CheckLambda(lambda);

            double ldc1;

            ldc1 = 0.02 * fy / (lambda * sqrt_fc) * db;


            double ldc2;

            ldc2 = (0.0003 * fy) * db;

            ldc = Math.Min(ldc1, ldc2);

            return ldc;
        }

        internal double GetCompressionDevelopmentLength()
        {
            double ldc=GetBasicCompressionDevelopmentLength();
            ldc = CheckExcessRatioAndMinimumLength(ldc);
            return ldc;
        }

        internal double GetCompressionDevelopmentLength(bool isConfinedCompressionRebar)
        {
            double ldc = GetBasicCompressionDevelopmentLength();

            //confined bars
            if (isConfinedCompressionRebar == true)
            {
                ldc = 0.75 * ldc;
            }
            
            ldc = CheckExcessRatioAndMinimumLength(ldc);
            return ldc;
        }

        private double CheckExcessRatioAndMinimumLength(double ldc)
        {
            //excess rebar
            ldc = CheckExcessReinforcement(ldc, false, false);

            //minimum length
            if (ldc < 8.0)
            {
                ldc = 8.0;
            }
            return ldc;
        }
    }
}
