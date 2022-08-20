using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void HeroCtorShouldWork()
    {
        Hero hero = new Hero("Thor", 20);

        Assert.AreEqual("Thor", hero.Name);
        Assert.AreEqual(20, hero.Level);
    }

    [Test]
    public void CreateHeroShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Thor", 20);
        repo.Create(hero);

        Assert.AreEqual(1, repo.Heroes.Count);
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
    public void CreateHeroExistShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero = new Hero("Thor", 20);
        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repo.Create(new Hero("Thor", 20));
        });
    }

    [Test]
    public void RemoveHeroShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.IsTrue(repo.Remove("Thor"));
    }

    [Test]
    public void RemoveHeroCounterShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Remove("Thor");

        Assert.AreEqual(1, repo.Heroes.Count);
    }

    [Test]
    public void RemoveHeroNullShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);
        string name = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Remove(name);
        });
    }

    [Test]
    public void RemoveHeroWhiteSpaceShouldThrowException()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);
        string name = " ";

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Remove(name);
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.AreEqual(hero1, repo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.AreEqual(hero1, repo.GetHero("Thor"));
    }

    [Test]
    public void GetHeroNullShouldWork()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Thor", 20);
        Hero hero2 = new Hero("SpiderMan", 15);
        repo.Create(hero1);
        repo.Create(hero2);

        Assert.Null(repo.GetHero("Some Hero.."));
    }
}