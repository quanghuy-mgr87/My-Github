package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.List;

public class JA2_1d_BienDoi1CollectionThanhArray {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>();
        lstInt.add(11);
        lstInt.add(12);
        lstInt.add(13);
        lstInt.add(14);

        Integer[] arrInt = lstInt.toArray(new Integer[0]);
        for (int i = 0; i < arrInt.length; i++) {
            System.out.println(arrInt[i]);
        }
    }
}
