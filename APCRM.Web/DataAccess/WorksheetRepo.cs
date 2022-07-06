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
                .Include(e => e.eventinfo).ThenInclude(x => x.CustomerDetails)
                .Include(e => e.eventinfo).ThenInclude(y => y.EventType)
                .Include(p => p.packageinfo)
                .Include(w => w.WorkStatus)
                .ToListAsync();
        }

        public async Task<Worksheet> GetWorksheet(int Id)
        {
            IEnumerable<Worksheet> worksheets = await GetAllWorkSheets();
            return worksheets.FirstOrDefault(x => x.Id == Id);
        }
    }

    public class WorksheetPaymentLogRepo : Repo<WorksheetPaymentLog>, IWorksheetPaymentLogRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetPaymentLogRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<WorksheetPaymentLog>> GetAllWorksheetPaymentLog()
        {
            return await _db.WorksheetPaymentLog
               .ToListAsync();
        }

        public async Task<IEnumerable<WorksheetPaymentLog>> GetWorksheetPaymentLog(int Id)
        {
            IEnumerable<WorksheetPaymentLog> wspyl = await GetAllWorksheetPaymentLog();
            return wspyl.Where(x => x.WorkSheetId == Id);
        }
    }

    public class WorksheetProductRepo : Repo<WorksheetProduct>, IWorksheetProductRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetProductRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<WorksheetProduct>> GetAllWorkSheetProduct()
        {
            return await _db.WorksheetProduct
               .Include(w=>w.worksheet)
               .Include(s=>s.product)
               .ToListAsync();
        }

        public async Task<IEnumerable<WorksheetProduct>> GetWorksheetProduct(int Id)
        {
            IEnumerable<WorksheetProduct> worksheets = await GetAllWorkSheetProduct();
            return worksheets.Where(x => x.WorkSheetId == Id);
        }
    }

    public class WorksheetPaymentStatusRepo : Repo<WorksheetPaymentStatus>, IWorksheetPaymentStatusRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetPaymentStatusRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<WorksheetPaymentStatus> GetWorksheetPaymentStatus(int Id)
        {
            return await _db.WorksheetPaymentStatus.FirstOrDefaultAsync(x => x.WorkSheetId == Id);
        }
    }

    public class WorksheetDeliverableRepo : Repo<WorksheetDeliverable>, IWorksheetDeliverableRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetDeliverableRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<WorksheetDeliverable>> GetAllWorkSheetDeliverable()
        {
            return await _db.WorksheetDeliverable
              .Include(w => w.worksheet)
              .Include(s => s.deliverable)
              .ToListAsync();
        }

        public async Task<IEnumerable<WorksheetDeliverable>> GetWorksheetDeliverable(int Id)
        {
            IEnumerable<WorksheetDeliverable> worksheets = await GetAllWorkSheetDeliverable();
            return worksheets.Where(x => x.WorkSheetId == Id);
        }
    }
}
