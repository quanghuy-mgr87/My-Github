package JavaPractice.JavaMathFunction;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA3_1_09_InMotDSDaoNguocCua1DSTruyenVao {
    static void DaoNguocChuoi(List<String> lstStr) {
        Collections.reverse(lstStr);
    }

    public static void main(String[] args) {
        List<String> lstStr = new ArrayList<>(Arrays.asList("Nguyen Duc Toan", "Nguyen Hoang Truong", "Nguyen Dong Khanh"));
        System.out.println("List ban dau:");
        lstStr.forEach(x -> System.out.println(x));
        System.out.println("------------------------");
        DaoNguocChuoi(lstStr);
        System.out.println("List dao nguoc:");
        lstStr.forEach(x -> System.out.println(x + " "));
    }
}
