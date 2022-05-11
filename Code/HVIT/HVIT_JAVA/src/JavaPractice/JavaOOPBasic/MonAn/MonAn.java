package JavaPractice.JavaOOPBasic.MonAn;

import java.util.Scanner;

public class MonAn {
    private String TenMonAn;
    private double GiaBan;
    private String GioiThieu;
    private String NguyenLieuChinh;

    public String getTenMonAn() {
        return TenMonAn;
    }

    public void setTenMonAn(String tenMonAn) {
        TenMonAn = tenMonAn;
    }

    public double getGiaBan() {
        return GiaBan;
    }

    public void setGiaBan(double giaBan) {
        GiaBan = giaBan;
    }

    public String getGioiThieu() {
        return GioiThieu;
    }

    public void setGioiThieu(String gioiThieu) {
        GioiThieu = gioiThieu;
    }

    public String getNguyenLieuChinh() {
        return NguyenLieuChinh;
    }

    public void setNguyenLieuChinh(String nguyenLieuChinh) {
        NguyenLieuChinh = nguyenLieuChinh;
    }

    public MonAn() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap ten mon an: ");
        TenMonAn = sc.nextLine();
        System.out.printf("Nhap gia ban: ");
        GiaBan = sc.nextDouble();
        sc.nextLine();
        System.out.printf("Gioi thieu mon an: ");
        GioiThieu = sc.nextLine();
        System.out.printf("Nguyen lieu chinh: ");
        NguyenLieuChinh = sc.nextLine();
    }

    public void HienThi() {
        System.out.println("Mon an: " + TenMonAn + ", " + GioiThieu + ", duoc lam tu cac nguyen lieu: " + NguyenLieuChinh + ", co gia la: " + GiaBan);
    }
}
