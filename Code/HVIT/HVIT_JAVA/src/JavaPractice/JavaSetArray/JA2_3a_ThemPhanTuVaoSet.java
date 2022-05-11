package JavaPractice.JavaSetArray;

import java.util.HashSet;
import java.util.Set;

public class JA2_3a_ThemPhanTuVaoSet {
    public static void main(String[] args) {
        Set<Integer> set = new HashSet<>();
        set.add(1);
        set.add(2);
        set.add(2);
        set.add(3);
        set.add(3);

        System.out.println(set);
    }
}
