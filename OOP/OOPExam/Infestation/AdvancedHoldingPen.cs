using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AdvancedHoldingPen : HoldingPen
    {

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Weapon":
                    var weapon = new Weapon();
                    this.AddSupplement(weapon, commandWords[2]);
                    break;
                case "PowerInhibitor":
                    var power = new PowerInhibitor();
                    this.AddSupplement(power, commandWords[2]);
                    break;
                case "AggressionInhibitor":
                    var aggression = new AggressionInhibitor();
                    this.AddSupplement(aggression, commandWords[2]);
                    break;
                case "HealthInhibitor ":
                    var health = new HealthInhibitor();
                    this.AddSupplement(health, commandWords[2]);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);

                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;
                case InteractionType.Infest:
                    Unit unit = this.GetUnit(interaction.TargetUnit);
                    unit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        private void AddSupplement(ISupplement supplement, string unit)
        {
            this.GetUnit(unit).AddSupplement(supplement);
        }
    }
}