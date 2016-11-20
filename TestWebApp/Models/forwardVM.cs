using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class ForwardVm
    {
        [DisplayName("Сотрудник от:")]
        public Employee EmployeeFrom { get; set; }
        [DisplayName("Сотрудник куда:")]
        public Employee EmployeeTo { get; set; }
        [DisplayName("Дата начала")]
        public DateTime DateBegin { get; set; }
        [DisplayName("Дата окончания")]
        public DateTime DateEnd { get; set; }
        [DisplayName("Оставлять копии")]
        public bool LeavCopyMessage { get; set; }
    }
}