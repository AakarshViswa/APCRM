using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.DataAccess
{
    public class WorksheetRepo : Repo<Worksheet>, IWorksheetRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Worksheet>> GetAllWorkSheets()
        {
            return await _db.Worksheet
                .Include(e=>e.eventinfo).ThenInclude(x=>x.CustomerDetails)
                .Include(e=>e.eventinfo).ThenInclude(y=>y.EventType)
                .Include(p=>p.packageinfo)
                .Include(w=>w.WorkStatus)
                .ToListAsync();
        }

        public async Task<Worksheet> GetWorksheet(int Id)
        {
            IEnumerable<Worksheet> worksheets = await GetAllWorkSheets();
            return worksheets.FirstOrDefault(x => x.Id == Id);
        }
    }
}
