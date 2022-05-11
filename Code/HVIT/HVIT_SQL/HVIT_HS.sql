USE HocSinh;

-- Tìm những học sinh học nhiều hơn 3 môn

--SELECT hs.HocSinhID, hs.HoTen, COUNT(hs.HocSinhID) AS 'SLuongMon' FROM dbo.HocSinh AS hs, dbo.MonHoc AS mh, dbo.QuanLyHS AS ql
--WHERE hs.HocSinhID = ql.HocSinhID AND mh.MonHocID = ql.MonHocID
--GROUP BY hs.HocSinhID, hs.HoTen
--HAVING COUNT(hs.HocSinhID) > 3

SELECT dbo.QuanLyHS.HocSinhID, COUNT(HocSinhID) AS sl FROM dbo.QuanLyHS
GROUP BY dbo.QuanLyHS.HocSinhID
HAVING COUNT(dbo.QuanLyHS.HocSinhID) > 3

-- Tìm những học sinh có điểm phẩy môn Toán trên 8
SELECT * FROM dbo.HocSinh AS hs, dbo.MonHoc AS mh, dbo.QuanLyHS AS ql
WHERE hs.HocSinhID = ql.HocSinhID AND mh.MonHocID = ql.MonHocID
AND TenMon = N'Toán' AND ql.DiemPhay > 8


-- Tìm những môn học mà có 5 học sinh tham gia học và có ít nhất 3 bạn đạt từ điểm 8 trở lên

-- cách 1: dùng IN
--SELECT m.MonHocID, m.TenMon, COUNT(m.MonHocID) AS 'SoHS' FROM MonHoc AS m JOIN QuanLyHS AS ql
--ON m.MonHocID = ql.MonHocID
--WHERE m.MonHocID IN
--(
--	SELECT MonHocID FROM QuanLyHS
--	WHERE DiemPhay >= 8
--	GROUP BY MonHocID
--	HAVING COUNT(MonHocID) >= 3
--)
--GROUP BY m.MonHocID, m.TenMon
--HAVING COUNT(m.MonHocID) = 5

-- cách 2: tạo bảng phụ
SELECT m.MonHocID, m.TenMon, COUNT(m.MonHocID) AS 'SoHS' 
FROM MonHoc AS m, QuanLyHS AS ql,
(
	SELECT dbo.QuanLyHS.MonHocID FROM QuanLyHS
	WHERE dbo.QuanLyHS.DiemPhay >= 8
	GROUP BY dbo.QuanLyHS.MonHocID
	HAVING COUNT(dbo.QuanLyHS.MonHocID) >= 3
) AS Temp
WHERE m.MonHocID = ql.MonHocID AND m.MonHocID = Temp.MonHocID
GROUP BY m.MonHocID, m.TenMon
HAVING COUNT(m.MonHocID) = 5


--INSERT dbo.QuanLyHS
--        ( HocSinhID, MonHocID, DiemPhay )
--VALUES  
--( 1,1,8.8),
--( 1,2,7.7),
--( 1,3,7.7),
--( 1,4,7.7),
--( 1,5,7.7),
--( 1,6,7.7),
--( 4,1,9),
--( 4,2,8.8),
--( 5,1,8.8),
--( 6,1,2.3),
--( 7,1,4.5),
--( 7,7,8.8),
--( 6,7,8.8),
--( 5,7,8.8),
--( 4,7,8.8),
--( 1,7,8.8);