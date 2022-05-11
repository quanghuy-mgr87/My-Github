package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_2b_XaoTronMang {
    public static void main(String[] args) {
        Integer[] arr = {1, 4, 7, 8, 9, 6, 3, 2, 5};
        List<Integer> lstInt = new ArrayList<>();
        Collections.addAll(lstInt, arr);
        Collections.shuffle(lstInt);
        System.out.println(lstInt);

//        ArrayList<String> animals = new ArrayList<>(Arrays.asList("Cat", "Cow", "Dog"));

    }
}
