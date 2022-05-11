package JavaPractice.JavaBasic;

import java.time.DayOfWeek;
import java.time.Month;
import java.time.YearMonth;
import java.util.Calendar;
import java.util.Scanner;

public class JA5_01_Nhap1SoVaInRaThangTuongUng {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num;
        System.out.printf("Nhap so: ");
        num = sc.nextInt();
        switch (num) {
            case 1: {
                System.out.println(Month.JANUARY);
            }
            break;
            case 2: {
                System.out.println(Month.FEBRUARY);
            }
            break;
            case 3: {
                System.out.println(Month.MARCH);
            }
            break;
            case 4: {
                System.out.println(Month.APRIL);
            }
            break;
            case 5: {
                System.out.println(Month.MAY);
            }
            break;
            case 6: {
                System.out.println(Month.JUNE);
            }
            break;
            case 7: {
                System.out.println(Month.JULY);
            }
            break;
            case 8: {
                System.out.println(Month.AUGUST);
            }
            break;
            case 9: {
                System.out.println(Month.SEPTEMBER);
            }
            break;
            case 10: {
                System.out.println(Month.OCTOBER);
            }
            break;
            case 11: {
                System.out.println(Month.NOVEMBER);
            }
            break;
            case 12: {
                System.out.println(Month.DECEMBER);
            }
            break;

            default: {
                System.out.println("Invalid!");
            }
        }
    }
}
