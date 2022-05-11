package JavaLyThuyet.JavaSet_Array;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA07_Array_Collection {
    public static void main(String[] args) {
        //sap xep
        int[] arrInt = new int[]{1, 2, 3, 1, 5, 67, 1, 2, 5, 66, 7, 2};
        Arrays.sort(arrInt);
        for (int i : arrInt) {
            System.out.println(i);
        }
        System.out.println();
        List<Integer> lstNum = new ArrayList<>();
        lstNum.add(1);
        for (Integer val : lstNum) {
            System.out.println(val);
        }

        System.out.println();
        //Giong toList() trong C#
        List<String> lstStr = Arrays.asList("as", "fd", "qw");
        for (String s : lstStr) {
            System.out.println(s);
        }

        System.out.println();

        ArrayList<Integer> values = new ArrayList<>();
        Integer[] array = {10, 20, 30};

        // Add all elements in array to ArrayList.
        Collections.addAll(values, array);

        // Display.
        for (int value : values) {
            System.out.print(value);
            System.out.print(" ");
        }
        System.out.println();

        // Add more elements.
        Collections.addAll(values, 40, 50);

        // Display.
        for (int value : values) {
            System.out.print(value);
            System.out.print(" ");
        }

        System.out.println();
        //Mang 2 chieu
        int[][] arr = new int[2][3];
        int[][] arr1 = new int[2][];    //khai bao ma tran co 2 dong
        int[][] arr3 = new int[][]{
                {1, 2, 3},
                {4, 5, 6}
        };

    }
}
