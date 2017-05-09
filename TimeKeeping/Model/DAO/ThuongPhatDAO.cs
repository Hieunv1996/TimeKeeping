using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class ThuongPhatDAO
    {
        private TimeKeepingDbContext obj = null;
        public ThuongPhatDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(ThuongPhat thuongPhat)
        {
            try
            {
                thuongPhat.DauThoiGian = DateTime.Now;
                obj.ThuongPhats.Add(thuongPhat);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ThuongPhat thuongPhat)
        {
            try
            {
                ThuongPhat newThuongPhat = obj.ThuongPhats.Find(thuongPhat.ID);
                newThuongPhat.IDNhanVien = thuongPhat.IDNhanVien;
                newThuongPhat.MoTa = thuongPhat.MoTa;
                newThuongPhat.SoTien = thuongPhat.SoTien;
                newThuongPhat.DauThoiGian = thuongPhat.DauThoiGian;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<ThuongPhat> GetListThuongPhat(string keyword, int page, int pageSize)
        {
            IEnumerable<ThuongPhat> objThuongPhats = obj.ThuongPhats;
            if (!string.IsNullOrEmpty(keyword))
            {
                objThuongPhats = objThuongPhats.Where(x => x.MoTa.ToLower().Contains(keyword.ToLower()));
            }
            return objThuongPhats.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public ThuongPhat GetByThuongPhatID(long id)
        {
            return obj.ThuongPhats.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var thuongPhat = GetByThuongPhatID(id);
                obj.ThuongPhats.Remove(thuongPhat);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
