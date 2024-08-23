using App_Data.Data;
using App_Data.Entities;
using App_Data.InterfaceRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ImplementRepos
{
    public class Staff_MajorRepos : IStaff_MajorRepos
    {
        AppDbContext _context;
        public Staff_MajorRepos(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Staff_MajorFacility>> GetAll(Guid idstaff)
        {
            var lst = await _context.Staff_Major
                .Include(x => x.major_Facility.department_Facility.Facility)
                .Include(x => x.major_Facility.department_Facility.Department)
                .Include(x => x.major_Facility.Major)
                .Where(x => x.StaffId == idstaff)
                .ToListAsync();

            return lst;
        }

        public Task<List<Department>> GetAllDepartment(Guid idfacility)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Facility>> GetAllFacility()
        {
            var lst = await _context.Facility.ToListAsync();

            return lst;
        }
    }
}
