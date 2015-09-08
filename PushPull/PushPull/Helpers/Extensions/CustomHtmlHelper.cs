using System;
using System.Web.Mvc;
using PushPull.Models;

namespace PushPull.Helpers.Extensions
{
    public static class CustomHtmlHelper
    {
        public static string GetTaskCardData(this HtmlHelper helper, TaskCard taskCard)
        {
            return string.Format(@"data-id='{0}' data-assettype={1} data-valueunit={2} 
                                 data-assetvalue={3} data-failvalue={4} data-tag={5} 
                                 data-content='{6}' data-tasktype={7} data-deadline={8}", 
                                 taskCard.TaskId, taskCard.Card.AssetType, taskCard.Card.ValueUnit,
                                taskCard.Card.AssetValue,taskCard.Card.FailValue, taskCard.Card.Tag,
                                taskCard.Card.Content, (int)taskCard.EisenHowerType, 
                                taskCard.DeadlineDisplay);
        }
    }
}