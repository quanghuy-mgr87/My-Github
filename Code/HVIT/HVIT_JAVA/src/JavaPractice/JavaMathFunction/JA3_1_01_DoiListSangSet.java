package JavaPractice.JavaMathFunction;

import java.util.*;

public class JA3_1_01_DoiListSangSet {
    static Set<Integer> ChuyenListSangSet(List<Integer> lstInt) {
        Set<Integer> set = new HashSet<>();
        set.addAll(lstInt);
        return set;
    }

    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 4, 7, 8, 9, 6, 3, 2, 5));
        Set<Integer> set = ChuyenListSangSet(lstInt);
        set.stream().forEach(x -> System.out.printf(x + " "));
    }
}
