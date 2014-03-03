namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;
    using System.Collections.Generic;
    using System;

    public class MachineFactory : IMachineFactory
    {
        private List<string> usedNames = new List<string>();
 
        public IPilot HirePilot(string name)
        {
            if (usedNames.Contains(name))
            {
                throw new ArgumentException("Duplicate names not allowed");
            }
            else
            {
                usedNames.Add(name);
                return new Pilot(name);
            }
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (usedNames.Contains(name))
            { 
                throw new ArgumentException("Duplicate names not allowed");
            }
            else
            {
                usedNames.Add(name);
                return new Tank(name, attackPoints, defensePoints);
            }
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            if (usedNames.Contains(name))
            { 
                throw new ArgumentException("Duplicate names not allowed");
                
            }
            else
            {
                usedNames.Add(name);
                return new Fighter(name,attackPoints,defensePoints,stealthMode);
            }
        }
    }
}