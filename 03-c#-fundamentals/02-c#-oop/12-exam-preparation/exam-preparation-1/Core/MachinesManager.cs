namespace MortalEngines.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private Dictionary<string, IPilot> pilotByName = new Dictionary<string, IPilot>();

        private Dictionary<string, IMachine> machineByName = new Dictionary<string, IMachine>();

        public string HirePilot(string name)
        {
            if (this.pilotByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            this.pilotByName[name] = new Pilot(name);
            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machineByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var tank = new Tank(name, attackPoints, defensePoints);
            this.machineByName[name] = tank;
            return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machineByName.ContainsKey(name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var fighter = new Fighter(name, attackPoints, defensePoints);
            this.machineByName[name] = fighter;
            return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (this.pilotByName.ContainsKey(selectedPilotName) == false)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (this.machineByName.ContainsKey(selectedMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            var pilot = this.pilotByName[selectedPilotName];
            var machine = this.machineByName[selectedMachineName];

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (this.machineByName.ContainsKey(attackingMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (this.machineByName.ContainsKey(defendingMachineName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            var attacker = this.machineByName[attackingMachineName];
            var defender = this.machineByName[defendingMachineName];

            if (attacker.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attacker.Name);
            }
            else if (defender.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defender.Name);
            }

            attacker.Attack(defender);
            return string.Format(OutputMessages.AttackSuccessful, defender.Name, attacker.Name, defender.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilotByName[pilotReporting].Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machineByName[machineName].ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machineByName.ContainsKey(fighterName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            var fighter = (IFighter)this.machineByName[fighterName];
            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighter.Name);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machineByName.ContainsKey(tankName) == false)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            var tank = (ITank)this.machineByName[tankName];
            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
        }
    }
}
