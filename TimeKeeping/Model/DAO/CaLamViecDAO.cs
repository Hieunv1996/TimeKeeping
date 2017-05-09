using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class CaLamViecDAO
    {
        private TimeKeepingDbContext obj = null;
        public CaLamViecDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(CaLamViec acc)
        {
            try
            {
                obj.CaLamViecs.Add(acc);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CaLamViec caLam)
        {
            try
            {
                CaLamViec newCaLamViec = obj.CaLamViecs.Find(caLam.ID);
                newCaLamViec.TenCaLamViec = caLam.TenCaLamViec;
                newCaLamViec.TGBatDau = caLam.TGBatDau;
                newCaLamViec.TGKetThuc = caLam.TGKetThuc;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<CaLamViec> GetListCaLamViec(string keyword, int page, int pageSize)
        {
            IEnumerable<CaLamViec> objCaLamViecs = obj.CaLamViecs;
            if (!string.IsNullOrEmpty(keyword))
            {
                objCaLamViecs = objCaLamViecs.Where(x => x.TenCaLamViec.ToLower().Contains(keyword.ToLower()));
            }
            return objCaLamViecs.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public CaLamViec GetByCaLamViecID(int id)
        {
            return obj.CaLamViecs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var caLam = GetByCaLamViecID(id);
                obj.CaLamViecs.Remove(caLam);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
