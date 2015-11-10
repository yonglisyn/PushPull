using System;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.Migrations
{
    internal sealed class SeedBank
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

        public DailyTaskReport DefaultDailyTaskReport
        {
            get
            {
                return new DailyTaskReport
                {
                    Date = DateTime.Today,
                    EisenHowerType = EisenHowerType.ImportantAndUrgent,
                    CompletedCount = 10,
                    FailedCount = 3,
                    TotalCount = 13,
                    UserId = 1
                };
            }
        }

        public WeeklyTaskReport DefaultWeeklyTaskReport
        {
            get
            {
                return new WeeklyTaskReport
                {
                    WeekIndex = (DateTime.Today - new DateTime(1900,1,1)).Days/7,
                    EisenHowerType = EisenHowerType.ImportantAndUrgent,
                    CompletedCount = 10,
                    FailedCount = 3,
                    TotalCount = 13,
                    UserId = 1
                };
            }
        }
    }
}