using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        private string name = "Name";
        private int damage = 31;
        private int hp = 100;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void Constructor_ShouldInitialize_WithValidParameters()
        {
            var warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.NotNull(warrior);
            Assert.AreEqual(this.name, warrior.Name);
            Assert.AreEqual(this.damage, warrior.Damage);
            Assert.AreEqual(this.hp, warrior.HP);
        }

        [Test]
        public void Constructor_ShouldThrow_WithNullName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, this.damage, this.hp));
        }

        [Test]
        public void Constructor_ShouldThrow_WithEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, this.damage, this.hp));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Constructor_ShouldThrow_WithWhitespaceName(string whitespace)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(whitespace, this.damage, this.hp));
        }

        [Test]
        [TestCase(-100)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Constructor_ShouldThrow_WithInvalidDamage(int invalidDamage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(this.name, invalidDamage, this.hp));
        }

        [Test]
        [TestCase(-100)]
        [TestCase(-1)]
        public void Constructor_ShouldThrow_WithInvalidHp(int invalidHp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(this.name, this.damage, invalidHp));
        }

        [Test]
        public void Name_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.name, this.warrior.Name);
        }

        [Test]
        public void Damage_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.damage, this.warrior.Damage);
        }

        [Test]
        public void Hp_ShouldGetCorrectValue()
        {
            Assert.AreEqual(this.hp, this.warrior.HP);
        }

        [Test]
        [TestCase(100)]
        [TestCase(101)]
        public void Attack_ShouldReduceDefenderHp_ByAttackerDamage(int damage)
        {
            var attacker = new Warrior("Attacker", damage, 100);
            var defender = new Warrior("Defender", 10, 100);
            var ExpectedDefenderHp = Math.Max(0, defender.HP - attacker.Damage);

            attacker.Attack(defender);

            Assert.AreEqual(ExpectedDefenderHp, defender.HP);
        }

        [Test]
        [TestCase(100)]
        [TestCase(101)]
        public void Attack_ShouldReduceAttackerHp_ByDefenderDamage(int damage)
        {
            var attacker = new Warrior("Attacker", damage, 100);
            var defender = new Warrior("Defender", 10, 100);
            var ExpectedAttackerHp = Math.Max(0, attacker.HP - defender.Damage);

            attacker.Attack(defender);

            Assert.AreEqual(ExpectedAttackerHp, attacker.HP);
        }

        [Test]
        [TestCase(100)]
        [TestCase(101)]
        public void Attack_ShouldReduceDefenderHpByAttackerDamage_AndAttackerHpByDefenderDamage(int damage)
        {
            var attacker = new Warrior("Attacker", damage, 100);
            var defender = new Warrior("Defender", 10, 100);
            var ExpectedAttackerHp = Math.Max(0, attacker.HP - defender.Damage);
            var ExpectedDefenderHp = Math.Max(0, defender.HP - attacker.Damage);

            attacker.Attack(defender);

            Assert.AreEqual(ExpectedAttackerHp, attacker.HP);
            Assert.AreEqual(ExpectedDefenderHp, defender.HP);
        }

        [Test]
        [TestCase(101)]
        [TestCase(200)]
        [TestCase(500)]
        [TestCase(1000)]
        public void Attack_ShouldSetDefenderHpToZero_WhenDefenderIsKilled(int damage)
        {
            var attacker = new Warrior("Attacker", damage, 100);
            var defender = new Warrior("Defender", 10, 100);
            var ExpectedDefenderHp = 0;

            attacker.Attack(defender);

            Assert.AreEqual(ExpectedDefenderHp, defender.HP);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(29)]
        [TestCase(30)]
        public void Attack_ShouldThrow_WhenWarriorHpIsTooLow(int hp)
        {
            var warrior = new Warrior("Attacker", 10, hp);
            var enemy = new Warrior("Defender", 10, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(29)]
        [TestCase(30)]
        public void Attack_ShouldThrow_WhenEnemyHpIsTooLow(int hp)
        {
            var enemy = new Warrior("Defender", 10, hp);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemy));
        }

        [Test]
        [TestCase(101)]
        [TestCase(111)]
        [TestCase(291)]
        [TestCase(312)]
        [TestCase(int.MaxValue)]
        public void Attack_ShouldThrow_WhenEnemyDamageIsTooHigh(int damage)
        {
            var enemy = new Warrior("Defender", damage, 100);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemy));
        }
    }
}