﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DTO.DataTransferObject
{
    public class StaffUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AccountFE { get; set; }
        public string AccountFPT { get; set; }
        public int Status { get; set; }
    }
}
