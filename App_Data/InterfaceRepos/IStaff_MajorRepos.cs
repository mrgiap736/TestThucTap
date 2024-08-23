using App_Data.Entities;
using App_DTO.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.InterfaceRepos
{
    public interface IStaff_MajorRepos
    {
        Task<List<Staff_MajorFacility>> GetAll(Guid idstaff);

        Task<List<Facility>> GetAllFacility();
        Task<List<Department>> GetAllDepartment(Guid idfacility);
    }
}
