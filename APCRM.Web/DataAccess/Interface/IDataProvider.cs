using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IDataProvider
    {
        #region Event
        /// <summary>
        /// Add / Update Event
        /// </summary>
        /// <param name="events"></param>
        void UpsertEvent(Event events);

        /// <summary>
        /// Get all Events
        /// </summary>
        /// <returns></returns>
        IEnumerable<Event> GetAllEvents();
        /// <summary>
        /// Get Specific Event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Event GetEvent(int id);
        #endregion

        #region Customer
        void UpdateCustomer(CustomerDetails customer);
        #endregion


        #region Enquiry
        void ConvertEnquiryintoCustomer(int enquiryid);
        #endregion
    }
}
