using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.EF;

using PagedList;

namespace Model.DAO
{
    public class ChamCongDAO
    {
        private TimeKeepingDbContext obj = null;
        public ChamCongDAO()
        {
            obj = new TimeKeepingDbContext();
        }

        public bool Insert(ChamCong chamCong)
        {
            try
            {
                chamCong.DauThoiGian = DateTime.Now;
                obj.ChamCongs.Add(chamCong);
                return obj.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ChamCong chamCong)
        {
            try
            {
                ChamCong newChamCong = obj.ChamCongs.Find(chamCong.ID);
                newChamCong.IDCaLamViec = chamCong.IDCaLamViec;
                newChamCong.XinNghiPhep = chamCong.XinNghiPhep;
                newChamCong.IDNhanVien = chamCong.IDNhanVien;
                newChamCong.IDTinhTrang = chamCong.IDTinhTrang;
                newChamCong.MoTa = chamCong.MoTa;
                newChamCong.Ngay = chamCong.Ngay;
                newChamCong.PheDuyet = chamCong.PheDuyet;
                newChamCong.NguoiDuyet = chamCong.NguoiDuyet;
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }

        public IEnumerable<ChamCong> GetListChamCong(string keyword, int page, int pageSize)
        {
            IEnumerable<ChamCong> objChamCongs = obj.ChamCongs;
            if (!string.IsNullOrEmpty(keyword))
            {
                objChamCongs = objChamCongs.Where(x => x.IDNhanVien.ToString().Contains(keyword));
            }
            return objChamCongs.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }

        public ChamCong GetByCaLamViecID(long id)
        {
            return obj.ChamCongs.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var caLam = GetByCaLamViecID(id);
                obj.ChamCongs.Remove(caLam);
                return obj.SaveChanges() > 0;
            }
            catch
            {

                return false;
            }
        }
    }
}
