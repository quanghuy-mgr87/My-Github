package JavaPractice.JavaSetArray;

import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

public class JA2_3_05_TimTapHopGiaoCua2TapHop {
    public static void main(String[] args) {
        Integer[] arrInt1 = {1, 2, 5, 0, 6, 7};
        Integer[] arrInt2 = {0, 9, 7, 5, 3, 8};

        Set<Integer> set1 = new HashSet<>();
        Collections.addAll(set1, arrInt1);
        Set<Integer> set2 = new HashSet<>();
        Collections.addAll(set2, arrInt2);

        Set<Integer> temp = new HashSet<>(set1);
        temp.retainAll(set2);
        System.out.println(temp);
    }
}
