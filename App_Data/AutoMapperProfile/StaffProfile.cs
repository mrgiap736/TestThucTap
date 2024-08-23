using App_Data.Entities;
using App_DTO.DataTransferObject;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.AutoMapperProfile
{
	public class StaffProfile : Profile
	{
        public StaffProfile()
        {
            CreateMap<StaffDTO, Staff>().ReverseMap();
            CreateMap<StaffUpdateRequest, Staff>();
        }
    }
}
