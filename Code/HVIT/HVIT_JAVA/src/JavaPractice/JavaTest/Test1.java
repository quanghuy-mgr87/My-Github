package JavaPractice.JavaTest;

import java.lang.reflect.Array;
import java.util.Scanner;

public class Test1 {
    public static Boolean KiemTraXau(String str) {
        char[] arr = str.toCharArray();
        for (char c : arr) {
            if (!Character.isLetterOrDigit(c))
                return false;
        }
        return true;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String s1 = "", s = "";
        do {
            System.out.printf("Nhap xau ki tu: ");
            s1 = sc.next();
        } while (s1.length() < 1 || s1.length() > 255 || !KiemTraXau(s1));
        char[] arr = s1.toCharArray();
        for (int i = 0; i < arr.length; i++) {
            if (Character.isDigit(arr[i]) && i < arr.length - 1) {
                for (int j = 0; j < Integer.parseInt(String.valueOf(arr[i])); j++) {
                    s += arr[i + 1];
                }
                i++;
            } else {
                s += arr[i];
            }
        }
        System.out.println("adu: " + s);
    }
}
