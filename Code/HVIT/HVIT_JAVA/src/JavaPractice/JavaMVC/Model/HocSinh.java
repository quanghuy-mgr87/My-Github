package JavaPractice.JavaMVC.Model;

import java.util.Scanner;

public class HocSinh {
    private int maHS;
    private String hoTen;
    private int tuoi;

    public int getMaHS() {
        return maHS;
    }

    public void setMaHS(int maHS) {
        this.maHS = maHS;
    }

    public String getHoTen() {
        return hoTen;
    }

    public void setHoTen(String hoTen) {
        this.hoTen = hoTen;
    }

    public int getTuoi() {
        return tuoi;
    }

    public void setTuoi(int tuoi) {
        this.tuoi = tuoi;
    }

    public void NhapThongTin() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Ma hoc sinh: ");
        setMaHS(Integer.parseInt(sc.nextLine()));
//        sc.nextLine();
        System.out.printf("Ho ten: ");
        setHoTen(sc.nextLine());
        System.out.printf("Tuoi: ");
        setTuoi(sc.nextInt());
    }

    @Override
    public String toString() {
        return "HocSinh{" +
                "maHS=" + maHS +
                ", hoTen='" + hoTen + '\'' +
                ", tuoi=" + tuoi +
                '}';
    }
}
