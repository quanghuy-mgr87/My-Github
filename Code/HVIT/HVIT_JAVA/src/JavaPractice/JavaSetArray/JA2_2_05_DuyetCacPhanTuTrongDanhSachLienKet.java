package JavaPractice.JavaSetArray;

import java.util.*;

public class JA2_2_05_DuyetCacPhanTuTrongDanhSachLienKet {
    public static void main(String[] args) {
        Integer[] arrInt = {1, 4, 7, 8, 9, 6, 3, 2, 5};
        LinkedList<Integer> linkedList = new LinkedList<>();
        Collections.addAll(linkedList, arrInt);
        for (int i = 0; i < linkedList.size(); i++) {
            System.out.println(linkedList.get(i));
        }
        System.out.println();
        Iterator itr = linkedList.iterator();
        while (itr.hasNext()) {
            System.out.println(itr.next());
        }
    }
}
