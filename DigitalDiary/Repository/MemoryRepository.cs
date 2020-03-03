using DigitalDiary.Interface;
using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class MemoryRepository : Repository<Memory>, IMemoryRepository
    {

        IEnumerable<Memory> IMemoryRepository.GetUserMemoriesList(int userid)
        {
            using (DigitalDiaryDataContext db = new DigitalDiaryDataContext())
            {
                return db.Memories.Where(x => x.userid == userid).ToList<Memory>();
            }
        }
    }
}