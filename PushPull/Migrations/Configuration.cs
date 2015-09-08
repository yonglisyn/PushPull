using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using PushPull.DataAccessLayer;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
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
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.ImportantAndNotUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World2",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.NotStarted,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.NotImportantAndUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World3",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.NotStarted,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.NotImportantAndNotUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 4",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.NotStarted,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.ImportantAndUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 5",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.Completed,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.ImportantAndNotUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 6",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.Completed,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.NotImportantAndUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 7",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.Completed,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.NotImportantAndNotUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 8",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.Completed,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                },
                new TaskCard
                {
                    UserId = 1,
                    DeadLine = DateTime.Today.AddDays(10),
                    EisenHowerType = EisenHowerType.ImportantAndNotUrgent,
                    Card =
                        new Card
                        {
                            Content = "Seed data Hello World 9",
                            AssetType = AssetType.Money,
                            PullValue = 10,
                            PushValue = 10,
                            Status = CardStatus.Failed,
                            Tag = "Seed",
                            ValueUnit = "$"
                        },
                    ModifiedBy = "Yongli",
                    ModifiedOn = DateTime.Today
                }
            };
        }

        private List<Asset> SeedAssets()
        {
            return new List<Asset>
            {
                new Asset
                {
                    AssetType = AssetType.Money,
                    AssetPurpose = AssetPurpose.Pull,
                    AssetValue = 100,
                    UserId = 1,
                    ModifiedOn = DateTime.Today,
                    ModifiedBy = "Yongli"
                },
                new Asset
                {
                    AssetType = AssetType.Money,
                    AssetPurpose = AssetPurpose.Push,
                    AssetValue = 20,
                    UserId = 1,
                    ModifiedOn = DateTime.Today,
                    ModifiedBy = "Yongli"
                },
                new Asset
                {
                    AssetType = AssetType.Time,
                    AssetPurpose = AssetPurpose.Pull,
                    AssetValue = 100,
                    UserId = 1,
                    ModifiedOn = DateTime.Today,
                    ModifiedBy = "Yongli"
                },
                new Asset
                {
                    AssetType = AssetType.Time,
                    AssetPurpose = AssetPurpose.Push,
                    AssetValue = 109,
                    UserId = 1,
                    ModifiedOn = DateTime.Today,
                    ModifiedBy = "Yongli"
                }
            };
        }
    }
}
