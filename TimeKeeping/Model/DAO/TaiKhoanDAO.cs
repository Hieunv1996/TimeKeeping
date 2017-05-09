using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;
using System.Data.Entity.Validation;

namespace Model.DAO
{
    public class TaiKhoanDAO
    {
        private TimeKeepingDbContext obj = null;
        public TaiKhoanDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(TaiKhoan acc)
        {
            try
            {
                acc.NgayTao = DateTime.Now;
                obj.TaiKhoans.Add(acc);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TaiKhoan account)
        {
            try
            {
                TaiKhoan updateTaiKhoan = obj.TaiKhoans.Find(account.ID);
                updateTaiKhoan.IDNhanVien = account.IDNhanVien;
                updateTaiKhoan.TenDangNhap = account.TenDangNhap;
                updateTaiKhoan.IDQuyen = account.IDQuyen;
                if (!string.IsNullOrEmpty(account.MatKhau))
                {
                    updateTaiKhoan.MatKhau = account.MatKhau;
                }
                updateTaiKhoan.TinhTrang = account.TinhTrang;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public List<ViewTaiKhoan> GetListTaiKhoan()
        {
            return obj.ViewTaiKhoans.ToList();
        }

        public IEnumerable<ViewTaiKhoan> GetListTaiKhoan(string query,int page, int pageSize)
        {
            IEnumerable<ViewTaiKhoan> accounts = obj.ViewTaiKhoans;
            if (!string.IsNullOrEmpty(query))
            {
                accounts = accounts.Where(x => (x.Ho + " " + x.Ten).ToLower().Contains(query.ToLower()) || x.TenDangNhap.ToLower().Contains(query.ToLower()));
            }
            return accounts.OrderBy(x => x.ID).ToPagedList(page,pageSize);
        }

        public TaiKhoan GetByUsername(string username)
        {
            return obj.TaiKhoans.SingleOrDefault(x => x.TenDangNhap == username);
        }

        public TaiKhoan GetByTaiKhoanID(long id)
        {
            return obj.TaiKhoans.Find(id);
        }

        public bool LoginValid(String username, String password)
        {
            return (obj.TaiKhoans.Count(x => x.TenDangNhap == username && x.MatKhau == password) > 0);
        }

        public bool Delete(long id)
        {
            try
            {
                var account = GetByTaiKhoanID(id);
                obj.TaiKhoans.Remove(account);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
