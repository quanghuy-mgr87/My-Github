package JavaPractice.JavaSetArray;

import java.util.Arrays;
import java.util.Map;
import java.util.TreeMap;

public class JA2_4_06_LietKeCacPhanTuXuatHienDung1Lan {
    public static void main(String[] args) {
        Integer[] a = {1, 1, 2, 5, 1};
        Map<Integer, Integer> map = new TreeMap<>();
        for (int i = 0; i < a.length; i++) {    //duyet mang
            if (map.containsKey(a[i])) {    //neu map co chua key nay roi
                int count = map.get(a[i]) + 1;  //lay gia tri cua phan tu co key nay dem + them 1
                //map.get() su dung de tra gia tri cho khoa duoc chi dinh
                map.put(a[i], count);   //put phan tu vao map theo dang key:a[i], value: count
            } else {
                map.put(a[i], 1);   //put phan tu vao map theo dang key:a[i], value: 1
            }
        }
        System.out.println("Cac phan tu xuat hien dung 1 lan:");
        for (Integer val : map.keySet()) {
            if (map.get(val) == 1) {
                System.out.printf(val + " ");
            }
        }
    }
}
