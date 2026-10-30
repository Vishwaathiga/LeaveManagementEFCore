using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagementEFCore.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public int? EntityId { get; set; }

        public string Details { get; set; } = string.Empty;

        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}
