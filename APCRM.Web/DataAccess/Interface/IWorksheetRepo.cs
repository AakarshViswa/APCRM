using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IWorksheetRepo: IRepo<Worksheet>
    {
        public Task<IEnumerable<Worksheet>> GetAllWorkSheets();

        public Task<Worksheet> GetWorksheet(int Id);
    }

    public interface IWorksheetPaymentLogRepo : IRepo<WorksheetPaymentLog>
    {
        Task<IEnumerable<WorksheetPaymentLog>> GetAllWorksheetPaymentLog();
        Task<IEnumerable<WorksheetPaymentLog>> GetWorksheetPaymentLog(int Id);
    }

    public interface IWorksheetProductRepo : IRepo<WorksheetProduct>
    {
        Task<IEnumerable<WorksheetProduct>> GetAllWorkSheetProduct();
        Task<IEnumerable<WorksheetProduct>> GetWorksheetProduct(int Id);
    }

    public interface IWorksheetPaymentStatusRepo : IRepo<WorksheetPaymentStatus>
    {
        Task<WorksheetPaymentStatus> GetWorksheetPaymentStatus(int Id);
    }

    public interface IWorksheetDeliverableRepo : IRepo<WorksheetDeliverable>
    {
        Task<IEnumerable<WorksheetDeliverable>> GetAllWorkSheetDeliverable();
        Task<IEnumerable<WorksheetDeliverable>> GetWorksheetDeliverable(int Id);
    }
}
