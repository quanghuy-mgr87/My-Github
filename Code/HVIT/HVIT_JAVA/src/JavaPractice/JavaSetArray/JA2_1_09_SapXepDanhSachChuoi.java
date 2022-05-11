package JavaPractice.JavaSetArray;

import java.text.CollationElementIterator;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_1_09_SapXepDanhSachChuoi {
    public static void main(String[] args) {
        List<String> lstStr = new ArrayList<>(Arrays.asList("Cam", "Quyt", "Mit", "Dua", "Dua", "Le", "Tao", "Oi"));
        Collections.sort(lstStr);
        System.out.println(lstStr);
    }
}
