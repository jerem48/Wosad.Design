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
using Wosad.Steel.AISC.SteelEntities.Members;
using Wosad.Steel.AISC.Exceptions;


namespace Wosad.Steel.AISC.AISC360_10.Flexure
{
    public abstract partial class FlexuralMemberBase : SteelFlexuralMember
    {
        public FlexuralMemberBase(ISteelSection section,
            double UnbracedLength, double EffectiveLengthFactor, ICalcLog CalcLog)
            : base(section,UnbracedLength, EffectiveLengthFactor, CalcLog)
        {

        }

        #region Plastic Moment
        double GetPlasticMomentCapacity(double Fy, double Z)
        {
            double Mn = 0.0;
            Mn = Fy * Z; //(F2-1)
            return Mn;
        }

        public double GetMajorPlasticMomentCapacity()
        {
            double Mn = 0.0;


            double Fy = this.Section.Material.YieldStress;
            double Zx = Section.Shape.PlasticSectionModulusX;

            Mn = GetPlasticMomentCapacity(Fy, Zx);


            return Mn;
        }
        public  double GetMinorPlasticMomentCapacity()
        {
            double Mn = 0.0;


            double Fy = this.Section.Material.YieldStress;
            double Zy = Section.Shape.PlasticSectionModulusY;

            Mn = GetPlasticMomentCapacity(Fy, Zy);


            return Mn;
        }

        #endregion

        #region Yield moment
        internal double GetCompressionFiberYieldMomentMyc(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Myc = 0.0;
            double Sxc = 0.0;

            double Fy = Section.Material.YieldStress;


            Sxc = GetSectionModulusCompressionSxc( compressionFiberPosition);

            Myc = Fy * Sxc;
            return Myc;
        }

        internal double GetTensionFiberYieldMomentMyt(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Myt = 0.0;
            double Sxt = 0.0;


            double Fy = Section.Material.YieldStress;

            Sxt = GetSectionModulusTensionSxt(compressionFiberPosition);

            Myt = Fy * Sxt;
            return Myt;
        }


        public  double GetSectionModulusCompressionSxc(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Sxc = 0.0;

            switch (compressionFiberPosition)
            {
                case FlexuralCompressionFiberPosition.Top:
                    Sxc = Section.Shape.SectionModulusXTop;
                    break;
                case FlexuralCompressionFiberPosition.Bottom:
                    Sxc = Section.Shape.SectionModulusXBot;
                    break;
                default:
                    throw new CompressionFiberPositionException();
            }

            return Sxc;
        }

        public  double GetSectionModulusTensionSxt( FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Sxt = 0.0;

            switch (compressionFiberPosition)
            {
                case FlexuralCompressionFiberPosition.Top:
                    Sxt = Section.Shape.SectionModulusXBot;
                    break;
                case FlexuralCompressionFiberPosition.Bottom:
                    Sxt = Section.Shape.SectionModulusXTop;
                    break;
                default:
                    throw new CompressionFiberPositionException();
            }

            return Sxt;
        }

        public double GetSectionModulusCompressionSyc(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Syc = 0.0;

            switch (compressionFiberPosition)
            {
                case FlexuralCompressionFiberPosition.Left:
                    Syc = Section.Shape.SectionModulusYLeft;
                    break;
                case FlexuralCompressionFiberPosition.Right:
                    Syc = Section.Shape.SectionModulusYRight;
                    break;
                default:
                    throw new CompressionFiberPositionException();

            }

            return Syc;
        }

        public double GetSectionModulusTensionSyt(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Syc = 0.0;

            switch (compressionFiberPosition)
            {
                case FlexuralCompressionFiberPosition.Left:
                    Syc = Section.Shape.SectionModulusYRight;
                    break;
                case FlexuralCompressionFiberPosition.Right:
                    Syc = Section.Shape.SectionModulusYLeft;
                    break;
                default:
                    throw new CompressionFiberPositionException();

            }

            return Syc;
        }

        #endregion

        #region Design Capacity
        
        internal virtual double GetFlexuralDesignValue(double Mn)
        {


                return 0.9 * Mn;


        }

        #endregion

        #region Compactness Parameter V E/Fy

        protected double SqrtE_Fy()
        {
            ISteelMaterial material = Section.Material;
            double Fy = material.YieldStress;
            double E = material.ModulusOfElasticity;

            if (Fy == 0 || E == 0)
            {
                throw new Exception("Material Fy or E cannot be zero");
            }
            return Math.Sqrt(E / Fy);
        }

        #endregion
    }
}
