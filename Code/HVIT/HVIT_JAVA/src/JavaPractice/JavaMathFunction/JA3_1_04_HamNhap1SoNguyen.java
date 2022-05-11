package JavaPractice.JavaMathFunction;

import java.util.Scanner;

public class JA3_1_04_HamNhap1SoNguyen {
    static int NhapSoNguyen() {
        Scanner sc = new Scanner(System.in);
        int ret = 0;
        boolean check = false;
        while (!check) {
            try {
                System.out.printf("Nhap so: ");
                ret = sc.nextInt();
                check = true;
            } catch (Exception ex) {
                System.out.println("So phai la so nguyen!");
                sc.nextLine();
            }
        }
        return ret;
    }

    public static void main(String[] args) {
        int num = NhapSoNguyen();
        System.out.println("So vua nhap la: " + num);
    }
}
