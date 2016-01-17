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
using Wosad.Common.Section.Interfaces;


namespace Wosad.Common.Section.Predefined
{
    /// <summary>
    /// Predefined L-section is used for single angles having known properties 
    /// from catalog (such as AISC shapes)
    /// </summary>
    public class PredefinedSectionAngle : SectionPredefinedBase, ISectionAngle
    {

        public PredefinedSectionAngle(AiscCatalogShape section)
            : base(section)
        {
            this._d = section.d;
            this._b = section.b;
            this._t = section.t;
            //OverrideCentroids(); not necessary
        }


        public PredefinedSectionAngle(
                                    double Height,
                                    double Thickness,
                                    double Width,
                                    double MomentOfInertiaPrincipalMajor,
                                    double MomentOfInertiaPrincipalMinor,
                                    double SectionModulusPrincipalMajor,
                                    double SectionModulusPrincipalMinor,
                                    double RadiusOfGyrationPrincipalMajor,
                                    double RadiusOfGyrationPrincipalMinor, ISection section)
            : base(section)
        {
            this._d                         =Height                         ;
            this._t                      =Thickness                      ;
            this._b                          =Width                          ;
            this.momentOfInertiaPrincipalMajor  =MomentOfInertiaPrincipalMajor  ;
            this.momentOfInertiaPrincipalMinor  =MomentOfInertiaPrincipalMinor  ;
            this.sectionModulusPrincipalMajor   =SectionModulusPrincipalMajor   ;
            this.sectionModulusPrincipalMinor   =SectionModulusPrincipalMinor   ;
            this.radiusOfGyrationPrincipalMajor =RadiusOfGyrationPrincipalMajor ;
            this.radiusOfGyrationPrincipalMinor =RadiusOfGyrationPrincipalMinor ;
        }

        double _d;

        public double d
        {
            get { return _d; }
            set { _d = value; }
        }
        double _t;

        public double t
        {
            get { return _t; }
        }
        double _b;

        public double b
        {
            get { return _b; }
        }

        double momentOfInertiaPrincipalMajor;

        public double MomentOfInertiaPrincipalMajor
        {
            get { return momentOfInertiaPrincipalMajor; }
        }
        double momentOfInertiaPrincipalMinor;

        public double MomentOfInertiaPrincipalMinor
        {
            get { return momentOfInertiaPrincipalMinor; }
        }

        double sectionModulusPrincipalMajor;

        public double S_major
        {
            get { return sectionModulusPrincipalMajor; }
        }
        double sectionModulusPrincipalMinor;

        public double S_minor
        {
            get { return sectionModulusPrincipalMinor; }
        }

        double radiusOfGyrationPrincipalMajor;

        public double r_major
        {
            get { return radiusOfGyrationPrincipalMajor; }
        }
        double radiusOfGyrationPrincipalMinor;

        public double r_minor
        {
            get { return radiusOfGyrationPrincipalMinor; }
        }


        public ISection GetWeakAxisClone()
        {
            throw new NotImplementedException();
        }

        //public override ISection Clone()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
