package JavaPractice.JavaSetArray;

import java.util.HashSet;
import java.util.Set;

public class JA2_3c_KiemTraSetRongHayCoPhanTu {
    public static void main(String[] args) {
        Set<Integer> set = new HashSet<>();
        set.add(1);
        if (set.stream().count() != 0) {
            System.out.println("set co phan tu");
        } else {
            System.out.println("set rong");
        }
    }
}
