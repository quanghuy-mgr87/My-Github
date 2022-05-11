package JavaPractice.JavaBasic;

import org.w3c.dom.TypeInfo;

import java.util.Scanner;

public class JA6_10_KiemTra1SoCoCacChuSoTangDanHayKhong {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int num;
        do {
            System.out.printf("Nhap so co it nhat 2 chu so: ");
            num = sc.nextInt();
        } while (num < 10);

        //y tuong la chuyen sang mang ki tu, sau do kiem tra day tang
        Boolean check = true;
        String str = Integer.toString(num);
        char charArr[] = str.toCharArray();
        for (int i = 0; i < charArr.length - 1; i++) {
            //Integer.parstInt chi nhan tring trong ngoac, nen phai doi tu char sang string
            if (Integer.parseInt(String.valueOf(charArr[i])) > Integer.parseInt(String.valueOf(charArr[i + 1]))) {
                check = false;
                break;
            }
        }
        if (check) {
            System.out.println(num + " la day tang.");
        } else {
            System.out.println(num + " khong la day tang.");
        }
    }
}
