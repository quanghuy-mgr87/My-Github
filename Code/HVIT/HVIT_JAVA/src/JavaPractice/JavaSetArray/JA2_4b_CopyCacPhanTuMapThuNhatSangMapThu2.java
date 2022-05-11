package JavaPractice.JavaSetArray;

import java.util.HashMap;
import java.util.Map;

public class JA2_4b_CopyCacPhanTuMapThuNhatSangMapThu2 {
    public static void main(String[] args) {
        Map<Integer, Integer> map = new HashMap<>();
        map.put(1, 1);
        map.put(2, 2);
        map.put(3, 3);
        map.put(4, 4);
        map.put(5, 5);
        map.put(6, 6);
        System.out.println(map);

        Map<Integer, Integer> map2 = new HashMap<>();
        map2.put(7, 7);
        map2.putAll(map);
        System.out.println(map2);
    }
}
