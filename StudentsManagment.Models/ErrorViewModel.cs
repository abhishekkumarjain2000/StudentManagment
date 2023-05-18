using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagment.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
