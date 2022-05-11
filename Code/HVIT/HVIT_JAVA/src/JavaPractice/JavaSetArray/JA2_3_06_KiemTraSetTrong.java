package JavaPractice.JavaSetArray;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class JA2_3_06_KiemTraSetTrong {
    public static void main(String[] args) {
        Set<Integer> setInt = new HashSet<>(Arrays.asList(1, 2, 1, 3, 3, 4, 3, 5, 5));
        if (setInt.stream().count() != 0) {
            System.out.println("Set khac rong");
        } else {
            System.out.println("Set rong");
        }
    }
}
