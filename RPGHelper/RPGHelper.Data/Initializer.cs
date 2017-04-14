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
                Password = "123"
            };

            User seedUser2 = new User
            {
                Username = "Maria",
                Password = "123"
            };

            User seedUser3 = new User
            {
                Username = "Jean",
                Password = "123"
            };

            Hero seedHero1 = new Hero
            {
                Name = "Ivan",
                Gold = 1000m
            };

            Hero seedHero2 = new Hero
            {
                Name = "Gosho",
                Gold = 1000m
            };

            Hero seedHero3 = new Hero
            {
                Name = "Penko",
                Gold = 1000m
            };

            Hero seedHero4 = new Hero
            {
                Name = "Nencho",
                Gold = 1000m
            };

            Hero seedHero5 = new Hero
            {
                Name = "Kamen",
                Gold = 1000m
            };

            Hero seedHero6 = new Hero
            {
                Name = "Penka",
                Gold = 1000m
            };


            HeroStats herostats1 = new HeroStats
            {
                Hero = seedHero1,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats2 = new HeroStats
            {
                Hero = seedHero2,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats3 = new HeroStats
            {
                Hero = seedHero3,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats4 = new HeroStats
            {
                Hero = seedHero4,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats5 = new HeroStats
            {
                Hero = seedHero5,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
                Affiliation = Affiliation.Dark
            };
            HeroStats herostats6 = new HeroStats
            {
                Hero = seedHero6,
                AttackPower = 120,
                Defence = 100,
                Hp = 900,
                Mana = 300,
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
                Cost = 100m,
                Name = "SeedItem1",
                Description = "some magic item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };

            Item seedItem2 = new Item
            {
                Cost = 100m,
                Name = "SeedItem2",
                Description = "some magic item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };

            Item seedItem3 = new Item
            {
                Cost = 100m,
                Name = "SeedItem3",
                Description = "some magic item",
                ItemType = ItemType.Weapon,
                Rarity = Rarity.Common,
                Slot = Slot.Weapon
            };


            ItemStats itemStats1 = new ItemStats
            {
                Attack = 10,
                Defence = 11,
                Item = seedItem1
            };
            ItemStats itemStats2 = new ItemStats
            {
                Attack = 11,
                Defence = 12,
                Item = seedItem2
            };
            ItemStats itemStats3 = new ItemStats
            {
                Attack = 12,
                Defence = 13,
                Item = seedItem3
            };

            seedItem1.ItemStats = itemStats1;
            seedItem2.ItemStats = itemStats2;
            seedItem3.ItemStats = itemStats3;

            Minion seedMinion1 = new Minion
            {
                Name = "Doge",
                Hp = 10000,
                Attack = 90,
                Defence = 40
            };


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


            seedHero1.Minions.Add(seedMinion1);
            seedHero2.Minions.Add(seedMinion1);
            seedHero3.Minions.Add(seedMinion1);
            seedHero4.Minions.Add(seedMinion1);
            seedHero5.Minions.Add(seedMinion1);
            seedHero6.Minions.Add(seedMinion1);

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

            context.Minions.Add(seedMinion1);

            context.Users.Add(seedUser1);
            context.Users.Add(seedUser2);
            context.Users.Add(seedUser3);

            context.SaveChanges();
        }
    }
}
