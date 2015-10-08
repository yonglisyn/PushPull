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
    }
}