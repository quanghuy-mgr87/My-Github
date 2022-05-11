package JavaPractice.JavaSetArray;

import java.util.HashSet;
import java.util.Set;

public class JA2_3_04_XoaPhanTuTrongSet {
    public static void main(String[] args) {
        Set<Integer> set1 = new HashSet<>();
        Set<Integer> set2 = new HashSet<>();
        set1.add(1);
        set1.add(2);
        set1.add(3);

        set2.add(4);
        set2.add(5);
        set2.add(6);
        set2.add(1);
        set2.add(2);
        set2.add(3);

        set1.remove(1);
        set2.removeAll(set1);

        System.out.println(set1);
        System.out.println(set2);

        set2.clear();
        System.out.println(set2);
    }
}
