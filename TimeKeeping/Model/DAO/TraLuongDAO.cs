using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class ViewTraLuongDAO
    {
        private TimeKeepingDbContext obj = null;
        public ViewTraLuongDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(TraLuong traLuong)
        {
            try
            {
                traLuong.DauThoiGian = DateTime.Now;
                obj.TraLuongs.Add(traLuong);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TraLuong traLuong)
        {
            try
            {
                TraLuong newViewTraLuong = obj.TraLuongs.Find(traLuong.ID);
                newViewTraLuong.IDNhanVien = traLuong.IDNhanVien;
                newViewTraLuong.LuongCuaThang = traLuong.LuongCuaThang;
                newViewTraLuong.TongSoCong = traLuong.TongSoCong;
                newViewTraLuong.ThuongPhat = traLuong.ThuongPhat;
                newViewTraLuong.PhuCap = traLuong.PhuCap;
                newViewTraLuong.ThanhTien = traLuong.ThanhTien;
                newViewTraLuong.DaTra = traLuong.DaTra;
                newViewTraLuong.ConNo = traLuong.ConNo;
                newViewTraLuong.NguoiTra = traLuong.NguoiTra;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<TraLuong> GetListViewTraLuong(string keyword, int page, int pageSize)
        {
            IEnumerable<TraLuong> objTraLuongs = obj.TraLuongs;
            if (!string.IsNullOrEmpty(keyword))
            {
                objTraLuongs = objTraLuongs.Where(x => (x.IDNhanVien.ToString()).Contains(keyword.ToLower()));
            }
            return objTraLuongs.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public TraLuong GetByViewTraLuongID(long id)
        {
            return obj.TraLuongs.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var traLuong = GetByViewTraLuongID(id);
                obj.TraLuongs.Remove(traLuong);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
