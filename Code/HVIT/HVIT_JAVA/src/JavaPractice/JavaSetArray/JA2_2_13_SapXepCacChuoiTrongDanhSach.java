package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_2_13_SapXepCacChuoiTrongDanhSach {
    public static void main(String[] args) {
        List<String> lstStr = new ArrayList<>(Arrays.asList("Cam", "Quyt", "Mit", "Dua", "Dua", "Le", "Tao", "Oi"));
        Collections.sort(lstStr);
        System.out.println(lstStr);
    }
}
