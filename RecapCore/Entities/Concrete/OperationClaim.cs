using System;
using System.Collections.Generic;
using System.Text;

namespace RecapCore.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
