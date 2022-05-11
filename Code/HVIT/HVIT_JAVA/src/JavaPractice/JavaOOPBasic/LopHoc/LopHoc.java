package JavaPractice.JavaOOPBasic.LopHoc;

import java.util.Scanner;

public class LopHoc {
    private int MaLop;
    private String TenLop;
    private int SiSo;
    private String DiaChi;
    private String GVCN;

    public int getMaLop() {
        return MaLop;
    }

    public void setMaLop(int maLop) {
        MaLop = maLop;
    }

    public String getTenLop() {
        return TenLop;
    }

    public void setTenLop(String tenLop) {
        TenLop = tenLop;
    }

    public int getSiSo() {
        return SiSo;
    }

    public void setSiSo(int siSo) {
        SiSo = siSo;
    }

    public String getDiaChi() {
        return DiaChi;
    }

    public void setDiaChi(String diaChi) {
        DiaChi = diaChi;
    }

    public String getGVCN() {
        return GVCN;
    }

    public void setGVCN(String GVCN) {
        this.GVCN = GVCN;
    }

    public LopHoc() {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Ma lop hoc: ");
        setMaLop(sc.nextInt());
        System.out.printf("Ten lop: ");
        sc.nextLine();
        setTenLop(sc.nextLine());
        System.out.printf("Si so: ");
        setSiSo(Integer.parseInt(sc.nextLine()));
//        sc.nextLine();
        System.out.printf("Dia chi: ");
        setDiaChi(sc.nextLine());
        System.out.printf("Giao vien chu nhiem: ");
        setGVCN(sc.nextLine());
    }

    public LopHoc(int maLop, String tenLop, int siSo, String diaChi, String gvcn) {
        setMaLop(maLop);
        setTenLop(tenLop);
        setSiSo(siSo);
        setDiaChi(diaChi);
        setGVCN(gvcn);
    }

    public void InThongTin() {
        System.out.println("Lop " + getTenLop() + " co ma la " + getMaLop() + " o dia chi " + getDiaChi() + "\n" +
                "Lop co " + getSiSo() + " hoc sinh va co GVCN la " + getGVCN());

    }
}
