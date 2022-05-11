package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_04_PhanTich1SoThanhThuaSoNguyenTo {
    public static void main(String[] args) {
        int a;
        int tich = 1;
        String str = "";
        Boolean laSoNT = false;
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap a: ");
        a = sc.nextInt();

        while (a > 1) {
            if (a % 2 == 0) {
                tich *= 2;
                str += 2 + " x ";
                a /= 2;
            } else {
                //Kiem tra so nguyen to
                for (int i = 3; i <= a; i++) {
                    if (a % i == 0) {
                        for (int j = 2; j < i; j++) {
                            if (i % j == 0) {
                                laSoNT = false;
                            } else {
                                laSoNT = true;
                            }
                        }
                        //Neu la so nguyen to thi thuc hien chia
                        if (laSoNT) {
                            tich *= i;
                            str += i + " x ";
                            a /= i;
                        }
                    }
                }
            }
        }
        System.out.println(str.substring(0, str.length() - 3) + " = " + tich);
    }
}
