package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

public class JA2_1_05_DuyetMangBangIterator {
    public static void main(String[] args) {
        String[] arrStr = {"Toan", "Ly", "Hoa", "Van", "Anh", "Toan Cao Cap", "Sinh Hoa"};
        List<String> lstStr = new ArrayList<>();
        Collections.addAll(lstStr, arrStr);
        Iterator itr = lstStr.iterator();
        while (itr.hasNext()) {
            Object val = itr.next();
            System.out.println(val);
        }
    }
}
