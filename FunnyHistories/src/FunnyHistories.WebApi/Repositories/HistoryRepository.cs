using FunnyHistories.Core.Models.Histories;
using FunnyHistories.WebApi.DatabaseConfig;
using FunnyHistories.WebApi.Helpers;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FunnyHistories.WebApi.Repositories
{
    [EnableCors("SiteCorsPolicy")]
    public class HistoryRepository : IHistoryRepository
    {
        private readonly FunnyHistoryContext _context;

        public HistoryRepository(FunnyHistoryContext context)
        {
            _context = context;
        }

        public void Add(History history)
        {
            var historyItem = _context.Histories.Any(o => o.Id == history.Id);
            if (!historyItem)
            {
                var itemDb = _context.Histories.FirstOrDefault(o => o.Id == history.Id);
                _context.Histories.Add(itemDb);         
            }       
        }

        public History Find(int key)
        {
            var history = new History();
            var testItem = _context.Histories.Any(o => o.Id == key);
            if(testItem)
            {
                return _context.Histories.FirstOrDefault(o => o.Id == key);
            }
            return history;
        }

        public IEnumerable<History> GetAll()
        {
            return _context.Histories.ToList();
        }

        public OperationStatus Remove(int key)
        {
            var historyItem = _context.Histories.Any(o => o.Id == key);
            if (historyItem)
            {
                var itemDb = _context.Histories.FirstOrDefault(o => o.Id == key);
                _context.Histories.Remove(itemDb);

                if (_context.SaveChanges() > 0)
                    return OperationStatus.OK;
                else
                    return OperationStatus.Failed;
            }
            return OperationStatus.Failed;
        }

        public OperationStatus Update(History history)
        {
            var historyItem = _context.Histories.Any(o => o.Id == history.Id);
            if (historyItem)
            {
                var itemDb = _context.Histories.FirstOrDefault(o => o.Id == history.Id);
                _context.Histories.Update(itemDb);

                if (_context.SaveChanges() > 0)
                    return OperationStatus.OK;
                else
                    return OperationStatus.Failed;
            }
            return OperationStatus.Failed;
        }
    }
}
