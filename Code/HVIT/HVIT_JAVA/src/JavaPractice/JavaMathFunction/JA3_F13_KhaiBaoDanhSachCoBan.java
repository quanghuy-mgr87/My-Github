package JavaPractice.JavaMathFunction;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class JA3_F13_KhaiBaoDanhSachCoBan {
    static void HienThiDSChuoi(List<String> lstStr) {
        System.out.println("Danh sach chuoi:");
        lstStr.forEach(x -> System.out.printf(x + " "));
    }

    public static void main(String[] args) {
        List<String> lstStr = new ArrayList<>(Arrays.asList("Chuoi", "Chuoi1", "Chuoi2", "Chuoi3", "Chuoi4"));
        HienThiDSChuoi(lstStr);
    }
}
