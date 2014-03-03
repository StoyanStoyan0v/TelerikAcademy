namespace WarMachines.Machines
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pilot's name cannot be empty");
                }
                this.name = value;
            }
        }

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            string machinesCount = string.Empty;
            if(this.machines.Count==0)
            {
                machinesCount = "no machines";
            }
            else if(this.machines.Count==1)
            {
                machinesCount = "1 machine" + Environment.NewLine ;
            }
            else
            {
                machinesCount = string.Format("{0} machines"+ Environment.NewLine ,this.machines.Count);
            }

            return string.Format("{0} - {1}{2}",this.Name,machinesCount,
                string.Join(Environment.NewLine ,this.machines.OrderBy(machine=>machine.HealthPoints).ThenBy(machine=>machine.Name)));
        }
    }

    public abstract class Machine : IMachine
    {
        private string name;

        private double attack;

        private double defense;

        private double health;

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid machine name");
                }
                this.name = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attack;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine health cannot be negative");
                }
                this.attack = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defense;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine defense cannot be negative number");
                }
                this.defense = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine health cannot be negative");
                }
                this.health = value;
            }
        }

        public Machine(string name, double attackPoiints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoiints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public void Attack(string target)
        {
        }

        public override string ToString()
        {
            return string.Format("- {0} *Type: {1} *Health: {2} *Attack: {3} *Defense: {4} *Targets: {5}",this.Name + Environment.NewLine,
                this.GetType().Name + Environment.NewLine, this.HealthPoints + Environment.NewLine, this.AttackPoints + Environment.NewLine,
                this.DefensePoints + Environment.NewLine, this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets));
        }
    }

    public class Tank : Machine, ITank
    {
        public bool DefenseMode { get; private set; }

        public Tank(string name, double atkPoints, double defPoints) : base(name,atkPoints,defPoints)
        {
            this.HealthPoints = 100;
            this.ToggleDefenseMode();
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !DefenseMode;
            if (DefenseMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} *Defense: {1}", base.ToString() + Environment.NewLine, this.DefenseMode ? "ON" : "OFF");
        }
    }

    public class Fighter : Machine, IFighter
    {
        public bool StealthMode { get; private set; }

        public Fighter(string name, double atkPoints, double defPoints, bool stealth) : base(name,atkPoints,defPoints)
        {
            this.HealthPoints = 200;
            this.StealthMode = stealth;
        }

        public void ToggleStealthMode()
        {
            if (StealthMode)
            {
                this.StealthMode = false;
            }
            else
            {
                this.StealthMode = true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} *Stealth: {1}", base.ToString() + Environment.NewLine, this.StealthMode ? "ON" : "OFF");
        }
    }
}