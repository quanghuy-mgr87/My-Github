package JavaPractice.JavaMathFunction;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class JA3_1_12_NhapMangVaSapXep {
    static int NhapSoNguyen() {
        Scanner sc = new Scanner(System.in);
        int ret = 0;
        boolean check = false;
        while (!check) {
            try {
                ret = sc.nextInt();
                check = true;
            } catch (Exception ex) {
                System.out.println("Ban can nhap so nguyen!");
                System.out.printf("Nhap lai: ");
                sc.nextLine();
            }
        }
        return ret;
    }

    static void NhapMang(Integer[] arrInt, int num) {
        Scanner sc = new Scanner(System.in);
        for (int i = 0; i < num; i++) {
            System.out.printf("arrInt[" + i + "] = ");
            arrInt[i] = NhapSoNguyen();
        }
    }

    static void InMang(Integer[] arrInt) {
        for (int i = 0; i < arrInt.length; i++) {
            if (i == arrInt.length - 1) {
                System.out.print(arrInt[i]);
            } else {
                System.out.printf(arrInt[i] + ",");
            }
        }
        System.out.println();
    }

    static void SapXep(Integer[] arrInt) {
        Arrays.sort(arrInt);
    }

    public static void main(String[] args) {
        int num;
        System.out.printf("Nhap so luong phan tu: ");
        num = NhapSoNguyen();

        Integer[] arrInt = new Integer[num];
        NhapMang(arrInt, num);
        System.out.println("Mang vua nhap:");
        InMang(arrInt);

        SapXep(arrInt);
        System.out.println("Mang sau khi sap xep:");
        InMang(arrInt);
    }
}
