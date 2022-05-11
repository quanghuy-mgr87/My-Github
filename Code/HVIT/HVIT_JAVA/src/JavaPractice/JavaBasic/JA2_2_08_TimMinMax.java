package JavaPractice.JavaBasic;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_2_08_TimMinMax {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 4, 7, 8, 9, 6, 3, 2, 5));
        Integer max = Collections.max(lstInt);
        Integer min = Collections.min(lstInt);
        System.out.println("GTLN: " + max + ", GTNN: " + min);
    }
}
