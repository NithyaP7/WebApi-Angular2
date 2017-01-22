using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyHistories.Core.Models.Histories
{
    public class History
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }

    }
}
