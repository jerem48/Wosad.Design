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
 
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wosad.Steel.AISC;
using Wosad.Steel.AISC.AISC360v10.Connections.Bolted;
using Wosad.Steel.AISC.SteelEntities.Bolts;

namespace Wosad.Steel.Tests.AISC.AISC360v10.Connections.Bolt
{
    [TestFixture]
    public class BearingBoltTests
    {

        //AISC Design Guide 29
        //Example 5.1

        //Page 45
         [Test]
        public void BearingBoltGroupAReturnsTensileStrengthA325()
        {
            BoltBearingGroupA bolt = new BoltBearingGroupA(7.0 / 8.0, BoltThreadCase.Included,  null);
            double phi_r_nt = bolt.GetAvailableTensileStrength();
            Assert.AreEqual(40.6, Math.Round(phi_r_nt, 1));    
        }



        //Page 45
        //and
        //AISC Steel Manual 14th Edition Table 7-1
         [Test]
        public void BearingBoltGroupAReturnsShearStrengthA325()
        {
            BoltBearingGroupA bolt = new BoltBearingGroupA(7.0 / 8.0, BoltThreadCase.Excluded,  null);
            double phi_r_nv = bolt.GetAvailableShearStrength(2.0, false);
            Assert.AreEqual(61.3, Math.Round(phi_r_nv,1));        
         }

         //AISC Steel Manual 14th Edition Table 7-1
         [Test]
         public void BearingBoltGroupAReturnsShearStrengthA490()
         {
             BoltBearingGroupB bolt = new BoltBearingGroupB(1.0, BoltThreadCase.Included, null);
             double phi_r_nv = bolt.GetAvailableShearStrength(1,false);
             Assert.AreEqual(40, Math.Floor(phi_r_nv));
         }                                   
     

    }
}
