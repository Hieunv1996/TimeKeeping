using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class NhanVienDAO
    {
        private TimeKeepingDbContext obj = null;
        public NhanVienDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(NhanVien nhanVien)
        {
            try
            {
                obj.NhanViens.Add(nhanVien);
                return obj.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<ViewNhanVien> GetListNhanVien()
        {
            return obj.ViewNhanViens.OrderBy(x => x.ID).ToList();
        }

        public bool Update(NhanVien nhanVien)
        {
            try
            {
                NhanVien newNhanVien = obj.NhanViens.Find(nhanVien.ID);
                newNhanVien.Ho = nhanVien.Ho;
                newNhanVien.Ten = nhanVien.Ten;
                newNhanVien.GioiTinh = nhanVien.GioiTinh;
                newNhanVien.NgayVaoLam = nhanVien.NgayVaoLam;
                newNhanVien.NgaySinh = nhanVien.NgaySinh;
                newNhanVien.CMND = nhanVien.CMND;
                newNhanVien.Email = nhanVien.Email;
                newNhanVien.DienThoai = nhanVien.DienThoai;
                newNhanVien.AnhDaiDien = nhanVien.AnhDaiDien;
                newNhanVien.IDChucVu = nhanVien.IDChucVu;
                newNhanVien.IDPhongBan = nhanVien.IDPhongBan;
                newNhanVien.IDHeSoLuong = nhanVien.IDHeSoLuong;
                return obj.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        public IEnumerable<ViewNhanVien> GetListNhanVien(string keyword, int page, int pageSize)
        {
            IEnumerable<ViewNhanVien> objNhanViens = obj.ViewNhanViens;
            if (!string.IsNullOrEmpty(keyword))
            {
                objNhanViens = objNhanViens.Where(x => (x.Ho + " " + x.Ten).ToLower().Contains(keyword.ToLower()));
            }
            return objNhanViens.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public NhanVien GetByNhanVienID(long id)
        {
            return obj.NhanViens.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var nhanVien = GetByNhanVienID(id);
                obj.NhanViens.Remove(nhanVien);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
