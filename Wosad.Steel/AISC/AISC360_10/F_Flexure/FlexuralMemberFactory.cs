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
using Wosad.Common.CalculationLogger.Interfaces; 
using Wosad.Steel.AISC.Interfaces;
using Wosad.Common.Entities;
using Wosad.Common.Section.Interfaces;
using Wosad.Steel.AISC.AISC360v10.General.Compactness;
using Wosad.Steel.AISC.Interfaces;
using Wosad.Steel.AISC.SteelEntities.Sections;
using Wosad.Common.Section.Predefined;
 
 

namespace Wosad.Steel.AISC.AISC360v10.Flexure
{

    public class FlexuralMemberFactory
    {
  

        public ISteelBeamFlexure GetBeam(ISection Shape, ISteelMaterial Material, ICalcLog Log, MomentAxis MomentAxis,
                 FlexuralCompressionFiberPosition compressionFiberPosition,  bool IsRolledMember=true)
        {
            ISteelBeamFlexure beam = null;

            if (MomentAxis == Common.Entities.MomentAxis.XAxis)
	        {
                    if (Shape is ISectionI)
                    {
                        ISectionI IShape = Shape as ISectionI;
                        SteelSectionI SectionI = new SteelSectionI(IShape, Material);
                        if (IShape.b_fBot == IShape.b_fTop && IShape.t_fBot == IShape.t_fTop) // doubly symmetric
                        {
                            DoublySymmetricIBeam dsBeam = new DoublySymmetricIBeam(SectionI, Log, compressionFiberPosition, IsRolledMember);
                            beam = dsBeam.GetBeamCase();
                        }
                        else
                        {
                            SinglySymmetricIBeam ssBeam = new SinglySymmetricIBeam(SectionI, IsRolledMember, compressionFiberPosition, Log );
                            beam = ssBeam.GetBeamCase();
                        }
                    }


                    else if (Shape is ISectionChannel)
                    {
                        ISectionChannel ChannelShape = Shape as ISectionChannel;
                        SteelChannelSection ChannelSection = new SteelChannelSection(ChannelShape, Material);
                        beam = new BeamChannel(ChannelSection, IsRolledMember, Log);
                    }


                    else if (Shape is ISectionPipe)
                    {
                        ISectionPipe SectionPipe = Shape as ISectionPipe;
                        SteelPipeSection PipeSection = new SteelPipeSection(SectionPipe, Material);
                        beam = new BeamCircularHss(PipeSection,  Log);
                    }

                    else if (Shape is ISectionTube)
	                {
                        ISectionTube TubeShape = Shape as ISectionTube;
                        SteelRhsSection RectHSS_Section = new SteelRhsSection(TubeShape, Material);
                        beam = new BeamRectangularHss(RectHSS_Section,compressionFiberPosition, MomentAxis,Log);

	                }


                    else if (Shape is ISectionBox )
                    {
                        ISectionBox BoxShape = Shape as ISectionBox;
                        SteelBoxSection BoxSection = new SteelBoxSection(BoxShape,Material);
                        beam = new BeamRectangularHss(BoxSection, compressionFiberPosition, MomentAxis,Log);
                    }

                    else if (Shape is ISectionTee)
                    {
                        ISectionTee TeeShape = Shape as ISectionTee;
                        SteelTeeSection TeeSection = new SteelTeeSection(TeeShape, Material);
                        beam = new BeamTee(TeeSection, Log);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
	        }
            else  // weak axis
	        {
                if (Shape is ISectionI)
                {
                        ISectionI IShape = Shape as ISectionI;
                        SteelSectionI SectionI = new SteelSectionI(IShape, Material);

                        beam = new BeamIWeakAxis(SectionI, IsRolledMember, Log);
                }
                throw new NotImplementedException();
	        }

            return beam;
        }


    }
}
