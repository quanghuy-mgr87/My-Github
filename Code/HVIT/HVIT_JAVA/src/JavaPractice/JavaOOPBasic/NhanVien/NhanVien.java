package JavaPractice.JavaOOPBasic.NhanVien;

import java.util.Scanner;

public class NhanVien {
    private int MaNhanVien;
    private String HoVaTen;
    private String PhongBan;
    private String DiaChi;
    private String SoDienThoai;

    public int getMaNhanVien() {
        return MaNhanVien;
    }

    public void setMaNhanVien(int maNhanVien) {
        MaNhanVien = maNhanVien;
    }

    public String getHoVaTen() {
        return HoVaTen;
    }

    public void setHoVaTen(String hoVaTen) {
        HoVaTen = hoVaTen;
    }

    public String getPhongBan() {
        return PhongBan;
    }

    public void setPhongBan(String phongBan) {
        PhongBan = phongBan;
    }

    public String getDiaChi() {
        return DiaChi;
    }

    public void setDiaChi(String diaChi) {
        DiaChi = diaChi;
    }

    public String getSoDienThoai() {
        return SoDienThoai;
    }

    public void setSoDienThoai(String soDienThoai) {
        SoDienThoai = soDienThoai;
    }

    public NhanVien() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Ma nhan vien: ");
        setMaNhanVien(sc.nextInt());
        System.out.printf("Ho ten: ");
        sc.nextLine();
        setHoVaTen(sc.nextLine());
        System.out.printf("Phong ban: ");
        setPhongBan(sc.nextLine());
        System.out.printf("Dia chi: ");
        setDiaChi(sc.nextLine());
        System.out.printf("So dien thoai: ");
        setSoDienThoai(sc.nextLine());
    }

    public void InThongTin() {
        System.out.println("Nhan vien " + getMaNhanVien() + " " + getHoVaTen() + " thuoc phong ban " + getPhongBan() + " co so dien thoai la " + getSoDienThoai());
    }
}
