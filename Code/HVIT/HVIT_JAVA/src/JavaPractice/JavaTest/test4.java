package JavaPractice.JavaTest;

import java.time.LocalDate;
import java.util.*;
import java.util.stream.Collectors;

public class test4 {
    public static void main(String[] args) {
        HashMap<String,String> capital=new HashMap<>();
        capital.put("VietNam", "HaNoi");
        capital.put("USA", "W.DC");
        capital.put("Korea", "Seoul");
        capital.put("Laos", "Lao");
        Iterator<HashMap.Entry<String, String>> iter = capital.entrySet().iterator();
        while (iter.hasNext()) {
            System.out.println(iter.next());
        }
    }
}
