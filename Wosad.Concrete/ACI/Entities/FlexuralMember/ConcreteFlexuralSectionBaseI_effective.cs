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
using Wosad.Common.Entities;
using Wosad.Common.Mathematics;
using Wosad.Common.Section.Interfaces;
using Wosad.Common.Section.SectionTypes;



namespace Wosad.Concrete.ACI
{
    public abstract partial class ConcreteFlexuralSectionBase : ConcreteSectionLongitudinalReinforcedBase, IConcreteFlexuralMember
    {
        public virtual double GetCrackedMomentOfInertia(FlexuralCompressionFiberPosition compFiberPosition, double I_cracked, double I_cracking, double M_service)
        {

        }
    }
}
