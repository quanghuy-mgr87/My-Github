package JavaPractice.JavaOOPBasic.BinhLinh;

public class Main {
    public static void main(String[] args) {
        BinhLinh linh = new BinhLinh();
        linh.setTen("linh_1");
        linh.InThongTin();
        BinhLinh linh2 = new BinhLinh();
        linh2.setTen("linh_2");
        linh2.setTrangBi(true);
        linh2.InThongTin();
        CungThu cung = new CungThu();
        cung.setTen("cung_1");
        cung.InThongTin();
        KiemSi kiem = new KiemSi();

        kiem.setTen("kiem_1");
        kiem.setTrangBi(true);
        kiem.InThongTin();

        KiemSi kiem2 = new KiemSi();
        kiem2.setTen("kiem_2");
        kiem2.InThongTin();


        System.out.println(kiem.ChienDau(kiem2));
    }
}
