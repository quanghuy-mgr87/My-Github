package JavaPractice.JavaMathFunction;

import java.util.Scanner;

public class JA3_2_04_HamTimSoNhoNhat {
    static int TimMin(int a, int b, int c) {
        return Math.min(Math.min(a, b), c);
    }

    public static void main(String[] args) {
        int a, b, c;
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap a: ");
        a = sc.nextInt();
        System.out.printf("Nhap b: ");
        b = sc.nextInt();
        System.out.printf("Nhap c: ");
        c = sc.nextInt();
        System.out.println("So nho nhat trong 3 so la: " + TimMin(a, b, c));
    }
}
