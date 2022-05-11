package JavaPractice.JavaMathFunction;

import java.util.Scanner;

public class JA3_1_06_HamDemKhoangTrang {
    static int DemKhoangTrang(String str) {
        int dem = 0;
        char[] arr = str.toCharArray();
        for (char c : arr) {
            if (c == ' ') {
                dem++;
            }
        }
        return dem;
    }

    public static void main(String[] args) {
        String str = "";
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap chuoi: ");
        str = sc.nextLine();
        System.out.println("Chuoi vua nhap co " + DemKhoangTrang(str) + " khoang trang.");
    }
}
