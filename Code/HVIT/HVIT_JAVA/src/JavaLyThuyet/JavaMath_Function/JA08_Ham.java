package JavaLyThuyet.JavaMath_Function;

public class JA08_Ham {
    static void InChu() {
        System.out.println("Hello");
    }

    static void InChu(int a, int b) {
        if (a > b) System.out.println("Hello");
        else System.out.println("1111111111111111");
    }

    static void InChu(double a, double b) {
        if (a > b) System.out.println("Hello");
        else System.out.println("222222222222");
    }

    public static void main(String[] args) {
        InChu();
        InChu(2, 3);
        InChu(2.2, 1.1);
    }
}
