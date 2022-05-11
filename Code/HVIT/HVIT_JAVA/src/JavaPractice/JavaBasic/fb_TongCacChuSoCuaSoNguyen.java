package JavaPractice.JavaBasic;

import java.util.Scanner;

public class fb_TongCacChuSoCuaSoNguyen {
    public static void main(String[] args) {
        int a;
        int tong = 0;
        Scanner sc = new Scanner(System.in);
        System.out.println("Nhap so nguyen a: ");
        a = sc.nextInt();
        while (a >= 10) {
            tong += a % 10;
            a /= 10;
        }
        tong += a;
        System.out.println("Tong cac chu so la: " + tong);
    }
}
