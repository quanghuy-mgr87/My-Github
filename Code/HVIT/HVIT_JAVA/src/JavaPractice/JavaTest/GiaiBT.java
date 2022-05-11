package JavaPractice.JavaTest;

import java.util.*;
import java.util.stream.Collectors;

public class GiaiBT {
    public static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        List<String> list = new ArrayList<>();
        list.add("Muoi");
        list.add("Chin");
        list.add("ConVoi");
        list.add("KhungLong");
        list.add("Nguoi");
        list.add("Taisaolaithe");
        int n = 6;

        InDanhSach(VietHoaDenN(list));
        System.out.println();
    }

    public static List<String> VietHoaDenN(List<String> list) { /// Ham viet hoa den n
        int n = list.size();
        for (int i = 0; i < n; i++) {
            list.set(i, list.get(i).length() <= n ? list.get(i).toUpperCase() : list.get(i).substring(0, n).toUpperCase() + list.get(i).substring(n));
        }
        return list;
    }

    public static void InDanhSach(List<String> list) { /// Ham in danh sach
        list.forEach(x -> System.out.print(x + ", "));
    }
}
