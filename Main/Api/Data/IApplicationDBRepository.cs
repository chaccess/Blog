using Main.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api.Data
{
    public interface IApplicationDBRepository
    {
        Task<Record?> GetRecord(long id);

        Task<bool> PostRecord(Record record);
    }
}
