using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IEventTypeRepo : IRepo<EventType>
    {
        void Update(EventType eventType);
    }
}
