using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class QuyenDAO
    {
        private TimeKeepingDbContext obj = null;
        public QuyenDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public List<Quyen> GetListQuyen()
        {
            return obj.Quyens.OrderBy(x => x.ID).ToList();
        }

        public bool Insert(Quyen quyen)
        {
            try
            {
                obj.Quyens.Add(quyen);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Quyen quyen)
        {
            try
            {
                Quyen newQuyen = obj.Quyens.Find(quyen.ID);
                newQuyen.TenQuyen = quyen.TenQuyen;
                newQuyen.MoTa = quyen.MoTa;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<Quyen> GetListQuyen(string keyword, int page, int pageSize)
        {
            IEnumerable<Quyen> objQuyens = obj.Quyens;
            if (!string.IsNullOrEmpty(keyword))
            {
                objQuyens = objQuyens.Where(x => x.TenQuyen.ToLower().Contains(keyword.ToLower()));
            }
            return objQuyens.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public Quyen GetByQuyenID(long id)
        {
            return obj.Quyens.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var quyen = GetByQuyenID(id);
                obj.Quyens.Remove(quyen);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
