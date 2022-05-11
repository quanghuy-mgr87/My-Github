package JavaPractice.JavaMVC.View;

import JavaPractice.JavaMVC.Controller.HocSinhController;
import JavaPractice.JavaMVC.Model.HocSinh;
import JavaPractice.JavaMVC.Model.ListHS;

import java.util.Scanner;

public class HocSinhView {
    public static Scanner sc = new Scanner(System.in);
    private static HocSinhController hocSinhController = new HocSinhController();

    public static void Menu() {
        System.out.printf("1. Them hoc sinh.\n" +
                "2. Sua hoc sinh.\n" +
                "3. Xoa hoc sinh.\n" +
                "4. Hien thi danh sach\n" +
                "0. Thoat\n" +
                "Moi nhap: ");
        int x = sc.nextInt();
        ThucThi(x);
    }

    public static void ThucThi(int x) {
        switch (x) {
            case 1:
                HocSinh hsMoi = new HocSinh();
                hsMoi.NhapThongTin();
                boolean isAdd = hocSinhController.ThemHocSinh(hsMoi);
                if (isAdd) {
                    System.out.println("Them thanh cong!");
                } else {
                    System.out.println("Them that bai!");
                }
                break;
            case 2:
                HocSinh hs = new HocSinh();
                hs.NhapThongTin();
                boolean isUpdate = hocSinhController.SuaHocSinh(hs);
                if (isUpdate) {
                    System.out.println("Sua thanh cong!");
                } else {
                    System.out.println("Sua that bai!");
                }
                break;
            case 3:
                System.out.printf("Nhap ma hoc sinh can xoa: ");
                int maHS = sc.nextInt();
                boolean isDelete = hocSinhController.XoaHocSinh(maHS);
                if (isDelete) {
                    System.out.println("Xoa thanh cong!");
                } else {
                    System.out.println("Xoa that bai!");
                }
                break;
            case 4:
                System.out.println("Danh sach hoc sinh: ");
                hocSinhController.HienThiDS(ListHS.lst);
                break;
            default:
                return;
        }
        Menu();
    }
}
