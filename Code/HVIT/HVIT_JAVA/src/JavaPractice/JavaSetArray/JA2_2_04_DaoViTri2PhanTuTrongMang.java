package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class JA2_2_04_DaoViTri2PhanTuTrongMang {
    public static void main(String[] args) {
        Integer[] arrInt = {1, 4, 7, 8, 9, 6, 3, 2, 5};
        List<Integer> lstInt = new ArrayList<>();
        Collections.addAll(lstInt, arrInt);
        Collections.swap(lstInt, 0, 2);
        System.out.println(lstInt);
    }
}
