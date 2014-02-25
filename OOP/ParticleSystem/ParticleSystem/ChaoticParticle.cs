using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        public MatrixCoords ChaoticSpeed { get; set; }

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed) : base(position,speed)
        {
            this.ChaoticSpeed = speed;
            
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)1 } };
        }

        protected override void Move()
        {
            this.Position += this.ChaoticSpeed;
        }
        
    }
}