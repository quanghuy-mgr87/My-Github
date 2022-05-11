package JavaLyThuyet.JavaBasic;

import java.util.Scanner;

public class JA_05_DieuKien {
    public static void main(String[] args) {
        int a = 3, b = 6;
        if (a > b) {
            System.out.println("hihi");
        } else {
            System.out.println("huhu");
        }

        //Scanner de lay du lieu nhap vao tu ban phim
        Scanner sc = new Scanner(System.in);
        //Chuyen doi du lieu nhap vao tu ban phim sang kieu int
        int c = sc.nextInt();
        if (c % 2 == 0) {
            System.out.println(c + " la so chan");
        } else {
            System.out.println(c + " la so le");
        }
    }
}
