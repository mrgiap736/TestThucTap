using App_Data.Data;
using App_Data.Entities;
using App_DTO.DataTransferObject;
using App_DTO.InterfaceRepos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.ImplementRepos
{
	public class StaffRepos : IStaffRepos
	{
		AppDbContext _context;
		IMapper _mapper;
        public StaffRepos(AppDbContext context, IMapper mapper)
        {
			_context = context;
			_mapper = mapper;
        }
        public async Task<HttpResponseMessage> Create(Staff input)
		{
			try
			{
                input.Id = Guid.NewGuid();
				_context.Staff.Add(input);
				await _context.SaveChangesAsync();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent("Add staff complete")
                };
            }
			catch (Exception ex)
			{
				return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(ex.Message)
				};
			}

		}

		public async Task<HttpResponseMessage> Delete(Guid id)
        {
			try
			{
				var staff = await _context.Staff.FindAsync(id);
				if (staff == null)
				{
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Staff is not found")
                    };
                }

				_context.Staff.Remove(staff);
				await _context.SaveChangesAsync();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent("Delete staff complete")
                };
            }
			catch (Exception ex)
			{
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

		public async Task<StaffDTO> Get(Guid id)
		{
			Staff staff = await _context.Staff.FindAsync(id);

            return _mapper.Map<StaffDTO>(staff);
		}

		public async Task<List<StaffDTO>> GetAll()
		{
            var lst = await _context.Staff.ToListAsync();

            return lst.Select(x => _mapper.Map<StaffDTO>(x)).ToList();
		}

		public async Task<HttpResponseMessage> Update(Staff input)
		{
            try
            {
                var staff = await _context.Staff.FindAsync(input.Id);
                if (staff == null)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Staff is not found")
                    };
                }

                staff.Name = input.Name;
                staff.Code = input.Code;
                staff.AccountFPT = input.AccountFPT;
                staff.AccountFE = input.AccountFE;
                staff.Status = input.Status;

                _context.Staff.Update(staff);
                await _context.SaveChangesAsync();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent("Update staff complete")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }
	}
}
