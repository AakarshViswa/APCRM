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

    }

    public class WorkStatusRepo : Repo<WorkStatus>, IWorkStatusRepo
    {
        public WorkStatusRepo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
