package JavaPractice.JavaSetArray;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class JA2_2_12_TinhTongPhanTuTrongDanhSach {
    public static void main(String[] args) {
        Integer sum = 0;
        List<Integer> lstInt = new ArrayList<>(Arrays.asList(1, 4, 7, 8, 9, 6, 3, 2, 5));
        sum = lstInt.stream().reduce(0, (a, b) -> a + b);
        // - Tham số đầu tiên, số interger = 0 là identity, nó là giá ban đầu của reduction operation.
        // Mặt khác nó cũng là giá trị mặc định khi Stream rỗng.
        // - Tham số thứ 2 là một lambda expression triển khai BiFunction functional interface tương ứng với accumulator,
        // nó sẽ lấy tổng của các phần tử trước đó cộng với phần tử tiếp theo cho đến phần tử cuối cùng của Stream.
        System.out.println("Tong la: " + sum);
    }

}
