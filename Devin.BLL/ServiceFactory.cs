
using Devin.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Devin.BLL
{
    public static class ServiceFactory
    {
	        public static Idt_managerService dt_managerService
        {
            get
            {
                return new dt_managerService();
            }
        }
		        public static Idt_manager_logService dt_manager_logService
        {
            get
            {
                return new dt_manager_logService();
            }
        }
		        public static Idt_manager_roleService dt_manager_roleService
        {
            get
            {
                return new dt_manager_roleService();
            }
        }
		        public static Idt_manager_role_valueService dt_manager_role_valueService
        {
            get
            {
                return new dt_manager_role_valueService();
            }
        }
		        public static Idt_navigationService dt_navigationService
        {
            get
            {
                return new dt_navigationService();
            }
        }
		        public static Idt_sms_templateService dt_sms_templateService
        {
            get
            {
                return new dt_sms_templateService();
            }
        }
		    }
}