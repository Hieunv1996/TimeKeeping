using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class ChucVuDAO
    {
        private TimeKeepingDbContext obj = null;
        public ChucVuDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public List<ChucVu> GetListChucVu()
        {
            return obj.ChucVus.OrderBy(x => x.ID).ToList();
        }

        public bool Insert(ChucVu chamCong)
        {
            try
            {
                obj.ChucVus.Add(chamCong);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ChucVu chucVu)
        {
            try
            {
                ChucVu newChucVu = obj.ChucVus.Find(chucVu.ID);
                newChucVu.TenChucVu = chucVu.TenChucVu;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<ChucVu> GetListChucVu(string keyword, int page, int pageSize)
        {
            IEnumerable<ChucVu> objChucVus = obj.ChucVus;
            if (!string.IsNullOrEmpty(keyword))
            {
                objChucVus = objChucVus.Where(x => x.TenChucVu.ToLower().Contains(keyword.ToLower()));
            }
            return objChucVus.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public ChucVu GetByChucVuID(long id)
        {
            return obj.ChucVus.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var caLam = GetByChucVuID(id);
                obj.ChucVus.Remove(caLam);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
