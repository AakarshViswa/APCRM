using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class EventTypeRepo : Repo<EventType>, IEventTypeRepo
    {
        private readonly ApplicationDbContext _db;
        public EventTypeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EventType eventType)
        {
            if (eventType != null)
            {
                eventType.CreatedOn = DateTime.Now; 
                _db.EventTypes.Update(eventType);
            }
        }
    }
}
