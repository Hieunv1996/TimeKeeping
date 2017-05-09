Create View ViewTaiKhoan As
Select TaiKhoan.*,NhanVien.Ho, NhanVien.Ten, Quyen.TenQuyen
From TaiKhoan, NhanVien, Quyen
Where TaiKhoan.IDNhanVien = NhanVien.ID
And Quyen.ID = TaiKhoan.IDQuyen

-------------------------------------------------------

Create View ViewTraLuong As
Select TraLuong.*,
(select NhanVien.Ho Where NhanVien.ID = IDNhanVien) as 'HoNV',
(select NhanVien.Ten Where NhanVien.ID = IDNhanVien) as 'TenNV',
(select NhanVien.Ho Where NhanVien.ID = NguoiTra) as 'HoNT',
(select NhanVien.Ten Where NhanVien.ID = NguoiTra) as 'TenNT'
From TraLuong, NhanVien

-------------------------------------------------------

Create View ViewChamCong As
Select ChamCong.*,CaLamViec.TenCaLamViec,TinhTrang.KiHieu,
(select NhanVien.Ho Where NhanVien.ID = IDNhanVien) as 'HoNV',
(select NhanVien.Ten Where NhanVien.ID = IDNhanVien) as 'TenNV',
(select NhanVien.Ho Where NhanVien.ID = NguoiDuyet) as 'HoND',
(select NhanVien.Ten Where NhanVien.ID = NguoiDuyet) as 'TenND'
From ChamCong, NhanVien, CaLamViec,TinhTrang

------------------------------------------------------

Create View ViewNhanVien As
Select NhanVien.*, ChucVu.TenChucVu, PhongBan.TenPhongBan, Luong.HeSoLuong
From NhanVien, ChucVu,PhongBan,Luong
Where NhanVien.IDChucVu = ChucVu.ID
And NhanVien.IDHeSoLuong = Luong.ID
And NhanVien.IDPhongBan = PhongBan.ID

-----------------------------------------------------

Create View ViewPhuCap As
Select PhuCap.*, NhanVien.Ho,NhanVien.Ten
From PhuCap, NhanVien
Where PhuCap.IDNhanVien = NhanVien.ID

-----------------------------------------------------

Create View ViewThuongPhat As
Select ThuongPhat.*, NhanVien.Ho,NhanVien.Ten
From ThuongPhat, NhanVien
Where ThuongPhat.IDNhanVien = NhanVien.ID