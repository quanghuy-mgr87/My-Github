use nhanvien;
select * from phancong;

select DuanID, count(DuanID) from phancong group by DuanID;

select * from phancong;

select NhanVienID, sum(Sogiolam) from phancong group by NhanvienID;

select *, sum(Sogiolam) from phancong group by NhanvienID, DuanID having DuanID = 1 order by sum(Sogiolam) desc limit 1;

select DuanID from phancong
group by DuanID
having count(NhanvienID) = (select count(NhanvienID) from phancong group by DuanID order by count(NhanvienID) asc limit 1);

select NhanvienID, sum(Sogiolam) from phancong group by NhanvienID order by sum(Sogiolam) desc limit 1;

select DuanID, sum(Sogiolam) from phancong group by DuanID;

select DuanID, avg(Sogiolam) from phancong group by DuanID;

/*Tính số giờ làm trung bình mỗi nhân viên (mỗi dự án làm trung bình bao nhiêu giờ)*/
select NhanvienID, avg(Sogiolam) from phancong group by NhanvienID;

select DuanID, sum(Sogiolam) from phancong group by DuanID order by sum(Sogiolam) desc limit 3;

select NhanvienID, sum(Sogiolam) from phancong group by NhanvienID having sum(Sogiolam) > 300;

select NhanvienID, sum(Sogiolam) from phancong group by NhanvienID having sum(Sogiolam) between 150 and 200;

select Diachi, count(Diachi) as sonhanvien from nhanvien group by Diachi;


-- Danh sách những sinh viên có tuổi từ 21 đến 23

-- Danh sách sinh viên sinh vào mùa xuân
-- Cho biết thông tin về mức học bổng của các sinh viên. Trong đó, mức học bổng sẽ hiển thị là “Học bổng cao” nếu giá trị của học bổng lớn hơn 150,000 và ngược lại hiển thị là “Mức trung bình”
-- Cho biết kết quả điểm thi của các sinh viên (Qua môn, trượt).
-- Cho biết tổng số sinh viên, số sinh viên nam và số sinh viên nữ của mỗi khoa.
-- Cho biết số lượng sinh viên theo từng tuổi [19-23]
-- Cho biết số lượng sinh viên đậu và số lượng sinh viên rớt của từng môn trong lần thi 1.
-- Cho biết danh sách sinh viên rớt 2 môn trở lên ở lần thi 1.
-- Cho biết khoa nào có 2 sinh viên nam trở lên.
-- Cho biết môn không có sinh viên rớt ở lần 1.
-- Cho biết sinh viên có điểm trung bình lần 1 từ 7 trở lên và không rớt môn nào ở lần 1.
-- Cho biết sinh viên đăng ký học hơn 3 môn mà thi lần 1 không bị rớt môn nào.
-- Tìm những sinh viên nam 20 tuổi có học bổng mà quê quán không phải 1 trong các tỉnh Hà Nội, Đà Nẵng, Hải Phòng, Thái Bình.
-- Tìm những sinh viên nữ thuộc khoa số 1 sinh vào mùa hè và có học bổng
-- Tìm môn học có điểm trung bình trên 7 mà không có sinh viên trượt ở lần thi 1
-- Tìm những sinh viên trượt 3 môn học trở lên
-- Tìm những sinh viên học 5 môn trở lên mà điểm trung bình thi lần 1 trên 8
-- Điểm thi cao nhất và thấp nhất môn học 1
-- Tìm những sinh viên có điểm thi lần 2 cao hơn hoặc bằng điểm cao nhất trong lần thi 1