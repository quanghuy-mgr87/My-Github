package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class JA2_2a_XoaPhanTuThu3TrongList {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        List<Integer> lstInt = new ArrayList<>();
        lstInt.add(1);
        lstInt.add(2);
        lstInt.add(3);
        lstInt.add(4);
        lstInt.add(5);
        System.out.println(lstInt);

        int pos;
        System.out.printf("Nhap vi tri can xoa: ");
        pos = sc.nextInt();

        for (int i = 0; i < lstInt.stream().count(); i++) {

        }

//        lstInt.remove(pos);

        System.out.println(lstInt);
    }
}
