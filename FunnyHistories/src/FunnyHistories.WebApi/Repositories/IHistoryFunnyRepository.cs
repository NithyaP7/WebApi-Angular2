using FunnyHistories.Core.Models.Histories;
using FunnyHistories.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyHistories.WebApi.Repositories
{
    public interface IHistoryRepository
    {
        void Add(History history);
        IEnumerable<History> GetAll();
        History Find(int key);
        OperationStatus Remove(int key);
        OperationStatus Update(History item);
    }
}
