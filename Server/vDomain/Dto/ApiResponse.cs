using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vDomain.Dto;

public class ApiResponse
{
    public object? Data { get; set; }
    public bool Success { get; set; }   

    public static ApiResponse GenerateSuccess(object? data)
    {
        var response = new ApiResponse()
        {
            Data = data,
            Success = true
        };

        return response;
    }
}
