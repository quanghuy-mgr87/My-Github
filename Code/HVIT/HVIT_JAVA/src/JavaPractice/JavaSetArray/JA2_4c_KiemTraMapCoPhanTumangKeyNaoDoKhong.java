package JavaPractice.JavaSetArray;

import java.util.HashSet;
import java.util.Set;

public class JA2_4c_KiemTraMapCoPhanTumangKeyNaoDoKhong {
    public static void main(String[] args) {
        Set<Integer> set1 = new HashSet<>();
        set1.add(1);
        set1.add(2);
        set1.add(3);
        set1.add(4);
        set1.add(7);

        Set<Integer> set2 = new HashSet<>();
        set2.add(1);
        set2.add(2);
        set2.add(3);
        set2.add(4);
        set2.add(5);
        set2.add(6);

        boolean check = true;
        for (Integer val : set1) {
            if (!set2.contains(val))
                check = false;
        }

        System.out.println(check);

        System.out.println(set2.containsAll(set1));
    }
}
