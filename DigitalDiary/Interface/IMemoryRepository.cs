using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Interface
{
    interface IMemoryRepository : IRepository<Memory>
    {
        IEnumerable<Memory> GetUserMemoriesList(int userid);
    }
}
