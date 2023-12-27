using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Room
{
    public record RoomForCreateDto(
        int CategoryId,
        int Number,
        int Floor);
   
}
