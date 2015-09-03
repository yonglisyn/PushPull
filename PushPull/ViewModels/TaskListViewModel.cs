using System.Collections.Generic;
using System.Linq;
using PushPull.Enums;
using PushPull.Models;

namespace PushPull.ViewModels
{
    public class TaskListViewModel
    {
        public List<TaskCard> IuTaskCards { get; set; }
        public List<TaskCard> InuTaskCards { get; set; }
        public List<TaskCard> NiuTaskCards { get; set; }
        public List<TaskCard> NinuTaskCards { get; set; }
        public TaskListViewModel(List<TaskCard> taskCards)
        {
            IuTaskCards = taskCards.Where(x=>x.EisenHowerType == EisenHowerType.ImportantAndUrgent).ToList();
            InuTaskCards = taskCards.Where(x => x.EisenHowerType == EisenHowerType.ImportantAndNotUrgent).ToList();
            NiuTaskCards = taskCards.Where(x => x.EisenHowerType == EisenHowerType.NotImportantAndUrgent).ToList();
            NinuTaskCards = taskCards.Where(x => x.EisenHowerType == EisenHowerType.NotImportantAndNotUrgent).ToList();
        }
    }
}