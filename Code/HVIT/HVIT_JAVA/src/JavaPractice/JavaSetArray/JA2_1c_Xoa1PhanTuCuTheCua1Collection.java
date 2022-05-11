package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.List;

public class JA2_1c_Xoa1PhanTuCuTheCua1Collection {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>();
        lstInt.add(11);
        lstInt.add(12);
        lstInt.add(13);
        System.out.println(lstInt);
        lstInt.remove(1);
        System.out.println(lstInt);
    }
}
