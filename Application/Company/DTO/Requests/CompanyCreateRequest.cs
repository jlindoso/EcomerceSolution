using Application.Company.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Company.DTO.Requests
{
    public class CompanyCreateRequest
    {
        public string Name { get; set; } = string.Empty;

    }
}
