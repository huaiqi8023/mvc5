//引进TT模版的命名空间

using Devin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.DataAccess.BaseDataAccess
{
    public static class RepositoryFactory
    {
	  public static Idt_managerRepository dt_managerRepository
    {
		get
		{
		return new dt_managerRepository();
		}
    }
	  public static Idt_manager_logRepository dt_manager_logRepository
    {
		get
		{
		return new dt_manager_logRepository();
		}
    }
	  public static Idt_manager_roleRepository dt_manager_roleRepository
    {
		get
		{
		return new dt_manager_roleRepository();
		}
    }
	  public static Idt_manager_role_valueRepository dt_manager_role_valueRepository
    {
		get
		{
		return new dt_manager_role_valueRepository();
		}
    }
	  public static Idt_navigationRepository dt_navigationRepository
    {
		get
		{
		return new dt_navigationRepository();
		}
    }
	  public static Idt_sms_templateRepository dt_sms_templateRepository
    {
		get
		{
		return new dt_sms_templateRepository();
		}
    }
	    }
}