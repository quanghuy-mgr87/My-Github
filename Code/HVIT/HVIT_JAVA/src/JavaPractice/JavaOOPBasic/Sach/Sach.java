package JavaPractice.JavaOOPBasic.Sach;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.util.Date;
import java.util.Scanner;

public class Sach {
    private String TenSach;
    private String TheLoaiSach;
    private int Gia;
    private String TacGia;
    private LocalDate NgayXuatBan;

    public LocalDate getNgayXuatBan() {
        return NgayXuatBan;
    }

    public void setNgayXuatBan(LocalDate ngayXuatBan) {
        NgayXuatBan = ngayXuatBan;
    }

    public String getTenSach() {
        return TenSach;
    }

    public void setTenSach(String tenSach) {
        TenSach = tenSach;
    }

    public String getTheLoaiSach() {
        return TheLoaiSach;
    }

    public void setTheLoaiSach(String theLoaiSach) {
        TheLoaiSach = theLoaiSach;
    }

    public int getGia() {
        return Gia;
    }

    public void setGia(int gia) {
        Gia = gia;
    }


    public String getTacGia() {
        return TacGia;
    }

    public void setTacGia(String tacGia) {
        TacGia = tacGia;
    }

    public void NhapNgay() {
        Scanner sc = new Scanner(System.in);
        LocalDate localDate;
        boolean check = false;
        while (!check) {
            try {
                localDate = LocalDate.parse(sc.nextLine());
                check = true;
                setNgayXuatBan(localDate);
            } catch (Exception ex) {
                System.out.printf("Nhap sai dinh dang!\n" +
                        "Nhap lai: ");
            }
        }
    }

    public Sach(String tenSach, String theLoaiSach, int gia, String tacGia, LocalDate ngayXuatBan) {
        TenSach = tenSach;
        TheLoaiSach = theLoaiSach;
        Gia = gia;
        TacGia = tacGia;
        NgayXuatBan = ngayXuatBan;
    }

    public Sach() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Ten sach: ");
        setTenSach(sc.nextLine());
        System.out.printf("The loai sach: ");
        setTheLoaiSach(sc.nextLine());
        System.out.printf("Gia: ");
        setGia(sc.nextInt());
        System.out.printf("Ngay xuat ban (yyyy-MM-dd): ");
        sc.nextLine();
        NhapNgay();
        System.out.printf("Tac gia: ");
        setTacGia(sc.nextLine());
    }

    public void InThongTin() {
        System.out.println(getTenSach() + " la sach the loai " + getTheLoaiSach() + " co gia la " + getGia() + " ngay xuat ban " + getNgayXuatBan() + " tac gia la " + getTacGia());
    }
}
