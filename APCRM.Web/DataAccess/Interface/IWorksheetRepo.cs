using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IWorksheetRepo: IRepo<Worksheet>
    {
        public Task<IEnumerable<Worksheet>> GetAllWorkSheets();

        public Task<Worksheet> GetWorksheet(int Id);
    }
}
