using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class LuongDAO
    {
        private TimeKeepingDbContext obj = null;
        public LuongDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public List<Luong> GetListLuong()
        {
            return obj.Luongs.OrderBy(x => x.ID).ToList();
        }

        public bool Insert(Luong luong)
        {
            try
            {
                obj.Luongs.Add(luong);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Luong luong)
        {
            try
            {
                Luong newLuong = obj.Luongs.Find(luong.ID);
                newLuong.LuongCoBan = luong.LuongCoBan;
                newLuong.HeSoLuong = luong.HeSoLuong;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<Luong> GetListLuong(string keyword, int page, int pageSize)
        {
            IEnumerable<Luong> objLuongs = obj.Luongs;
            if (!string.IsNullOrEmpty(keyword))
            {
                objLuongs = objLuongs.Where(x => x.HeSoLuong.ToString().Contains(keyword));
            }
            return objLuongs.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public Luong GetByLuongID(int id)
        {
            return obj.Luongs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var luong = GetByLuongID(id);
                obj.Luongs.Remove(luong);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
