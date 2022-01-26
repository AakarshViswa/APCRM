using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class PackageRepo : Repo<Package>, IPackageRepo
    {
        private readonly ApplicationDbContext _db;
        public PackageRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Package package)
        {
            _db.Update(package);
        }
    }

    public class ProductRepo : Repo<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _db;
        public ProductRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            _db.Update(product);
        }
    }

    public class DeliverableRepo : Repo<Deliverable>, IDeliverableRepo
    {
        private readonly ApplicationDbContext _db;
        public DeliverableRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Deliverable delivery)
        {
            _db.Update(delivery);
        }
    }

    public class ProductDocketRepo : Repo<ProductDocket>, IProductDocketRepo
    {
        private readonly ApplicationDbContext _db;
        public ProductDocketRepo(ApplicationDbContext db) : base(db)
        {
            _db= db;    
        }

        public void Update(ProductDocket productDocket)
        {
            _db.Update(productDocket);
        }
    }
    public class DeliverableDocketRepo : Repo<DeliverableDocket>, IDeliverableDocketRepo
    {
        private readonly ApplicationDbContext _db;
        public DeliverableDocketRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DeliverableDocket delivery)
        {
            _db.Update(delivery);
        }
    }
}

