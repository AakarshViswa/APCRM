using APCRM.Web.Data;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IWorkPhaseRepo : IRepo<WorkPhase>
    {
        void Update(WorkPhase workphase);
    }

    public class WorkPhaseRepo : Repo<WorkPhase>, IWorkPhaseRepo
    {

        private readonly ApplicationDbContext _db;
        public WorkPhaseRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WorkPhase workphase)
        {
            _db.Update(workphase);
        }
    }

    public interface IWorkStatusRepo : IRepo<WorkStatus>
    {
        void Update(WorkStatus workStatus);
    }

    public class WorkStatusRepo : Repo<WorkStatus>, IWorkStatusRepo
    {
        private readonly ApplicationDbContext _db;
        public WorkStatusRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WorkStatus workStatus)
        {
            _db.Update(workStatus);
        }
    }
}
