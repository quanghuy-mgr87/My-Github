package JavaPractice.JavaOOPBasic.HocSinh;

import java.time.LocalDate;
import java.util.Scanner;

public class HocSinh {
    private String HoTen, Lop;
    private LocalDate NgaySinh;
    private double DiemToan, DiemVan, DiemAnh, DiemTB;

    public String getHoTen() {
        return HoTen;
    }

    public void setHoTen(String hoTen) {
        HoTen = hoTen;
    }

    public String getLop() {
        return Lop;
    }

    public void setLop(String lop) {
        Lop = lop;
    }

    public LocalDate getNgaySinh() {
        return NgaySinh;
    }

    public void setNgaySinh(LocalDate ngaySinh) {
        NgaySinh = ngaySinh;
    }

    public double getDiemToan() {
        return DiemToan;
    }

    public void setDiemToan(double diemToan) {
        DiemToan = diemToan;
    }

    public double getDiemVan() {
        return DiemVan;
    }

    public void setDiemVan(double diemVan) {
        DiemVan = diemVan;
    }

    public double getDiemAnh() {
        return DiemAnh;
    }

    public void setDiemAnh(double diemAnh) {
        DiemAnh = diemAnh;
    }

    public double getDiemTB() {
        return DiemTB;
    }

    private void setDiemTB() {
        DiemTB = (DiemToan + DiemVan + DiemAnh) * 1.0 / 3;
    }

    public void NhapNgaySinh() {
        Scanner sc = new Scanner(System.in);
        boolean check = false;
        while (!check) {
            try {
                NgaySinh = LocalDate.parse(sc.nextLine());
                check = true;
            } catch (Exception ex) {
                System.out.printf("Nhap sai dinh dang.\n" +
                        "Nhap lai: ");
            }
        }
    }

    public HocSinh() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap ho ten: ");
        HoTen = sc.nextLine();
        System.out.printf("Nhap lop: ");
        Lop = sc.nextLine();
        System.out.printf("Ngay sinh: ");
        NhapNgaySinh();
        System.out.printf("Diem toan: ");
        DiemToan = sc.nextDouble();
        System.out.printf("Diem van: ");
        DiemVan = sc.nextDouble();
        System.out.printf("Diem anh: ");
        DiemAnh = sc.nextDouble();
        setDiemTB();
    }

    public HocSinh(String hoTen, String lop, LocalDate ngaySinh, double diemToan, double diemVan, double diemAnh) {
        HoTen = hoTen;
        Lop = lop;
        NgaySinh = ngaySinh;
        DiemToan = diemToan;
        DiemVan = diemVan;
        DiemAnh = diemAnh;
    }

    public void InThongTin() {
        System.out.println(HoTen + " hoc lop " + Lop + ", co diem trung binh la " + DiemTB);
    }
}
