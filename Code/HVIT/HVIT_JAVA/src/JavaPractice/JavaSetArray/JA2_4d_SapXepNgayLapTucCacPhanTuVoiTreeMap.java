package JavaPractice.JavaSetArray;

import java.util.Map;
import java.util.TreeMap;

public class JA2_4d_SapXepNgayLapTucCacPhanTuVoiTreeMap {
    public static void main(String[] args) {
        Map<Integer, Integer> treeMap = new TreeMap();
        treeMap.put(1, 1);
        treeMap.put(3, 3);
        treeMap.put(2, 2);
        treeMap.put(6, 6);
        treeMap.put(5, 5);
        treeMap.put(4, 4);
        for (Map.Entry x : treeMap.entrySet()) {
            System.out.println(x.getKey() + " " + x.getValue());
        }
    }
}
