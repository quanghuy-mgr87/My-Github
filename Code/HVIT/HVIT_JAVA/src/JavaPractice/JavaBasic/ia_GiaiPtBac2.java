package JavaPractice.JavaBasic;

import java.util.Scanner;
import java.util.zip.DeflaterOutputStream;

public class ia_GiaiPtBac2 {
    public static void main(String[] args) {
        double a, b, c;
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap a: ");
        a = sc.nextDouble();
        System.out.printf("Nhap b: ");
        b = sc.nextDouble();
        System.out.printf("Nhap c: ");
        c = sc.nextDouble();
        System.out.println("Phuong trinh bac 2: " + (int) a + "x2 + " + (int) b + "x + " + (int) c + " = 0");
        if (a == 0) {
            if (b == 0) {
                if (c == 0) {
                    System.out.println("Phuong trinh vo so nghiem");
                } else {
                    System.out.println("Phuong trinh vo nghiem");
                }
            } else {
                System.out.println("Nghiem cua phuong trinh: " + -c * 1.0 / b);
            }
        } else {
            Double delta = Math.pow(b, 2) - 4 * a * c;
            if (delta == 0) {
                System.out.println("Phuong trinh co nghiem kep: " + -b * 1.0 / (2 * a));
            } else if (delta < 0) {
                System.out.println("Phuong trinh vo nghiem");
            } else {
                System.out.println("Phuong trinh co 2 nghiem phan biet:");
                System.out.println("x1 = " + (-b + Math.sqrt(delta)) * 1.0 / (2 * a));
                System.out.println("x2 = " + (-b - Math.sqrt(delta)) * 1.0 / (2 * a));
            }
        }
    }
}
