package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_06_BaiToanTinhTongChuoiTheoCongThuc {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap n: ");
        int n = sc.nextInt();
        double sum = 0;

        for (int i = 1; i <= n; i++) {
            sum += 1.0 / (i * (i + 1));
        }

        System.out.println("Tong la: " + sum);
    }
}
