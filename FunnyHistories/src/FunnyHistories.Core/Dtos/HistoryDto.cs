using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoGiftApi.Core.Dtos
{
    public class HistoryDto
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}
