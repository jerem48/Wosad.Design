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
using Wosad.Common.Section.Interfaces;


namespace Wosad.Steel.AISC.AISC360v10.Flexure
{
    public abstract partial class FlexuralMemberIBase : FlexuralMember
    {

        public double GetIyc(FlexuralCompressionFiberPosition compressionFiberPosition)
        {
            double Iyc = 0.0;
            double tf;
            double bf;

            if (compressionFiberPosition == FlexuralCompressionFiberPosition.Top)
            {
                tf = this.Get_tfTop();
                bf = this.GetBfTop();
            }
            else
            {
                tf = this.Get_tfBottom();
                bf = this.GetBfBottom();

            }

            Iyc = tf * Math.Pow(bf, 3) / 12.0;

            return Iyc;
        }
    }
}
