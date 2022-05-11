package JavaLyThuyet.JavaSet_Array;

import java.util.*;

public class JA09_Collection_Map {
    public static void main(String[] args) {
        //  Map la tap cac cap gia tri, cac gia tri cua phan tu co the giong nhau nhung khoa khong the giong nhau dc
        //  Moi phan tu gom 2 phan, key la Integer, gia tri la String
        Map<Integer, String> hashMap = new HashMap<>();
        Map<Integer, String> linkedMap = new LinkedHashMap<>();
        Map<Integer, String> treeMap = new TreeMap<>();

        hashMap.put(1, "one");
        hashMap.put(2, "two");
        hashMap.put(3, "three");
        linkedMap.put(1, "one");
        linkedMap.put(2, "two");
        linkedMap.put(3, "three");
        treeMap.put(1, "one");
        treeMap.put(2, "two");
        treeMap.put(3, "three");

        System.out.println("Hash map: " + hashMap);
        System.out.println("Linked map: " + linkedMap);
        System.out.println("Tree map: " + treeMap);


        //Lay gia tri cua Map
        Set<Map.Entry<Integer, String>> setNew = treeMap.entrySet();
        System.out.println(setNew);
        //Lay key cua Map
        for (Integer key : treeMap.keySet()) {
            System.out.println(key);
        }
        //Lay value
        for (String value : treeMap.values()) {
            System.out.println(value);
        }

        //Lay toan bo cac gia tri entry cua map thong qua Iterator *Chua lam dc

        //Tim gia tri khi biet key
        System.out.println(treeMap.get(1));
        //Xoa 1 phan tu nao do
        treeMap.remove(1);
        System.out.println(treeMap);

        treeMap.replace(2, "two", "hai");
        System.out.println(treeMap);
    }
}
