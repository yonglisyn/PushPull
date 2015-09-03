using System.Web.Mvc;
using PushPull.Enums;

namespace PushPull.ViewModels
{
    public class PushPullJsonResponse : JsonResult
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}