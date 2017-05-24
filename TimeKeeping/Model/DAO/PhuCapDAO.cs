using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class PhuCapDAO
    {
        private TimeKeepingDbContext obj = null;
        public PhuCapDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(PhuCap phuCap)
        {
            try
            {
                obj.PhuCaps.Add(phuCap);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PhuCap phuCap)
        {
            try
            {
                PhuCap newPhuCap = obj.PhuCaps.Find(phuCap.ID);
                newPhuCap.IDChucVu = phuCap.IDChucVu;
                newPhuCap.MoTaPhuCap = phuCap.MoTaPhuCap;
                newPhuCap.SoTien = phuCap.SoTien;
                newPhuCap.TinhTrang = phuCap.TinhTrang;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<ViewPhuCap> GetListPhuCap(string keyword, int page, int pageSize)
        {
            IEnumerable<ViewPhuCap> objViewPhuCaps = obj.ViewPhuCaps;
            if (!string.IsNullOrEmpty(keyword))
            {
                objViewPhuCaps = objViewPhuCaps.Where(x => x.TenChucVu.ToLower().Contains(keyword.ToLower()));
            }
            return objViewPhuCaps.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public PhuCap GetByPhuCapID(long id)
        {
            return obj.PhuCaps.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var phuCap = GetByPhuCapID(id);
                obj.PhuCaps.Remove(phuCap);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
