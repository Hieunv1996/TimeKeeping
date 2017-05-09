using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class TinhTrangDAO
    {
        private TimeKeepingDbContext obj = null;
        public TinhTrangDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(TinhTrang tinhTrang)
        {
            try
            {
                obj.TinhTrangs.Add(tinhTrang);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TinhTrang tinhTrang)
        {
            try
            {
                TinhTrang newTinhTrang = obj.TinhTrangs.Find(tinhTrang.ID);
                newTinhTrang.KiHieu = tinhTrang.KiHieu;
                newTinhTrang.MoTa = tinhTrang.MoTa;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<TinhTrang> GetListTinhTrang(string keyword, int page, int pageSize)
        {
            IEnumerable<TinhTrang> objTinhTrangs = obj.TinhTrangs;
            if (!string.IsNullOrEmpty(keyword))
            {
                objTinhTrangs = objTinhTrangs.Where(x => (x.MoTa).ToLower().Contains(keyword.ToLower()) || x.KiHieu.ToLower().Contains(keyword.ToLower()));
            }
            return objTinhTrangs.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public TinhTrang GetByTinhTrangID(int id)
        {
            return obj.TinhTrangs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var tinhTrang = GetByTinhTrangID(id);
                obj.TinhTrangs.Remove(tinhTrang);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
