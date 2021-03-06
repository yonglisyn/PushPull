﻿using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PushPull.Constants;
using PushPull.DataAccessLayer.Repositories;
using PushPull.DataAccessLayer.Repositories.Interfaces;
using PushPull.Enums;
using PushPull.Helpers;
using PushPull.Managers;
using PushPull.Models;
using PushPull.ViewModels;

namespace PushPull.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public TaskController()
        {
            TaskRepository = new TaskRepository();
        }

        public TaskController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            TaskRepository = new TaskRepository();
        }

        public ITaskRepository TaskRepository { get; set; }

        private ApplicationUserManager _UserManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _UserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _UserManager = value;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var taskToBeDone = await TaskRepository.GetAllTaskCardsAsync(userId);
            return View("TaskList", new TaskListViewModel(taskToBeDone));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TaskCardViewModel form)
        {
            string partialHtml;
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.Identity.GetUserId<int>();
                    var taskCard = new TaskCard(form)
                    {
                        UserId = userId,
                        ModifiedBy = User.Identity.Name,
                        ModifiedOn = DateTime.Now
                    };
                    await TaskRepository.EditTaskCardAsync(taskCard);
                    partialHtml = RenderViewHelper.RenderRazorViewToString(ControllerContext, "_TaskCard", taskCard);
                    return Json(new
                    {
                        Status = ResponseStatus.Success,
                        Data = partialHtml,
                        TaskId = taskCard.TaskId,
                        TargetId = GetDisplayTargetId(taskCard.EisenHowerType)

                    });
                }
                catch (Exception ex)
                {
                    //todo use elma to log ex
                    ModelState.AddModelError("Exception", "Hi Boss, System is sick. Need MC!");
                }
            }
            partialHtml = RenderViewHelper.RenderRazorViewToString(ControllerContext,"_TaskCardEditForm", form);
            return Json(new
            {
                Status = ResponseStatus.Fail,
                Data = partialHtml
            });
        }

        [HttpPost]
        public async Task<JsonResult> Add(TaskCardViewModel form)
        {
            string partialHtml;
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.Identity.GetUserId<int>();
                    var taskCard = new TaskCard(form)
                    {
                        UserId = userId,
                        ModifiedBy = User.Identity.Name,
                        ModifiedOn = DateTime.Now
                    };
                    await TaskRepository.AddTaskCardAsync(taskCard);
                    partialHtml = RenderViewHelper.RenderRazorViewToString(ControllerContext, "_TaskCard", taskCard);
                    return Json(new
                    {
                        Status = ResponseStatus.Success,
                        Data = partialHtml,
                        TaskId = taskCard.TaskId,
                        TargetId = GetDisplayTargetId(taskCard.EisenHowerType)
                    });
                }
                catch (Exception ex)
                {
                    //todo use elma to log ex
                    ModelState.AddModelError("Exception", "Hi Boss, System is sick. Need MC!");
                }
            }
            partialHtml = RenderViewHelper.RenderRazorViewToString(ControllerContext, "_TaskCardAddForm", form);
            return Json(new
            {
                Status = ResponseStatus.Success,
                Data = partialHtml
            });
        }

        private string GetDisplayTargetId(EisenHowerType eisenHowerType)
        {
            switch (eisenHowerType)
            {
                case EisenHowerType.ImportantAndUrgent:
                    return StringConst.IuTaskList;
                case EisenHowerType.ImportantAndNotUrgent:
                    return StringConst.InuTaskList;
                case EisenHowerType.NotImportantAndUrgent:
                    return StringConst.NiuTaskList;
                case EisenHowerType.NotImportantAndNotUrgent:
                    return StringConst.NinuTaskList;
                default:
                    return string.Empty;
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(long taskId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await TaskRepository.RemoveTaskCardAsync(taskId);
                    return Json(new
                    {
                        Status = ResponseStatus.Success
                    });
                }
                catch (Exception ex)
                {
                    //todo use elma to log ex
                    ModelState.AddModelError("Exception", "Hi Boss, System is sick. Need MC!");
                }
            }
            return Json(new
            {
                Status = ResponseStatus.Fail
            });
        }
    }
}