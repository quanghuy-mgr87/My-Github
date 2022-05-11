package JavaPractice.JavaOOPBasic.Nguoi;

import java.time.LocalDate;
import java.util.Date;
import java.util.Scanner;

public class Nguoi {
    private int MaSo;
    private String HoTen;
    private LocalDate NgaySinh;
    private String Ho;
    private String Dem;
    private String Ten;

    public int getMaSo() {
        return MaSo;
    }

    public void setMaSo(int maSo) {
        MaSo = maSo;
    }

    public String getHoTen() {
        return HoTen;
    }

    public void setHoTen(String hoTen) {
        HoTen = ChuanHoaTen(hoTen);
        String[] temp = HoTen.split(" ");
        setHo(temp[0]);
        setTen(temp[temp.length - 1]);
        String name = "";
        for (int i = 1; i < temp.length - 1; i++) {
            name += temp[i] + " ";
        }
        setDem(name.trim());
    }

    public LocalDate getNgaySinh() {
        return NgaySinh;
    }

    public void setNgaySinh(LocalDate ngaySinh) {
        NgaySinh = ngaySinh;
    }

    public String getHo() {
        return Ho;
    }

    private void setHo(String ho) {
        Ho = ho;
    }

    public String getDem() {
        return Dem;
    }

    private void setDem(String dem) {
        Dem = dem;
    }

    public String getTen() {
        return Ten;
    }

    private void setTen(String ten) {
        Ten = ten;
    }

    private void TaoDuLieuHoTen(String hoTen) {
        if (hoTen.isEmpty()) {
            setHoTen("Nguyen Van A");
        } else {
            setHoTen(hoTen);
        }
    }

    public void NhapNgaySinh() {
        Scanner sc = new Scanner(System.in);
        boolean check = false;
        System.out.printf("Nhap ngay sinh: ");
        while (!check) {
            try {
                NgaySinh = LocalDate.parse(sc.nextLine());
                check = true;
            } catch (Exception ex) {
                System.out.printf("Nhap sai, nhap lai: ");
            }
        }
    }

    private String ChuanHoaTen(String hoTen) {
        String name = "";
        hoTen = hoTen.toLowerCase().trim();
        while (hoTen.contains("  ")) {
            hoTen = hoTen.replace("  ", " ");
        }
        String[] arrStr = hoTen.split(" ");
        for (int i = 0; i < arrStr.length; i++) {
            name += arrStr[i].substring(0, 1).toUpperCase() + arrStr[i].substring(1) + " ";
        }
        return name.trim();
    }

    public Nguoi() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Ma so: ");
        setMaSo(Integer.parseInt(sc.nextLine()));
        System.out.printf("Ho ten: ");
        TaoDuLieuHoTen(sc.nextLine());
        NhapNgaySinh();

    }

    public void InThongTin() {
        System.out.println(MaSo + " co ten la " + HoTen + " sinh ngay " + NgaySinh + " co ho la " + Ho + " co dem la " + Dem + " co ten la " + Ten);
    }
}
