package JavaPractice.JavaMathFunction;

public class JA3_F18_TimPhanTuChanTrongMang {
    static int TimPhanTuChanDauTienTrongMang(int[] arr) {
        int ret = 0;
        for (int i : arr) {
            if (i % 2 == 0) {
                ret = i;
                break;
            }
        }
        return ret;
    }

    public static void main(String[] args) {
        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int num = TimPhanTuChanDauTienTrongMang(arr);
        System.out.println("Phan tu chan dau tien trong mang la: " + num);
    }
}
