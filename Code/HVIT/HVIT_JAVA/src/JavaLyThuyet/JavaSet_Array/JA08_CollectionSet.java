package JavaLyThuyet.JavaSet_Array;

import java.util.*;
import java.util.stream.Collectors;

public class JA08_CollectionSet {

    public static void main(String[] args) {
        List<Integer> lstInt = new ArrayList<>();
        lstInt.add(12);
        lstInt.add(33);
        lstInt.add(33);

        //List co the in ra cac phan tu trung nhau nhung Set lai ko in cac phan tu trung nhau
        Set<Integer> treeSetNew = new TreeSet<>(lstInt);
        System.out.println("Tree set new: " + treeSetNew);

        Set<Integer> hashsetInt = new HashSet<>();
        hashsetInt.add(12);
        hashsetInt.add(14);
        hashsetInt.add(44);
        hashsetInt.add(66);
        hashsetInt.add(23);

        Set<Integer> treesetInt = new TreeSet<>();
        treesetInt.add(32);
        treesetInt.add(62);
        treesetInt.add(22);

        System.out.println("Hash set: ");
        System.out.println(hashsetInt);
        System.out.println("Tree set: ");
        System.out.println(treesetInt);

        System.out.println("Tree set chan:");
        List<Integer> lstIntNew = new ArrayList<>();
        lstIntNew.add(12);
        lstIntNew.add(24);
        lstIntNew.add(25);

        Set<Integer> treesetChan = lstIntNew.stream().filter(num -> num % 2 == 0).collect(Collectors.toSet());
        System.out.println(treesetChan);


        ///////////////////////////////////////////////////////

        Integer[] arr1 = {2, 3, 4, 5, 6, 10};
        Integer[] arr2 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

        List<Integer> lst1 = Arrays.asList(arr1);
        List<Integer> lst2 = Arrays.asList(arr2);

        Set<Integer> set1 = new HashSet<>(lst1);
        Set<Integer> set2 = new HashSet<>(lst2);

        //Toan tu chứa
        if (set2.containsAll(set1)) {
            System.out.println("set1 chua set2");
        } else {
            System.out.println("s1 ko chua s2");
        }

        //Toán tử giao
        set1.retainAll(set2);
        System.out.println(set1);

        //Toán tử hợp
        set1.addAll(set2);
        System.out.println(set1);

        set1 = new HashSet<>(lst1);
        set2 = new HashSet<>(lst2);
        //Xoá những cái có chung của 2 cái
        set2.removeAll(set1);
        System.out.println(set2);
    }
}
