using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Pesho", 100, 500);
        }

        [Test]
        public void Constructor_ShouldInitializeProperly()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Count);
            Assert.AreNotEqual(null, arena.Warriors);
        }

        [Test]
        public void Enroll_ShouldIncreaseCount_WithValidWarrior()
        {
            this.arena.Enroll(this.warrior);

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddCorrectWarrior_WithValidWarrior()
        {
            this.arena.Enroll(this.warrior);

            Assert.AreEqual(1, this.arena.Count);
            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void Enroll_ShouldThrow_WhenAddingPreviouslyEnrolledWarrior()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.warrior));
        }

        [Test]
        public void Fight_ShouldWorkCorrectly()
        {
            var attacker = this.warrior;
            var defender = new Warrior("Gosho", 50, 1000);
            var attackerExpectedHp = Math.Max(0, attacker.HP - defender.Damage);
            var defenderExpectedHp = Math.Max(0, defender.HP - attacker.Damage);
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(attackerExpectedHp, attacker.HP);
            Assert.AreEqual(defenderExpectedHp, defender.HP);
        }

        [Test]
        public void Fight_ShouldThrow_IfAttackerHasNotBeenEnrolled()
        {
            var defender = new Warrior("Gosho", 50, 1000);
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Pesho", defender.Name));
        }

        [Test]
        public void Fight_ShouldThrow_IfDefenderHasNotBeenEnrolled()
        {
            var attacker = this.warrior;
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, "Gosho"));
        }

        [Test]
        public void Fight_ShouldThrow_IfBothWarriorsDoNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Pesho the crusher", "Gosho the killa"));
        }
    }
}
