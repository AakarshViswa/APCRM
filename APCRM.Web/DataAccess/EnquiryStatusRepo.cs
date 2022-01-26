﻿using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.DataAccess
{
    public class EnquiryStatusRepo : Repo<EnquiryStatus>, IEnquiryStatusRepo
    {
        private readonly ApplicationDbContext _db;
        public EnquiryStatusRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EnquiryStatus>> GetAllEnquiryAsync()
        {
            return await _db.EnquiryStatus.Include(x => x.UpdatedBy).Include(x => x.CreatedBy).ToListAsync();
        }

        public void Update(EnquiryStatus user)
        {
            _db.Update(user);
        }       
    }
}
