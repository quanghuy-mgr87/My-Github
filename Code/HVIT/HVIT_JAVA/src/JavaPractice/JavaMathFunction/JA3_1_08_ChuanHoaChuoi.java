package JavaPractice.JavaMathFunction;

public class JA3_1_08_ChuanHoaChuoi {
    static String ChuanHoaChuoi(String str) {
        str = str.trim();
        while (str.contains("  ")) {
            str = str.replace("  ", " ");
        }
        return str;
    }

    public static void main(String[] args) {
        String str = "Nguyen van   a   ";
        str = ChuanHoaChuoi(str);
        System.out.println(str);
    }
}
