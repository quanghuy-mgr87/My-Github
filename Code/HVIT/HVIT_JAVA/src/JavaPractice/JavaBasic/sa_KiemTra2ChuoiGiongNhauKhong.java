package JavaPractice.JavaBasic;

import java.util.Scanner;

public class sa_KiemTra2ChuoiGiongNhauKhong {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String str1, str2;
        System.out.printf("Nhap chuoi 1: ");

        //nextLine() tra lai noi dung cua 1 hang (cho phep nhap chuoi co dau cach)
        //next() chi tra lai noi dung truoc khoang trang
        str1 = sc.nextLine();
        System.out.printf("Nhap chuoi 2: ");
        str2 = sc.nextLine();
        System.out.println("2 chuoi vua nhap: " + str1 + ", " + str2);
        if (str1 == str2) {
            System.out.println("2 chuoi giong nhau");
        } else {
            System.out.println("2 chuoi khac nhau");
        }
    }
}
