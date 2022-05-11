package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_8_TinhTongCacUocSoChan {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n;
        do {
            System.out.printf("Nhap n: ");
            n = sc.nextInt();
        } while (n <= 0);

        int sum = 0;

        for (int i = 1; i <= n; i++) {
            if (n % i == 0 && i % 2 == 0) {
                sum += i;
            }
        }

        if (n % 2 == 0) {
            System.out.println("Tong la: " + sum);
        }
    }
}
