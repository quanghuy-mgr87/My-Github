package JavaPractice.JavaOOPBasic.JavaLearn;

import java.util.Scanner;

public class HocSinh extends Nguoi {
    private String maHocSinh = "HS1";
    private double diemTB = 5;
    private String maLop = "12A1";

    public void Di(){
        System.out.println("Di hoc");
    }

    public String getMaHocSinh() {
        return maHocSinh;
    }

    public void setMaHocSinh(String maHocSinh) {
        this.maHocSinh = maHocSinh;
    }

    public double getDiemTB() {
        return diemTB;
    }

    //Constructor không tham số
    public HocSinh() {
    }

    //Constructor có tham số
    public HocSinh(String hoTen, Integer tuoi, String diaChi, String soCMT, String soDienThoai, String maHocSinh,
                   double diemTB, String maLop) {
        super(hoTen, tuoi, diaChi, soCMT, soDienThoai);
        this.maHocSinh = maHocSinh;
        this.diemTB = diemTB;
        this.maLop = maLop;
    }

    public void setDiemTB(double diemTB) {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap tai khoan: ");
        String taiKhoan = sc.nextLine();
        System.out.printf("Mat khau: ");
        String matKhau = sc.nextLine();
        if (taiKhoan.equals("admin") && matKhau.equals("admin")) {
            this.diemTB = diemTB;
        } else {
            System.out.println("Ban khong co quyen thay doi diem");
        }
    }

    public String getMaLop() {
        return maLop;
    }

    public void setMaLop(String maLop) {
        this.maLop = maLop;
    }

    public void DoiThongTin() {
        hoTen = "Duong Van B";
//        tuoi = 50;
    }

    public void NhapThongTinHocSinh() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap ma hoc sinh: ");
        maHocSinh = sc.nextLine();
        System.out.printf("Nhap diem trung binh: ");
        diemTB = sc.nextDouble();
        System.out.printf("Nhap ma lop: ");
        maLop = sc.nextLine();
    }

    public void InThongTinHocSinh() {
        System.out.println("HocSinh{" +
                "maHocSinh='" + maHocSinh + '\'' +
                ", diemTB=" + diemTB +
                ", maLop='" + maLop + '\'' +
                '}');
    }
}
