package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class JA2_4a_DuyetMapBangIterator {
    public static void main(String[] args) {
        Map<Integer, Integer> map = new HashMap<>();
        map.put(1, 1);
        map.put(2, 2);
        map.put(3, 3);
        map.put(4, 4);
        map.put(5, 5);

        // Use iterator to display contents of al
        System.out.print("Original contents of al: ");
        Iterator itr = map.values().iterator();
        Iterator itr1 = map.entrySet().iterator();
        Iterator itr2 = map.keySet().iterator();
        while (itr.hasNext()) {
            Object element = itr.next();
            System.out.print(element + " ");
        }
    }
}
