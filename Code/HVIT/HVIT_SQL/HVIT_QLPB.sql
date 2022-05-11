USE QLPhongBan;

-- Tìm những nhân viên thuộc phòng ban 'marketing' và không tham gia dự án nào
SELECT * FROM dbo.NhanVien JOIN dbo.PhongBan
ON PhongBan.MaPhongBan = NhanVien.MaPhongBan
WHERE TenPhongBan = 'marketing' AND MaNhanVien NOT IN
(
	SELECT MaNhanVien FROM dbo.QuanLyDuAn
)


-- Tìm những nhân viên ở "Hà Nội" và tham gia từ 3 dự án trở lên
SELECT NhanVien.MaNhanVien, HoTen, DiaChi, COUNT(NhanVien.MaNhanVien) AS 'SoDuAn' FROM dbo.NhanVien JOIN dbo.QuanLyDuAn
ON QuanLyDuAn.MaNhanVien = NhanVien.MaNhanVien
WHERE DiaChi = N'Hà Nội'
GROUP BY NhanVien.MaNhanVien, HoTen, DiaChi
HAVING COUNT(NhanVien.MaNhanVien) >= 3


-- Tìm những nhân viên có số giờ làm việc nhiều nhất của mỗi dự án

--SELECT DISTINCT dbo.NhanVien.MaNhanVien, dbo.DuAn.MaDuAn, dbo.QuanLyDuAn.SoGioLamViec
--FROM dbo.NhanVien, dbo.DuAn, dbo.QuanLyDuAn, 
--(
--	-- tạo bảng phụ chứa mã dự án và số giờ làm việc lớn nhất trong dự án đó
--	SELECT dbo.DuAn.MaDuAn, MAX(dbo.QuanLyDuAn.SoGioLamViec) AS SoGio
--	FROM dbo.DuAn JOIN dbo.QuanLyDuAn
--	ON DuAn.MaDuAn = QuanLyDuAn.MaDuAn
--	GROUP BY DuAn.MaDuAn
--) AS Tmp
--WHERE QuanLyDuAn.MaDuAn = Tmp.MaDuAn
--AND QuanLyDuAn.MaNhanVien = NhanVien.MaNhanVien
--AND QuanLyDuAn.MaDuAn = DuAn.MaDuAn
--AND dbo.QuanLyDuAn.SoGioLamViec = Tmp.SoGio 
--ORDER BY DuAn.MaDuAn ASC

SELECT DISTINCT dbo.NhanVien.MaNhanVien, dbo.QuanLyDuAn.MaDuAn, dbo.QuanLyDuAn.SoGioLamViec
FROM dbo.NhanVien, dbo.QuanLyDuAn, 
(
	-- tạo bảng phụ chứa mã dự án và số giờ làm việc lớn nhất trong dự án đó
	SELECT dbo.QuanLyDuAn.MaDuAn, MAX(dbo.QuanLyDuAn.SoGioLamViec) AS SoGio
	FROM QuanLyDuAn
	GROUP BY dbo.QuanLyDuAn.MaDuAn
) AS Tmp
WHERE QuanLyDuAn.MaDuAn = Tmp.MaDuAn
AND QuanLyDuAn.MaNhanVien = NhanVien.MaNhanVien
AND dbo.QuanLyDuAn.SoGioLamViec = Tmp.SoGio 
ORDER BY dbo.QuanLyDuAn.MaDuAn ASC