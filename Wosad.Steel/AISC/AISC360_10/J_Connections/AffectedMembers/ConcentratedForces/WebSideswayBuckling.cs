﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wosad.Steel.AISC.AISC360_10.J_Connections.AffectedMembers.ConcentratedForces
{
    // WebSideswayBuckling
    public static partial class FlangeOrWebWithConcentratedForces
    {
        /// <summary>
        /// Web sidesway buckling strength
        /// </summary>
        /// <param name="t_w">Web thickness</param>
        /// <param name="t_f">Flange thickness</param>
        /// <param name="h">clear distance between flanges less the fillet or corner radius for rolled shapes; distance between adjacent lines of fasteners or the clear distance between flanges when welds are used for built-up shapes,</param>
        /// <param name="L_b">largest laterally unbraced lengthalong either flange at the point of load, in.</param>
        /// <param name="b_f">Flange width</param>
        /// <param name="CompressionFlangeRestrained"></param>
        /// <param name="M_u">Design moment</param>
        /// <param name="M_y">Yield moment</param>
        /// <returns></returns>
        public static double WebSideswayBucklingStrength(double t_w, double t_f, double h,
            double L_b, double b_f, bool CompressionFlangeRestrained, double M_u, double M_y)
        {
            double C_r = GetC_r(M_u, M_y);
            double R_n = 0.0;
            if (CompressionFlangeRestrained ==true)
            {
                if((h/t_w)/(L_b/b_f)<=2.3)
                {
                    //(J10-6)
                    R_n = ((C_r * Math.Pow(t_w, 3) * t_f) / (Math.Pow(h, 2))) * (1 + 0.4 * Math.Pow((((((h) / (t_w))) / (((L_b) / (b_f))))), 3));
                }
                else
	            {
                    R_n = double.PositiveInfinity;
	            }
            }
            else
            {
                if ((h / t_w) / (L_b / b_f) <= 1.7)
                {
                    //(J10-7)
                    R_n = ((C_r * Math.Pow(t_w, 3) * t_f) / (Math.Pow(h, 2))) * (0.4 * Math.Pow((((((h) / (t_w))) / (((L_b) / (b_f))))), 3));
                }
                else
                {
                    R_n = double.PositiveInfinity;
                }
                 
            }
            return 0.85 * R_n;
        }

        private double GetC_r(double M_u, double M_y)
        {
            if (M_u<M_y)
            {
                return 960000.0;
            }
            else
            {
                return 480000.0;
            }

        }
    }
}
