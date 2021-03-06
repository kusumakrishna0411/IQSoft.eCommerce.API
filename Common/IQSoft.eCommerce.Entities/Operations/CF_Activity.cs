﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "CF_Activity", Schema = "dbo")]
    public class CF_Activity
    {
        [Key]
        public int ActivityID { get; set; }
        public int ActivityTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? AssignedToID { get; set; }
        public string RefTable { get; set; }
        public int? RefRecordID { get; set; }

        public DateTime? PlannedDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? PriorityID { get; set; }
        public DateTime? NextScheduleDate { get; set; }

        public string Remark { get; set; }
        public string RecordStatus { get; set; }

        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}
