package JavaPractice.JavaTest;
import java.util.*;
import java.util.concurrent.TimeUnit;


public class Test2 {
    static char[] sapXepMang(int n) {
        String str = Integer.toString(n);
        char[] arr = str.toCharArray();
        Arrays.sort(arr);
        return arr;
    }

    static int sapXepSo(char[] arr) {
        if (arr[0] == '0') {
            for (int i = 1; i < arr.length; i++) {
                if (arr[i] != '0') {
                    arr[0] = arr[i];
                    arr[i] = '0';
                    break;
                }
            }
        }
        int num = 0;
        for (int i = 0; i < arr.length; i++) {
            num += (arr[i] - '0') * Math.pow(10, (arr.length) - i - 1);
        }
        return num;
    }

//		List<Integer> numbers = new LinkedList<>();
//		for (int i = n; i > 0; i /= 10) {
//			numbers.add(i % 10);
//		}
//		Collections.sort(numbers);
//		Integer[] arr = numbers.toArray(new Integer[numbers.size()]);
//
//	}

    public static void main(String[] args) {
        int n = 120345;
        System.out.println(sapXepSo(sapXepMang(n)));

    }
}
