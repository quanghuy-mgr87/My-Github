CREATE DATABASE HVIT;

USE HVIT;

CREATE TABLE KhachHang
(
	KhachHangID INT IDENTITY PRIMARY KEY,
	HoTen NVARCHAR(50),
	DiaChi NVARCHAR(100),
	SoDienThoai CHAR(12),
	NgaySinh DATE,
	Email CHAR(30)
)
GO

CREATE TABLE LoaiSanPham
(
	LoaiSanPhamID INT IDENTITY PRIMARY KEY,
	TenLoai NVARCHAR(50),
	GhiChu NVARCHAR(100)
)
GO

CREATE TABLE SanPham
(
	SanPhamID INT IDENTITY PRIMARY KEY,
	LoaiSanPhamID INT,
	KyHieuSanPham CHAR(10),
	TenSanPham NVARCHAR(50),
	MoTa NVARCHAR(100),
	NhaSanXuat NVARCHAR(50),
	NgayDang DATE,
	GiaBan INT,
	LaSanPhamMoi INT
)
GO

--Tạo khóa ngoại
ALTER TABLE dbo.SanPham
ADD CONSTRAINT FK_SP
FOREIGN KEY (LoaiSanPhamID) REFERENCES dbo.LoaiSanPham (LoaiSanPhamID)

CREATE TABLE DonDatHang
(
	DonDatHangID INT IDENTITY PRIMARY KEY,
	KhachHangID INT,
	SoHieuDon INT,
	NgayDat DATE,
	NgayGioTraThucTe DATETIME,
	GhiChu NVARCHAR(100),
	TinhTrang CHAR(10)
)
GO

--Tạo khóa ngoại
ALTER TABLE dbo.DonDatHang
ADD CONSTRAINT FK_DDH
FOREIGN KEY (KhachHangID) REFERENCES dbo.KhachHang (KhachHangID)
GO

CREATE TABLE ChiTietDonDatHang
(
	ChiTietDonDatHangID INT IDENTITY PRIMARY KEY,
	DonDatHangID INT,
	SanPhamID INT,
	SoLuong INT
)
GO

--Tạo khóa ngoại
ALTER TABLE dbo.ChiTietDonDatHang
ADD CONSTRAINT FK_CTDDH
FOREIGN KEY (DonDatHangID) REFERENCES dbo.DonDatHang (DonDatHangID),
FOREIGN KEY (SanPhamID) REFERENCES dbo.SanPham (SanPhamID)
GO

-------------------------------------------------------------------------------------------------------

SELECT * FROM dbo.LoaiSanPham;
SELECT * FROM dbo.SanPham;
SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.DonDatHang;
SELECT * FROM dbo.ChiTietDonDatHang;
UPDATE dbo.SanPham SET NgayDang = GETDATE();

-------------------------------------------------------------------------------------------------------

-- 1.Tìm các sản phẩm có ký hiệu “SP01” hoặc “SP02”.

SELECT * FROM dbo.SanPham WHERE KyHieuSanPham = 'SP01' OR KyHieuSanPham = 'SP02';



-- 2. In ra danh sách các sản phẩm không bán được trong năm 2018

SELECT * FROM dbo.SanPham
WHERE YEAR(NgayDang) = '2018' AND SanPham.SanPhamID NOT IN
(
	SELECT SanPhamID FROM dbo.ChiTietDonDatHang JOIN dbo.DonDatHang
	ON DonDatHang.DonDatHangID = ChiTietDonDatHang.DonDatHangID
	WHERE YEAR(dbo.DonDatHang.NgayDat) = '2018'
)
GO


-- 3. In ra danh sách sản phẩm thuộc loại "Đồ ăn" sản xuất và được bán ra trong ngày 25/8/2019

SELECT * FROM dbo.SanPham JOIN dbo.LoaiSanPham
ON LoaiSanPham.LoaiSanPhamID = SanPham.LoaiSanPhamID
WHERE LoaiSanPham.TenLoai = N'Đồ ăn' AND NgayDang = '20190825' AND SanPhamID IN
(
	SELECT SanPhamID FROM dbo.DonDatHang JOIN dbo.ChiTietDonDatHang
	ON ChiTietDonDatHang.DonDatHangID = DonDatHang.DonDatHangID
	WHERE NgayDat = '20190825'
)


-- 4. Tìm các số hiệu đơn đã mua sản phẩm thuộc loại sản phẩm "Đồ ăn" hoặc "Đồ uống", mỗi sản phẩm mua với số lượng từ 10 đến 20.

SELECT ddh.SoHieuDon FROM dbo.DonDatHang AS ddh, dbo.ChiTietDonDatHang AS ctddh, dbo.SanPham AS sp, dbo.LoaiSanPham AS lsp
WHERE ctddh.DonDatHangID = ddh.DonDatHangID AND ctddh.SanPhamID = sp.SanPhamID AND lsp.LoaiSanPhamID = sp.LoaiSanPhamID
AND (lsp.TenLoai = N'Đồ ăn' OR lsp.TenLoai = N'Đồ uống')
AND ctddh.SoLuong >= 10 AND ctddh.SoLuong <= 20;


-- 5. In ra tổng tiền của các hóa đơn trong ngày 25/08/2019

SELECT SUM(SoLuong * GiaBan) FROM dbo.SanPham, dbo.DonDatHang, dbo.ChiTietDonDatHang
WHERE ChiTietDonDatHang.SanPhamID = SanPham.SanPhamID AND ChiTietDonDatHang.DonDatHangID = DonDatHang.DonDatHangID
AND NgayDat = '20190825'



-- 6. Tính tổng số sản phẩm của từng hóa đơn 

SELECT DonDatHangID, SUM(SoLuong) FROM dbo.ChiTietDonDatHang
GROUP BY DonDatHangID;



-- 7. Tìm khách hàng có số lần mua hàng nhiều nhất.

-- Cach 1:
SELECT * FROM dbo.KhachHang
WHERE KhachHangID IN
(
	SELECT TOP(1) KhachHangID FROM dbo.DonDatHang
	GROUP BY KhachHangID
	ORDER BY (COUNT(KhachHangID)) DESC
)

-- Cach 2:
SELECT TOP 1 dbo.KhachHang.HoTen, COUNT(dbo.DonDatHang.DonDatHangID) AS dem
FROM dbo.KhachHang JOIN dbo.DonDatHang
ON DonDatHang.KhachHangID = KhachHang.KhachHangID
GROUP BY dbo.KhachHang.HoTen
ORDER BY COUNT(dbo.DonDatHang.DonDatHangID) DESC


-- 8. Tìm hóa đơn có mua 3 sản phẩm do “Viet Nam” sản xuất (3 sản phẩm khác nhau)
SELECT ChiTietDonDatHang.DonDatHangID FROM dbo.SanPham, dbo.DonDatHang, dbo.ChiTietDonDatHang
WHERE ChiTietDonDatHang.SanPhamID = SanPham.SanPhamID AND ChiTietDonDatHang.DonDatHangID = DonDatHang.DonDatHangID
AND NhaSanXuat LIKE '%VN%'
GROUP BY ChiTietDonDatHang.DonDatHangID
HAVING COUNT(DISTINCT ChiTietDonDatHang.SanPhamID) > 2


-- 9. Tháng mấy trong năm 2018 có doanh số bán hàng cao nhất ?
SELECT TOP 1 MONTH(NgayDat) AS Thang, YEAR(NgayDat) AS Nam, SUM(SoLuong * GiaBan) AS DoanhSo FROM dbo.ChiTietDonDatHang, dbo.DonDatHang, dbo.SanPham
WHERE DonDatHang.DonDatHangID = ChiTietDonDatHang.DonDatHangID AND ChiTietDonDatHang.SanPhamID = SanPham.SanPhamID
GROUP BY MONTH(NgayDat), YEAR(NgayDat)
ORDER BY DoanhSo DESC



-- 10. Cho biết trị giá hóa đơn cao nhất, thấp nhất là bao nhiêu ?
SELECT MAX(SoLuong * GiaBan) AS 'Trị giá hóa đơn cao nhất', MIN(SoLuong * GiaBan) AS 'Trị giá hóa đơn thấp nhất' 
FROM dbo.DonDatHang, dbo.ChiTietDonDatHang, dbo.SanPham
WHERE DonDatHang.DonDatHangID = ChiTietDonDatHang.DonDatHangID AND ChiTietDonDatHang.SanPhamID = SanPham.SanPhamID



-- 11. Tìm sản phẩm có tổng số lượng bán ra thấp nhất trong năm 2018
SELECT TOP 1 SanPhamID, SUM(SoLuong) AS 'Tong so luong ban ra' FROM dbo.ChiTietDonDatHang JOIN dbo.DonDatHang
ON DonDatHang.DonDatHangID = ChiTietDonDatHang.DonDatHangID
WHERE YEAR(NgayDat) = '2018'
GROUP BY SanPhamID
ORDER BY [Tong so luong ban ra] ASC