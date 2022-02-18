namespace APCRM.Web.Models.ViewModel
{
    public class PackageViewModel
    {
        public IEnumerable<Package> Packages { get; set;}
        public Package package { get; set;}

        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Deliverable> deliverables { get; set; }
        public bool isUpdate { get; set; }

        public int PLastIndex { get; set; }
        public int DLastIndex { get; set; }
    }
}
