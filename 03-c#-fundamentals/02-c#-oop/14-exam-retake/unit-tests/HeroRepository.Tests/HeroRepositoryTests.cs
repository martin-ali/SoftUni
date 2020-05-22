using System;
using NUnit.Framework;

// namespace HeroRepository.Tests
// {
public class HeroRepositoryTests
{
    private string name;
    private int level;

    private Hero hero;

    private HeroRepository heroRepository;

    [SetUp]
    public void Setup()
    {
        this.name = "Pesho";
        this.level = 110;

        this.hero = new Hero(this.name, this.level);

        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void Constructor_ShouldInitializeProperly()
    {
        var heroRepository = new HeroRepository();

        Assert.IsNotNull(heroRepository.Heroes);
    }

    [Test]
    public void Create_ShouldIncreaseHeroCount()
    {
        this.heroRepository.Create(this.hero);

        Assert.AreEqual(1, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void Create_ShouldCreateCorrectHero_WithValidHero()
    {
        this.heroRepository.Create(this.hero);

        Assert.That(this.heroRepository.Heroes, Has.Member(this.hero));
    }

    [Test]
    public void Create_ShouldThrow_WithNullHero()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]
    public void Create_ShouldThrow_WithDuplicateHero()
    {
        this.heroRepository.Create(this.hero);

        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(this.hero));
    }

    [Test]
    public void Remove_ShouldDecreaseHeroesCount()
    {
        this.heroRepository.Create(this.hero);

        Assert.AreEqual(1, this.heroRepository.Heroes.Count);

        this.heroRepository.Remove(this.hero.Name);

        Assert.AreEqual(0, this.heroRepository.Heroes.Count);
    }

    [Test]
    public void Remove_ShouldRemoveCorrectHero()
    {
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(new Hero("DoNotRemoveMe", 11));

        this.heroRepository.Remove(this.hero.Name);

        Assert.That(this.heroRepository.Heroes, Has.No.Member(this.hero));
    }

    [Test]
    public void Remove_ShouldThrow_WithNullName()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(null));
    }

    [Test]
    public void Remove_ShouldThrow_WithEmptyName()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(string.Empty));
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("          ")]
    public void Remove_ShouldThrow_WithWhitespaceName(string name)
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
    }

    [Test]
    public void GetHeroWithHighestLevel_ShouldReturnCorrectHero()
    {
        this.heroRepository.Create(hero);
        this.heroRepository.Create(new Hero("DoNotRemoveMe", 11));

        var actualHero = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreSame(this.hero, actualHero);
    }

    [Test]
    public void GetHero_ShouldReturnCorrectHero()
    {
        this.heroRepository.Create(hero);

        var actualHero = this.heroRepository.GetHero(this.hero.Name);

        Assert.AreSame(this.hero, actualHero);
    }
}
// }