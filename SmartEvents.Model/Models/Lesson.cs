using System;
using System.Collections.Generic;

namespace SmartEvents.Model.Models
{
    public partial class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime AuthInfo_Created { get; set; }
        public string AuthInfo_CreatedBy { get; set; }
        public System.DateTime AuthInfo_Modified { get; set; }
        public string AuthInfo_ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
