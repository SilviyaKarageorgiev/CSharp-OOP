using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{

    [Test]
    public void ConstructorShouldWorkProperly()
    {
        HeroRepository repo = new HeroRepository();

        Assert.AreEqual(0, repo.Heroes.Count);
    }

    [Test]
    public void CreateHeroValidDataShouldWorkProperly()
    {
        HeroRepository repo = new HeroRepository();
        repo.Create(new Hero("Thor", 30));
        repo.Create(new Hero("Spider-Man", 20));

        Assert.AreEqual(2, repo.Heroes.Count);
    }

    [Test]
    public void CreateHeroNullShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Create(hero);
        });
    }

    [Test]
    public void CreateHeroWhoExistShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        repo.Create(new Hero("Thor", 30));

        Assert.Throws<InvalidOperationException>(() =>
        {
            repo.Create(new Hero("Thor", 30));
        });
    }

    [Test]
    public void RemoveHeroShouldWorkProperly()
    {
        HeroRepository repo = new HeroRepository();
        repo.Create(new Hero("Thor", 30));
        repo.Create(new Hero("Spider-Man", 20));
        repo.Remove("Spider-Man");

        Assert.AreEqual(1, repo.Heroes.Count);
    }

    [Test]
    public void RemoveHeroWithNullNameShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        repo.Create(new Hero("Thor", 30));
        repo.Create(new Hero("Spider-Man", 20));

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Remove(null);
        });
    }

    [Test]
    public void RemoveHeroWithWhiteSpaceNameShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        repo.Create(new Hero("Thor", 30));
        repo.Create(new Hero("Spider-Man", 20));

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Remove("   ");
        });
    }

    [Test]
    public void GetHeroWithHighestLevelHeroShouldWorkProperly()
    {
        HeroRepository repo = new HeroRepository();

        Hero hero1 = new Hero("Thor", 30);
        Hero hero2 = new Hero("Spider-Man", 20);
        Hero hero3 = new Hero("The Hulk", 50);
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        Assert.AreEqual(hero3, repo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroByNameShouldWorkProperly()
    {
        HeroRepository repo = new HeroRepository();

        Hero hero1 = new Hero("Thor", 30);
        Hero hero2 = new Hero("Spider-Man", 20);
        Hero hero3 = new Hero("The Hulk", 50);
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        Assert.AreEqual(hero1, repo.GetHero("Thor"));
    }



}