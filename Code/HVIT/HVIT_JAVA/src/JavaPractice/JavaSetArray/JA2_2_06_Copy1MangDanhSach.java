package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_2_06_Copy1MangDanhSach {
    public static void main(String[] args) {
        List<String> lstNum = new ArrayList<>(Arrays.asList("1", "2", "3", "4"));
        List<String> lstStr = new ArrayList<>(Arrays.asList("A", "B", "C", "D"));
        Collections.copy(lstNum, lstStr);
        System.out.println(lstNum);
    }
}
