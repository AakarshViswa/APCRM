using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IPackageRepo : IRepo<Package>
    {
        void Update(Package package);
        Task<IEnumerable<Package>> GetAllPackageAsync();
    }

    public interface IProductRepo : IRepo<Product>
    {
        void Update(Product product);
        Task<IEnumerable<Product>> GetAllProductAsync();
    }
    public interface IDeliverableRepo: IRepo<Deliverable>
    {
        void Update(Deliverable delivery);
        Task<IEnumerable<Deliverable>> GetAllDeliverableAsync();
    }
    public interface IProductDocketRepo: IRepo<ProductDocket>
    {
        void Update(ProductDocket productDocket);
    }

    public interface IDeliverableDocketRepo : IRepo<DeliverableDocket>
    {
        void Update(DeliverableDocket delivery);
    }
}
