use `hocsinh`;
-- Danh sách các học sinh có họ tên bắt đầu bằng chữ T
select * from hocsinh where Hoten like 'T%';
-- Liệt kê danh sách những học sinh có chữ cái cuối cùng trong tên là I
select * from hocsinh where Hoten like '%I';	
-- Danh sách những học sinh có ký tự thứ hai của họ tên là chữ N
select * from hocsinh where Hoten like '_N%';	
-- Liệt kê những học sinh mà họ tên có chứa chữ Thị.
select * from hocsinh where Hoten like N'%Thị%'
-- Cho biết danh sách những học sinh có ký tự đầu tiên của họ tên nằm trong khoảng từ a đến m
select * from hocsinh where Hoten between 'a' and 'm'
-- Liệt kê các học sinh có địa chỉ ở Hà Nội
select * from hocsinh where Diachi = N'Hà Nội'
-- Danh sách các học sinh nữ có địa chỉ ở Hà Nội
select * from hocsinh where Diachi = N'Hà Nội' and Gioitinh = N'nữ'
-- Cho biết những học sinh có ngày sinh từ ngày 01/01/2005 đến ngày 05/06/2005
select * from hocsinh where Ngaysinh between '20050101' and '20050605'
-- Danh sách những học sinh thuộc 1 trong các tỉnh Hà Nội, Thái Bình, Cao Bằng
select * from hocsinh where Diachi = N'Hà Nội' or Diachi = N'Thái Bình' or Diachi = N'Cao Bằng'
-- Cho biết những lớp có trên 30 học sinh và có giáo viên chủ nhiệm tên Quỳnh
select * from lop where Siso > 30 and GVCN like N'%Quỳnh'
-- Danh sách học sinh nam ở Hà Giang thuộc lớp số 5
select * from hocsinh join lop on hocsinh.lopID = lop.lopID where 
-- Danh sách học sinh chưa có địa chỉ email

-- Danh sách những học sinh không sinh năm 2005
-- Liệt kê danh sách học sinh, họ tên sắp xếp theo thứ tự trong bảng chữ cái
-- Liệt kê danh sách học sinh, sắp xếp theo thứ tự giảm dần của ID học sinh
-- Liệt kê danh sách học sinh, sắp xếp theo thứ tự ngày sinh tăng dần và lớp giảm dần.
-- Liệt kê danh sách lớp tăng dần theo sĩ số
-- Liệt kê danh sách học sinh nữ ở Hà Nội, sắp xếp tăng dần theo ngày sinh
-- Liệt kê những học sinh mà địa chỉ không thuộc 1 trong các tỉnh Hà Nội, Lào Cai, Thanh Hóa, sắp xếp lớp tăng dần
-- Liệt kê tất cả địa chỉ quê quán của học sinh (không được liệt kê trùng lặp)