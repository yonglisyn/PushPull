using System;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.Helpers.Extensions
{
    public static class SeedDataExtension
    {
        public static TaskCard WithContent(this TaskCard taskCard, string content)
        {
            taskCard.Card.Content = content;
            return taskCard;
        }
        public static TaskCard WithType(this TaskCard taskCard, EisenHowerType type)
        {
            taskCard.EisenHowerType = type;
            return taskCard;
        }
        public static TaskCard WithStatus(this TaskCard taskCard, CardStatus status)
        {
            taskCard.Card.Status = status;
            return taskCard;
        }
        public static Asset WithPurpose(this Asset asset, AssetPurpose purpose)
        {
            asset.AssetPurpose = purpose;
            return asset;
        }
        public static Asset WithDate(this Asset asset, DateTime date)
        {
            asset.Date = date;
            return asset;
        }
        public static Asset WithDayOfWeek(this Asset asset, int dayOfWeek)
        {
            asset.DayOfWeek = dayOfWeek;
            return asset;
        }
        public static Asset WithValue(this Asset asset, decimal? value, Random random)
        {
            if (value == null)
            {
                value = random.Next(1,1000);
            }
            asset.AssetValue = (decimal)value;
            return asset;
        }


        public static DailyTaskReport WithValues(this DailyTaskReport dailyTaskReport,int completed, int failed)
        {
            dailyTaskReport.CompletedCount = completed;
            dailyTaskReport.FailedCount = failed;
            dailyTaskReport.TotalCount = completed + failed;
            return dailyTaskReport;
        }

        public static DailyTaskReport WithType(this DailyTaskReport dailyTaskReport, EisenHowerType eisenHowerType)
        {
            dailyTaskReport.EisenHowerType = eisenHowerType;
            return dailyTaskReport;
        }
        public static DailyTaskReport WithDate(this DailyTaskReport dailyTaskReport, DateTime date)
        {
            dailyTaskReport.Date = date;
            return dailyTaskReport;
        }
        public static WeeklyTaskReport WithValues(this WeeklyTaskReport weeklyTaskReport,int completed, int failed)
        {
            weeklyTaskReport.CompletedCount = completed;
            weeklyTaskReport.FailedCount = failed;
            weeklyTaskReport.TotalCount = completed + failed;
            return weeklyTaskReport;
        }

        public static WeeklyTaskReport WithType(this WeeklyTaskReport weeklyTaskReport, EisenHowerType eisenHowerType)
        {
            weeklyTaskReport.EisenHowerType = eisenHowerType;
            return weeklyTaskReport;
        }
        public static WeeklyTaskReport WithWeekIndex(this WeeklyTaskReport weeklyTaskReport, int weekIndex)
        {
            weeklyTaskReport.WeekIndex = weekIndex;
            return weeklyTaskReport;
        }

    }
}