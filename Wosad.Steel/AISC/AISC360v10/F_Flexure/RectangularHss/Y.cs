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
 
 
 using Wosad.Common.CalculationLogger;
using Wosad.Common.CalculationLogger.Interfaces; 
using Wosad.Steel.AISC.Interfaces;
using Wosad.Common.CalculationLogger;

using Wosad.Steel.AISC.AISC360v10.General.Compactness;
using Wosad.Steel.AISC.SteelEntities.Sections;
using Wosad.Steel.AISC.SteelEntities;
using Wosad.Steel.AISC.Exceptions;
using Wosad.Steel.AISC.Steel.Entities;



namespace Wosad.Steel.AISC.AISC360v10.Flexure
{
    public partial class BeamRectangularHss : FlexuralMemberRhsBase, ISteelBeamFlexure
    {

        public SteelLimitStateValue GetPlasticMomentCapacity(MomentAxis MomentAxis)

        {
            SteelLimitStateValue ls = new SteelLimitStateValue();
            double phiM_n;
            double M_n=0.0;
            switch (MomentAxis)
            {
                case MomentAxis.XAxis:
                    M_n = GetMajorNominalPlasticMoment();
                    break;
                case MomentAxis.YAxis:
                    M_n = GetMinorNominalPlasticMoment();
                    break;
                default:
                    throw new FlexuralBendingAxisException();
                    break;
           }
            phiM_n =0.9*M_n;
            ls.Value = phiM_n;
            ls.IsApplicable = true;
            return ls;
        }

        //Yielding F7.1
        public  SteelLimitStateValue GetMajorPlasticMomentStrength()
        {
            SteelLimitStateValue ls = new SteelLimitStateValue();
            double M_p = GetMajorNominalPlasticMoment();

            double phiM_n = 0.9 * M_p;


            ls.IsApplicable = true;
            ls.Value = phiM_n;
            return ls;
        }

        public SteelLimitStateValue GetMinorNominalPlasticStrength()
        {
            SteelLimitStateValue ls = new SteelLimitStateValue();

            double Mp = GetMinorNominalPlasticMoment();
            double phiM_n = Mp;



            ls.IsApplicable = true;
            ls.Value = phiM_n;
            return ls;
        }


    }
}
