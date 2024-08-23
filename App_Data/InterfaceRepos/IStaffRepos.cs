using App_Data.Entities;
using App_DTO.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DTO.InterfaceRepos
{
	public interface IStaffRepos
	{
		Task<HttpResponseMessage> Create(Staff input);
		Task<HttpResponseMessage> Update(Staff input);
		Task<HttpResponseMessage> Delete(Guid id);
		Task<List<StaffDTO>> GetAll();
		Task<StaffDTO> Get(Guid id);
	}
}
