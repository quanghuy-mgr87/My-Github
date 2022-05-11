package JavaPractice.JavaBasic;

import java.util.Scanner;

public class JA6_09_KiemTra1ThangCoBaoNhieuNgay {
    public static Boolean KiemTraNamNhuan(int year) {
        if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
            return true;
        return false;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int month, year;
        System.out.printf("Nhap vao thang: ");
        month = sc.nextInt();
        System.out.printf("Nhap vao nam: ");
        year = sc.nextInt();
        switch (month) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12: {
                System.out.println("Thang co 31 ngay.");
            }
            break;
            case 2: {
                if (KiemTraNamNhuan(year)) {
                    System.out.println("Thang co 29 ngay.");
                } else {
                    System.out.println("Thang co 28 ngay.");
                }
            }
            break;
            case 4:
            case 6:
            case 9:
            case 11: {
                System.out.println("Thang co 30 ngay.");
            }
            break;
            default:
                System.out.println("Invalid");
        }

    }
}
