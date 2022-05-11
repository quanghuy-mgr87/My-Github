package JavaPractice.JavaSetArray;

import java.util.*;

public class JA2_1_10_DuyetNguocBangIterator {
    public static void main(String[] args) {
        //https://hajsoftutorial.com/listiterator-hasnext-next-hasprevious-and-previous/#:~:text=A%20list%20iterator%20gives%20you,method%20Returns%20the%20previous%20element.
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 4, 7, 8, 9, 6, 3, 2, 5));
        System.out.println(lstInt);
        ListIterator<Integer> lstItr = lstInt.listIterator();
        // list iterator duyet tu dau den cuoi xong moi duyet tu cuoi len dau
        while (lstItr.hasNext()) {
            System.out.printf(lstItr.next() + " ");
        }
        System.out.println();
        while (lstItr.hasPrevious()) {
            System.out.printf(lstItr.previous() + " ");
        }
    }
}
