package JavaPractice.JavaBasic;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class JA2_2_09_ChiaMangChanLe {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>();
        int num;
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap so luong phan tu mang: ");
        num = sc.nextInt();
        for (int i = 0; i < num; i++) {
            System.out.printf("lstInt[" + i + "] = ");
            lstInt.add(sc.nextInt());
        }
        System.out.println("Mang vua nhap: " + lstInt);
        List<Integer> lstChan = new ArrayList<>();
        List<Integer> lstLe = new ArrayList<>();
        for (Integer val : lstInt) {
            if (val % 2 == 0) {
                lstChan.add(val);
            } else {
                lstLe.add(val);
            }
        }
        lstInt = new ArrayList<>();
        lstInt.addAll(lstChan);
        lstInt.addAll(lstLe);
        System.out.println("Mang sau khi tach: " + lstInt);
    }
}
