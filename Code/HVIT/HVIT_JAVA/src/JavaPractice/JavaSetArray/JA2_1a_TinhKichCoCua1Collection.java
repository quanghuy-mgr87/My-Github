package JavaPractice.JavaSetArray;

import java.util.*;

public class JA2_1a_TinhKichCoCua1Collection {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>();
        lstInt.add(11);
        lstInt.add(12);
        lstInt.add(13);
        lstInt.add(14);
        System.out.println(lstInt.size());

        //Thay the phan tu trong list
        lstInt.set(1, 13);
        System.out.println(lstInt);
        lstInt.replaceAll(x -> x + 1);
        System.out.println(lstInt);

        Set<Integer> set1 = new HashSet<>();
        set1.add(11);
        set1.add(11);
        set1.add(12);
        set1.add(12);
        set1.add(13);
        System.out.println(set1.size());
    }
}
