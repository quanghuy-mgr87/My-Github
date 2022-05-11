package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_05_Fibonacci {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap so luong so Fibonacci: ");
        int num = sc.nextInt();
        String str = "";
        int r = 0, r1 = 0;
        for (int i = 1; i < num; i++) {
            if (r == 0 && r1 == 0) {
                r1 = 1;
                str += r + ", " + r1 + ", ";
            } else {
                int temp = r1;
                r1 += r;
                r = temp;
                str += r1 + ", ";
            }
        }
        System.out.println(str.substring(0,str.length()-2));
    }
}
