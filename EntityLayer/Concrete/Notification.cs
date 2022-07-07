using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification : BaseClass
    {
        public string NotificationType { get; set; }
        public string NotificationContent { get; set; }
        public DateTime NotificationDate { get; set; }

    }
}
