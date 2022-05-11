package JavaPractice.JavaOOPBasic.JavaLearn;

import java.time.LocalDate;
import java.util.Scanner;

public abstract class Nguoi {

    //PRIVATE
    protected String hoTen = "Nguyen Van A";
    private Integer tuoi = 30;
    private String diaChi = "Ha Noi";
    private String soCMT = "123456";
    private String soDienThoai = "123456";

    public void Di(){
        System.out.println("Di bo");
    }

    public Nguoi() {
    }

    public Nguoi(String hoTen, Integer tuoi, String diaChi, String soCMT, String soDienThoai) {
        this.hoTen = hoTen;
        this.tuoi = tuoi;
        this.diaChi = diaChi;
        this.soCMT = soCMT;
        this.soDienThoai = soDienThoai;
    }

    //PUBLIC
    public void NhapThongTin() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap ho ten: ");
        hoTen = sc.nextLine();
        System.out.printf("Nhap tuoi: ");
        tuoi = sc.nextInt();
        System.out.printf("Nhap dia chi: ");
        diaChi = sc.nextLine();
        System.out.printf("Nhap so CMT: ");
        soCMT = sc.nextLine();
        System.out.printf("Nhap so dien thoai: ");
        soDienThoai = sc.nextLine();
    }

    public void HienThiThongTin() {
        System.out.println("Nguoi{" +
                "hoTen='" + hoTen + '\'' +
                ", tuoi=" + tuoi +
                ", diaChi='" + diaChi + '\'' +
                ", soCMT='" + soCMT + '\'' +
                ", soDienThoai='" + soDienThoai + '\'' +
                '}');
    }
}
