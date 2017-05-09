using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class PhongBanDAO
    {
        private TimeKeepingDbContext obj = null;
        public PhongBanDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public List<PhongBan> GetListPhongBan()
        {
            return obj.PhongBans.OrderBy(x => x.ID).ToList();
        }

        public bool Insert(PhongBan phongBan)
        {
            try
            {
                obj.PhongBans.Add(phongBan);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PhongBan phongBan)
        {
            try
            {
                PhongBan newPhongBan = obj.PhongBans.Find(phongBan.ID);
                newPhongBan.TenPhongBan = phongBan.TenPhongBan;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<PhongBan> GetListPhongBan(string keyword, int page, int pageSize)
        {
            IEnumerable<PhongBan> objPhongBans = obj.PhongBans;
            if (!string.IsNullOrEmpty(keyword))
            {
                objPhongBans = objPhongBans.Where(x => x.TenPhongBan.ToLower().Contains(keyword.ToLower()));
            }
            return objPhongBans.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public PhongBan GetByPhongBanID(long id)
        {
            return obj.PhongBans.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var nhanVien = GetByPhongBanID(id);
                obj.PhongBans.Remove(nhanVien);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
