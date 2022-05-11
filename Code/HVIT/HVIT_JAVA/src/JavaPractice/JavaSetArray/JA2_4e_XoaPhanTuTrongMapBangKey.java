package JavaPractice.JavaSetArray;

import java.util.Map;
import java.util.TreeMap;

public class JA2_4e_XoaPhanTuTrongMapBangKey {
    public static void main(String[] args) {
        Map<Integer, String> map = new TreeMap<>();
        map.put(1, "Hvit");
        map.put(2, "Clan");
        map.put(3, "Chua");
        map.put(4, "Ha");
        System.out.println(map);
        map.remove(2);
        System.out.println(map);
    }
}
