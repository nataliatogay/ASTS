using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASTS.DTOs;

namespace ASTS.Services.Interfaces
{
    public interface IParametersService
    {
        Task<MaterialRequestParametersResponse> GetParameters();
    }
}
