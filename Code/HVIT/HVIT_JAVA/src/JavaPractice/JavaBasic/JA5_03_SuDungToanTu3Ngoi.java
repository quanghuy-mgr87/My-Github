package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA5_03_SuDungToanTu3Ngoi {
    public static void main(String[] args) {
        String quyen = "";
        Scanner sc = new Scanner(System.in);
        int age;
        System.out.printf("Nhap tuoi: ");
        age = sc.nextInt();
        System.out.println(quyen = age > 18 ? "Duoc quyen truy cap" : "Ban khong du tuoi");
    }
}
