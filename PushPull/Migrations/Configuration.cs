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
        private readonly SeedBank _SeedBank;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            _SeedBank = new SeedBank();
        }


        protected override void Seed(ApplicationDbContext context)
        {
            context.TaksCards.AddOrUpdate(SeedTaskCards().ToArray());
            context.Assets.AddOrUpdate(SeedAssets().ToArray());
            context.DailyReports.AddOrUpdate(SeedDailyReports().ToArray());
            context.WeeklyReports.AddOrUpdate(SeedWeeklyReports().ToArray());
            context.SaveChanges();

        }


        private List<WeeklyTaskReport> SeedWeeklyReports()
        {
            var random = new Random();
            return new List<WeeklyTaskReport>
            {
                _SeedBank.DefaultWeeklyTaskReport,
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-1),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-2),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-3),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-4),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-5),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-6),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-7),
                _SeedBank.DefaultWeeklyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-8),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-1),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-2),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-3),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-4),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-5),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-6),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-1),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-2),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-3),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-4),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-5),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-6),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-1),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-2),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-3),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-4),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-5),
                _SeedBank.DefaultWeeklyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithWeekIndex(-6)
            };
        }

        private List<DailyTaskReport> SeedDailyReports()
        {
            var random = new Random();
            var today = DateTime.Today;
            return new List<DailyTaskReport>
            {
                _SeedBank.DefaultDailyTaskReport,
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-1)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-2)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-3)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-4)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-5)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-6)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-7)),
                _SeedBank.DefaultDailyTaskReport.WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-8)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-1)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-2)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-3)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-4)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-5)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.ImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-6)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-1)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-2)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-3)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-4)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-5)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-6)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-1)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-2)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-3)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-4)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-5)),
                _SeedBank.DefaultDailyTaskReport.WithType(EisenHowerType.NotImportantAndNotUrgent).WithValues(random.Next(1,10),random.Next(1,10)).WithDate(today.AddDays(-6)),
            };
        }

        private List<TaskCard> SeedTaskCards()
        {
            return new List<TaskCard>
            {
                _SeedBank.DefaultTaskCard, 
                _SeedBank.DefaultTaskCard.WithContent("seed 2"), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndNotUrgent).WithStatus(CardStatus.NotStarted), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndNotUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.NotImportantAndUrgent).WithStatus(CardStatus.NotStarted), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.NotImportantAndUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.NotImportantAndNotUrgent).WithStatus(CardStatus.NotStarted), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.NotImportantAndNotUrgent).WithStatus(CardStatus.NotStarted).WithContent("seed 2"),
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Completed),
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Completed).WithContent("seed 3"), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Failed), 
                _SeedBank.DefaultTaskCard.WithType(EisenHowerType.ImportantAndUrgent).WithStatus(CardStatus.Failed).WithContent("seed 3"),
            };
        }

        private List<Asset> SeedAssets()
        {
            var random = new Random();
            var today = DateTime.Today;
            return new List<Asset>
            {
                _SeedBank.DefaultAsset.WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-1))
                    .WithDayOfWeek((int) (today.AddDays(-1)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-2))
                    .WithDayOfWeek((int) (today.AddDays(-2)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-3))
                    .WithDayOfWeek((int) (today.AddDays(-3)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-4))
                    .WithDayOfWeek((int) (today.AddDays(-4)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-5))
                    .WithDayOfWeek((int) (today.AddDays(-5)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithDate(today.AddDays(-6))
                    .WithDayOfWeek((int) (today.AddDays(-6)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push).WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-1))
                    .WithDayOfWeek((int) (today.AddDays(-1)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-2))
                    .WithDayOfWeek((int) (today.AddDays(-2)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-3))
                    .WithDayOfWeek((int) (today.AddDays(-3)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-4))
                    .WithDayOfWeek((int) (today.AddDays(-4)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-5))
                    .WithDayOfWeek((int) (today.AddDays(-5)).DayOfWeek)
                    .WithValue(null, random),
                _SeedBank.DefaultAsset.WithPurpose(AssetPurpose.Push)
                    .WithDate(today.AddDays(-6))
                    .WithDayOfWeek((int) (today.AddDays(-6)).DayOfWeek)
                    .WithValue(null, random)

            };
        }
    }
}
