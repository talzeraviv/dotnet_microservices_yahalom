using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Play.Catalog.Service.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreateDate);
    public record CreateItemDto([Required] string Name, string Description, [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0 and lower than max value for the double data type.")] decimal Price);
    public record UpdateItemDto([Required] string Name, string Description, [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0 and lower than max value for the double data type.")] decimal Price);
}