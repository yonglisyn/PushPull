//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using PushPull.Constants;
//using PushPull.Enums;
//using PushPull.Models;

//namespace PushPull.DataAccessLayer
//{
//    public class AccountDbInitializer : DropCreateDatabaseIfModelChanges<AccountDbContext>
//    {
//        private readonly Card _MoneyCard = new Card()
//        {
//            AssetType = AssetType.Money,
//            PullValue = 500,
//            PushValue = 300,
//            Status = CardStatus.Started,
//            ValueUnit = "$"
//        };

//        private Card _TimeCard = new Card()
//        {
//            AssetType = AssetType.Time,
//            PullValue = 1,
//            PushValue = 1,
//            Status = CardStatus.Started,
//            ValueUnit = "h"
//        };

//        protected override void Seed(AccountDbContext context)
//        {
//            var customers = new List<Customer>
//            {
//                new Customer()
//                {
//                    AccountId = "Yongli",
//                    CustomerId = 1,
//                    Email = "sylyongli@gmail.com",
//                    Password = "123456a",
//                    PasswordExpiryTime = DateTime.Now.AddMonths(AccountConstSettings.PasswordExpiredMonth),

//                },

//            var customerLives = new List<CustomerLife>
//            {
//                new CustomerLife()
//                {
//                    Email = "sylyongli@gmail.com",
//                    AccountId = "Yongli",
//                    CustomerId = 1,
//                    IsAlive = true
//                },
//                new CustomerLife()
//                {
//                    Email = "peterinsg@hotmail.com",
//                    AccountId = "BigMan",
//                    CustomerId = 2,
//                    IsAlive = true
//                },
//            };

//            var recurredSchedules = new List<RecurredSchedule>
//            {
//                new RecurredSchedule()
//                {
//                    RecurredScheduleId = 1,
//                    CustomerId = 1,
//                    RecurrenceType = RecurrenceType.DayOfWeek,
//                    FirstOccurrenceDate = DateTime.Today,
//                    ReccurrenceCount = 1,
//                    IsFinished = false,
//                    ModifiedOn = DateTime.Now,
//                    ModifiedBy = "yongli"
//                }
//            };

//            var scheduleCards = new List<ScheduleCard>
//            {
//                new ScheduleCard()
//                {
//                    ScheduleId = 1,
//                    RecurredScheduleId = 1,
//                    CustomerId = 1,
//                    Card = _TimeCard,
//                    Date = DateTime.Today,
//                    StartTime = new TimeSpan(2, 14, 0),
//                    EndTime = new TimeSpan(3, 54, 0),
//                    Content = "Happy coding",
//                    ModifiedBy = "yongli",
//                    ModifiedOn = DateTime.Now
//                },
//                new ScheduleCard()
//                {
//                    ScheduleId = 2,
//                    CustomerId = 1,
//                    Card = _TimeCard,
//                    Date = DateTime.Today,
//                    StartTime = new TimeSpan(2, 14, 0),
//                    EndTime = new TimeSpan(3, 54, 0),
//                    Content = "Happy coding 2",
//                    ModifiedBy = "yongli",
//                    ModifiedOn = DateTime.Now
//                }
//            };

//            var taksCards = new List<TaskCard>
//            {
//                new TaskCard()
//                {
//                    TaskId = 1,
//                    CustomerId = 1,
//                    Content = "Code for PushPull",
//                    DeadLine = new DateTime(2015, 11, 01),
//                    EisenHowerType = EisenHowerType.ImportantAndNotUrgent,
//                    Card = _MoneyCard,
//                    ModifiedOn = DateTime.Now,
//                    ModifiedBy = "yongli"
//                }
//            };

//            var tags = new List<Tag>
//            {
//                new Tag()
//                {
//                    TagId = 1,
//                    CustomerId = 1,
//                    Content = "Test Tag"
//                }
//            };
//            tags.ForEach(s => context.Tags.Add(s));
//            context.SaveChanges();

//        }
//    }
//}