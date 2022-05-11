package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_7_TinhTichCacUocCuaSoNguyen {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n;
        do {
            System.out.printf("Nhap n: ");
            n = sc.nextInt();
        } while (n <= 0);
        int tich = 1;
        String str = "";

        for (int i = 1; i <= n; i++) {
            if (n % i == 0) {
                tich *= i;
                str += i + " x ";
            }
        }

        System.out.println(str.substring(0, str.length() - 2) + " = " + tich);
    }
}
