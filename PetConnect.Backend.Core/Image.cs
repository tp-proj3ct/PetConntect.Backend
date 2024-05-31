using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.Core;

public class Image
{
    public long Id { get; set; }

    public long PetId { get; set; }

    public byte[]? Data { get; set; } 
}
