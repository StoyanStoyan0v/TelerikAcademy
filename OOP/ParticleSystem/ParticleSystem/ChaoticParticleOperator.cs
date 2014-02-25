using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChaoticParticleOperator : ParticleUpdater
    {
        private Random rand = new Random();
        
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var chaotircParticle = p as ChaoticParticle;

            if (chaotircParticle != null)
            {
                chaotircParticle.ChaoticSpeed = new MatrixCoords(rand.Next(-2, 3), rand.Next(-2, 3));
            }
            return base.OperateOn(p);          
        }
    }
}