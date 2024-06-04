using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.Contracts;

public class ReviewOutputModel
{
    public long Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
}
