namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    public class ChickenParticle : ChaoticParticle
    {
        public ChickenParticle(MatrixCoords position, MatrixCoords speed) : base(position, speed)
        {
        }

        public override IEnumerable<Particle> Update()
        {
            IEnumerable<Particle> current = base.Update();
            List<Particle> allGeneratedObjects = new List<Particle>();
           
            if (new Random().Next(0, 101) % 10 == 0)
            {
                allGeneratedObjects.Add(new ChickenParticle(this.Position, new MatrixCoords(0, 0)));
                Thread.Sleep(1000);        
            }
            allGeneratedObjects.AddRange(current);
            return allGeneratedObjects;
        }
    }
}