package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class JA2_2_10_InPhanTuBangCachSuDungViTriPhanTu {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 4, 7, 8, 9, 6, 3, 2, 5));
        System.out.println(lstInt);
        for (int i = 0; i < lstInt.size(); i++) {
            System.out.println(i + " - " + lstInt.get(i));
        }
    }
}
