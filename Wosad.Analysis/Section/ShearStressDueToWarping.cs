﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wosad.Analysis.Section
{
    public partial class SectionStressAnalysis
    {
        /// <summary>
        /// Shear stress due to warping in open cross section
        /// </summary>
        /// <param name="E">Modulus of elasticity</param>
        /// <param name="S_ws">Warping statical moment at point s</param>
        /// <param name="t_el">Thickness of element</param>
        /// <param name="theta_3der">Third derivative of angle of rotation with respect to z</param>
        /// <returns></returns>
        public double GetShearStressDueToWarpingOpenSecton(double E, double S_ws,double t_el,  double theta_3der)
        {
            double tau_w = (-E * S_ws * theta_3der) / t_el; //AISC Design Guide 9 Equation(4.2a)
            return tau_w;
        }
    }
}
