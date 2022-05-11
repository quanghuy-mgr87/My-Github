package JavaPractice.JavaSetArray;

import java.util.*;

public class JA2_2_11_LietKeSoLanXuatHienCuaCacPhanTu {
    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 2, 1, 3, 3, 4, 3, 5, 5));
        Map<Integer, Integer> map = new TreeMap<>();
        for (int i = 0; i < lstInt.size(); i++) {
            // kiem tra xem map da co phan tu nao co key la lstInt.get(i) chua
            if (map.containsKey(lstInt.get(i))) {
                // lstInt.get(i) la lay ra gia tri cua phan tu thu i trong list
                // neu co thi lay value cua key do dem + them 1, sau do put vao map
                int count = map.get(lstInt.get(i)) + 1;
                map.put(lstInt.get(i), count);
            } else {
                // neu ko co thi put phan tu vao voi key la lstInt.get(i) va value la 1
                map.put(lstInt.get(i), 1);
            }
        }
        for (Integer val : map.keySet()) {
            System.out.println(val + " - " + map.get(val));
        }
    }
}
