using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PushPull.DataAccessLayer;
using PushPull.Enums;
using PushPull.Helpers.Extensions;
using PushPull.Models;

namespace PushPull.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public TaskCard DefaultTaskCard
        {
            get
            {
                return
                    new TaskCard
                    {
                        UserId = 1,
                        DeadLine = DateTime.Today.AddDays(10),
                        EisenHowerType = EisenHowerType.ImportantAndUrgent,
                        Card =
                            new Card
                            {
                                Content = "Seed data Hello World",
                                AssetType = AssetType.Money,
                                PullValue = 10,
                                PushValue = 10,
                                Status = CardStatus.NotStarted,
                                Tag = "Seed",
                                ValueUnit = "$"
                            },
                        ModifiedBy = "Yongli",
                        ModifiedOn = DateTime.Today
                    };
            }
        }

        public Asset DefaultAsset
        {
            get
            {
                return new Asset
                {
                    UserId = 1,
                    AssetType = AssetType.Money,
                    AssetPurpose = AssetPurpose.Pull,
                    AssetValue = 100,
                    Date = DateTime.Today,
                    DayOfWeek = (int) DateTime.Today.DayOfWeek,
                    ModifiedOn = DateTime.Today,
                    ModifiedBy = "Yongli"
                };
            }
        }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            context.TaksCards.AddOrUpdate(SeedTaskCards().ToArray());
            context.Assets.AddOrUpdate(SeedAssets().ToArray());
            context.SaveChanges();

        }

        private List<TaskCard> SeedTaskCards()
        {
            return new List<TaskCard>
            {
                DefaultTaskCard,
                DefaultTaskCard.WithContent("seed 2"),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndNotUrgent).WithStatus(CardStatus.NotStarted),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndNotUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"),
                DefaultTaskCard.WithType(EisenHowerType.NotImportantAndUrgent).WithStatus(CardStatus.NotStarted),
                DefaultTaskCard.WithType(EisenHowerType.NotImportantAndUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"),
                DefaultTaskCard.WithType(EisenHowerType.NotImportantAndNotUrgent).WithStatus(CardStatus.NotStarted),
                DefaultTaskCard.WithType(EisenHowerType.NotImportantAndNotUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Completed),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Completed).WithContent("seed 3"),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Failed),
                DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Failed).WithContent("seed 3"),
            };
        }

        private List<Asset> SeedAssets()
        {
            var random = new Random();
            return new List<Asset>
            {
                DefaultAsset.WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-1))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-1)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-2))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-2)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-3))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-3)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-4))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-4)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-5))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-5)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithDate(DateTime.Today.AddDays(-6))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-6)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push).WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-1))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-1)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-1))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-1)).DayOfWeek)
                    .WithValue(200m, random)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-2))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-2)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-3))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-3)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-4))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-4)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-5))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-5)).DayOfWeek)
                    .WithValue(null, random),
                DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(DateTime.Today.AddDays(-6))
                    .WithDayOfWeek((int) (DateTime.Today.AddDays(-6)).DayOfWeek)
                    .WithValue(null, random)

            };
        }
    }
}
