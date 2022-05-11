package JavaPractice.JavaOOPBasic.SoPhuc;

import java.util.Scanner;

public class SoPhuc {
    private double PhanThuc;
    private double PhanAo;

    public double getPhanThuc() {
        return PhanThuc;
    }

    public void setPhanThuc(double phanThuc) {
        PhanThuc = phanThuc;
    }

    public double getPhanAo() {
        return PhanAo;
    }

    public void setPhanAo(double phanAo) {
        PhanAo = phanAo;
    }

    public SoPhuc() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap phan thuc: ");
        setPhanThuc(sc.nextDouble());
        System.out.printf("Nhap phan ao: ");
        setPhanAo(sc.nextDouble());
    }

    public SoPhuc(double PhanThuc, double PhanAo) {
        setPhanAo(PhanThuc);
        setPhanAo(PhanAo);
    }

    public void InThongTin() {
        System.out.println(getPhanThuc() + "+" + getPhanAo() + "i");
    }
}
