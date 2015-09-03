using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PushPull.Enums;
using PushPull.Resources;

namespace PushPull.ViewModels
{
    public class TaskCardViewModel
    {
        public string Purpose { get; set; }
        [Required]
        [StringLength(200, ErrorMessageResourceType = typeof (Resource), ErrorMessageResourceName = "ContentMaxLength")]
        public string Content { get; set; }
        public decimal AssetValue { get; set; }
        public decimal FailValue { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        public EisenHowerType EisenHowerType { get; set; }
        [StringLength(50, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CommonStringMaxLength")]
        public string AssetType { get; set; }
        [StringLength(50, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CommonStringMaxLength")]
        public string ValueUnit { get; set; }
        [StringLength(50, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "CommonStringMaxLength")]
        public string Tag { get; set; }
        public long TaskId { get; set; }

        public IEnumerable<SelectListItem> EisenHowerTypeList {
            get { return new List<SelectListItem>
            {
                new SelectListItem {Text = Resource.EisenHowerType_IU, Value = "1", Selected = (int)EisenHowerType==1},
                new SelectListItem {Text = Resource.EisenHowerType_INU, Value = "2", Selected = (int)EisenHowerType==2},
                new SelectListItem {Text = Resource.EisenHowerType_NIU, Value = "3", Selected = (int)EisenHowerType==3},
                new SelectListItem {Text = Resource.EisenHowerType_NINU, Value = "4", Selected = (int)EisenHowerType==4},
            }; }
        }
    }
}