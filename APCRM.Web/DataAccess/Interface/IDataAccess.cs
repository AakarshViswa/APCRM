﻿using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IDataAccess
    {
        ISettingRepo settings { get; }
        IAppUserRepo appUser { get; }
        IEventTypeRepo eventType { get; }
        IEnquiryStatusRepo enquiryStatus { get; }

        IProductRepo product { get; }
        IPackageRepo package { get; }
        IDeliverableRepo deliverable { get; }
        IProductDocketRepo productDocket { get; }
        IDeliverableDocketRepo  DeliverableDocket { get; }
        ICustomerRepo customer { get; } 
        IEventRepo Event { get; }
        IWorkPhaseRepo workPhase { get; }
        IWorkStatusRepo workStatus { get; }
        void Save();
    }

    public interface IEventRepo : IRepo<Event>
    {

    }
}
