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
using System.Threading.Tasks;

namespace Wosad.Analysis.Section
{
    public partial class SectionStressAnalysis
    {
        /// <summary>
        /// Normal stress due to warping in open cross section
        /// </summary>
        /// <param name="E">Modulus of elasticity</param>
        /// <param name="W_ns">Normalized warping function at point s</param>
        /// <param name="theta_2der">Second derivative of angle of rotation with respect to z</param>
        /// <returns></returns>
        public double GetNormalStressDueToWarpingOpenSection(double E, double W_ns, double theta_2der)
        {
            double sigma_w = E * W_ns * theta_2der; //AISC Design Guide 9 Equation(4.3a)
            return sigma_w;
        }
    }
}
