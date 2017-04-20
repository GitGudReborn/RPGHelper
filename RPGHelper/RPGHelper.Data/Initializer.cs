using RPGHelper.Models;
using RPGHelper.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper.Data
{
    public class Initializer : DropCreateDatabaseIfModelChanges<RPGHelperContext>
    {
        protected override void Seed(RPGHelperContext context)
        {
            User seedUser1 = new User
            {
                Username = "Stoyan",
                Password = "123",
                Birthdate = new DateTime(1989,11,24),
                FirstName = "Stoyan",
                LastName = "Grigorov",
                Gender = Gender.Male,
                Email = "stoyan@test.bg"
            };

            User seedUser2 = new User
            {
                Username = "Maria",
                Password = "123"
            };

            User seedUser3 = new User
            {
                Username = "Jean",
                Password = "123",
                Birthdate = new DateTime(1997,11,11),
                FirstName = "Jean",
                LastName = "Petrov",
                Gender = Gender.Male,
                Email = "narumcyt@gmail.com"
            };

            Hero seedHero1 = new Hero
            {
                Name = "Kunkka",
                Gold = 1000m
            };

            Hero seedHero2 = new Hero
            {
                Name = "Sven",
                Gold = 1000m
            };

            Hero seedHero3 = new Hero
            {
                Name = "Mirana",
                Gold = 1000m
            };

            Hero seedHero4 = new Hero
            {
                Name = "Luna",
                Gold = 1000m
            };

            Hero seedHero5 = new Hero
            {
                Name = "Lich",
                Gold = 1000m
            };

            Hero seedHero6 = new Hero
            {
                Name = "Axe",
                Gold = 1000m
            };


            HeroStats herostats1 = new HeroStats
            {
                Hero = seedHero1,
                AttackPower = 102,
                Defence = 7,
                Hp = 1404,
                Mana = 507,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats2 = new HeroStats
            {
                Hero = seedHero2,
                AttackPower = 104,
                Defence = 9,
                Hp = 1305,
                Mana = 445,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats3 = new HeroStats
            {
                Hero = seedHero3,
                AttackPower = 95,
                Defence = 8,
                Hp = 965,
                Mana = 521,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats4 = new HeroStats
            {
                Hero = seedHero4,
                AttackPower = 90,
                Defence = 9,
                Hp = 1020,
                Mana = 545,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats5 = new HeroStats
            {
                Hero = seedHero5,
                AttackPower = 97,
                Defence = 5,
                Hp = 904,
                Mana = 826,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats6 = new HeroStats
            {
                Hero = seedHero6,
                AttackPower = 88,
                Defence = 6,
                Hp = 1290,
                Mana = 525,
                Affiliation = Affiliation.Dark
            };

            seedHero1.HeroStats = herostats1;
            seedHero2.HeroStats = herostats2;
            seedHero3.HeroStats = herostats3;
            seedHero4.HeroStats = herostats4;
            seedHero5.HeroStats = herostats5;
            seedHero6.HeroStats = herostats6;

            Item seedItem1 = new Item
            {
                Cost = 6200m,
                Name = "DIVINE RAPIER",
                Description = "some dmg item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };

            Item seedItem2 = new Item
            {
                Cost = 465m,
                Name = "MAGIC WAND",
                Description = "some magic item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };

            Item seedItem3 = new Item
            {
                Cost = 2720m,
                Name = "DAGON",
                Description = "some magic item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };


            ItemStats itemStats1 = new ItemStats
            {
                Attack = 10,
                Defence = 11
            };
            ItemStats itemStats2 = new ItemStats
            {
                Attack = 11,
                Defence = 12
            };
            ItemStats itemStats3 = new ItemStats
            {
                Attack = 12,
                Defence = 13
            };

            seedItem1.ItemStats = itemStats1;
            seedItem2.ItemStats = itemStats2;
            seedItem3.ItemStats = itemStats3;

            seedHero1.Items.Add(seedItem1);
            seedHero1.Items.Add(seedItem2);

            seedHero2.Items.Add(seedItem2);
            seedHero2.Items.Add(seedItem3);

            seedHero3.Items.Add(seedItem1);
            seedHero3.Items.Add(seedItem3);

            seedHero4.Items.Add(seedItem1);
            seedHero4.Items.Add(seedItem2);

            seedHero5.Items.Add(seedItem2);
            seedHero5.Items.Add(seedItem3);

            seedHero6.Items.Add(seedItem1);
            seedHero6.Items.Add(seedItem3);

            seedUser1.Heroes.Add(seedHero1);
            seedUser1.Heroes.Add(seedHero2);
            seedUser2.Heroes.Add(seedHero3);
            seedUser2.Heroes.Add(seedHero4);
            seedUser3.Heroes.Add(seedHero5);
            seedUser3.Heroes.Add(seedHero6);

            context.Heroes.Add(seedHero1);
            context.Heroes.Add(seedHero2);
            context.Heroes.Add(seedHero3);
            context.Heroes.Add(seedHero4);
            context.Heroes.Add(seedHero5);
            context.Heroes.Add(seedHero6);

            context.Items.Add(seedItem1);
            context.Items.Add(seedItem2);
            context.Items.Add(seedItem3);


            seedUser1.Friends.Add(seedUser2);
            seedUser1.Friends.Add(seedUser3);
            seedUser2.Friends.Add(seedUser1);



            context.Users.Add(seedUser1);
            context.Users.Add(seedUser2);
            context.Users.Add(seedUser3);
            context.SaveChanges();

            itemStats1.ItemId = seedItem1.Id;
            itemStats2.ItemId = seedItem2.Id;
            itemStats3.ItemId = seedItem3.Id;
            context.SaveChanges();

            seedItem1.ItemStatsId = itemStats1.Id;
            seedItem2.ItemStatsId = itemStats2.Id;
            seedItem3.ItemStatsId = itemStats3.Id;
            context.SaveChanges();
        }
    }
}
