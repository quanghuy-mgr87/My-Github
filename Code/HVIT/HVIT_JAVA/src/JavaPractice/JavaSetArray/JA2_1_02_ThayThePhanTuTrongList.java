package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class JA2_1_02_ThayThePhanTuTrongList {
    public static void main(String[] args) {
        String[] arrStr = {"Toan", "Ly", "Hoa", "Van", "Anh", "Toan Cao Cap", "Sinh Hoa"};
        List<String> lstStr = new ArrayList<>();
        Collections.addAll(lstStr, arrStr);
        System.out.println(lstStr);
        Collections.replaceAll(lstStr, "Toan", "Test");
        System.out.println(lstStr);
    }
}
