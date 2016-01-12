﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wosad.Common.CalculationLogger;
using Wosad.Common.Entities;
using Wosad.Common.Section.Interfaces;
using Wosad.Common.Section.SectionTypes;


namespace Wosad.Common.Section.Predefined
{
    public class AiscShapeFactory
    {

        public ISection GetShape(string ShapeId, ShapeTypeSteel shapeType)
        {

            string DEFAULT_EXCEPTION_STRING = "Selected shape is not supported. Specify a different shape.";
            AiscCatalogShape cs = new AiscCatalogShape(ShapeId,null);
            CalcLog log = new CalcLog();
            ISection sec = null;

            switch (shapeType)
            {
                case ShapeTypeSteel.IShapeRolled:
                    sec = new PredefinedSectionI(cs);
                    break;
                case ShapeTypeSteel.IShapeBuiltUp:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.Channel:
                    sec = new PredefinedSectionChannel(cs);
                    break;
                case ShapeTypeSteel.Angle:
                    sec = new PredefinedSectionAngle(cs);
                    break;
                case ShapeTypeSteel.TeeRolled:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.TeeBuiltUp:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.DoubleAngle:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.CircularHSS:
                    sec = new PredefinedSectionCHS(cs);
                    break;
                case ShapeTypeSteel.RectangularHSS:
                    sec = new PredefinedSectionRHS(cs);
                    break;
                case ShapeTypeSteel.Box:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.Rectangular:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.Circular:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                case ShapeTypeSteel.IShapeAsym:
                    throw new Exception(DEFAULT_EXCEPTION_STRING);
                    break;
                default:
                    break;
            }

            return sec;
        }

        private double GetAngleGap(string ShapeId)
        {
            double gap=0;

            string[] strings = ShapeId.Split('X');
            if (strings.Count() == 4)
            {
                string gapStr = strings[3];
                string gs;
                if (gapStr.Contains("LLBB") || gapStr.Contains("SLBB"))
                {
                    gs = gapStr.Substring(0, gapStr.Length - 5);
                }
                else
                {
                    gs = gapStr;
                }
                string[] gsFraction = gs.Split('/');
                if (gsFraction.Count() ==2)
                {
                    double num = double.Parse(gsFraction[0]);
                    double den = double.Parse(gsFraction[1]);
                    gap = num / den;
                }
            }

            return gap;
        }


    }
}
