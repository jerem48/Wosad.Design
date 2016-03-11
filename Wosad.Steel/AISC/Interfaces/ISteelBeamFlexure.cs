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
using System.Text; using Wosad.Common.Entities; using Wosad.Common.Section.Interfaces; using Wosad.Steel.AISC.Interfaces;
using Wosad.Common.Entities;
using Wosad.Steel.AISC.SteelEntities;

namespace Wosad.Steel.AISC.Interfaces
{
    public interface ISteelBeamFlexure
    {
        SteelLimitStateValue GetFlexuralYieldingStrength( FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetFlexuralLateralTorsionalBucklingStrength(double C_b, double L_b, FlexuralCompressionFiberPosition CompressionLocation,
            FlexuralAndTorsionalBracingType BracingType, MomentAxis MomentAxis);
        SteelLimitStateValue GetFlexuralFlangeLocalBucklingStrength( FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetFlexuralCompressionFlangeYieldingStrength(FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetFlexuralTensionFlangeYieldingStrength( FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetFlexuralWebOrWallBucklingStrength(FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetFlexuralLegOrStemBucklingStrength(FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetLimitingLengthForInelasticLTB_Lr(FlexuralCompressionFiberPosition CompressionLocation);
        SteelLimitStateValue GetLimitingLengthForFullYielding_Lp(FlexuralCompressionFiberPosition CompressionLocation);
    }
}
