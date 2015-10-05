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
using Wosad.Common.Entities; 
using Wosad.Common.Section.Interfaces; 
using Wosad.Steel.AISC.Interfaces;
 
using Wosad.Analytics.Steel.AISC360_10.Connections.AffectedElements;
 
using Wosad.Common.CalculationLogger.Interfaces; 
using Wosad.Steel.AISC.Interfaces;
using Wosad.Steel.AISC.SteelEntities.Sections;
using Wosad.Steel.AISC.Code;
 

namespace  Wosad.Analytics.Steel.AISC360_10.HSS.ConcentratedForces
{
    partial class ChsLongitudinalPlateShear : ChsToPlateConnection
    {
        ICalcLog CalcLog;

        public ChsLongitudinalPlateShear(SteelChsSection Hss, SteelPlateSection Plate, SteelDesignFormat DesignFormat, ICalcLog CalcLog)
            : base(Hss, Plate,DesignFormat,CalcLog)
        {
            this.CalcLog = CalcLog;
        }

        double GetAvailableStrength(SteelDesignFormat format)
        {
            double R = 0.0;
            double tmax = GetMaximumPlateThickness();
            Plate.Section.Width = tmax;

            //Calculate plate shear capacity per Chapter J
            AffectedElementInFlexureAndShear ae = new AffectedElementInFlexureAndShear(Plate,DesignFormat, this.CalcLog);
            double ShearCapacity = ae.GetShearCapacity();
            double MomentCapacity = ae.GetFlexuralCapacityMajorAxis( FlexuralCompressionFiberPosition.Top);
            //note: it is assumed that the section is symmetrical and compression fiber location does not matter
            double VmaxF = MomentCapacity / Plate.Section.Height;

            R = Math.Min(ShearCapacity, VmaxF);

            return R;
        }

        internal double GetMaximumPlateThickness()
        {

            double Fu = Hss.Material.UltimateStress;
            double Fyp = Plate.Material.YieldStress;
            double t = Plate.Section.Width;

            return Fu / Fyp * t;

        }
    }
}
