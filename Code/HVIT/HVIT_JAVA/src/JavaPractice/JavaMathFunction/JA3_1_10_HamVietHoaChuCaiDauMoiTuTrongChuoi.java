package JavaPractice.JavaMathFunction;

public class JA3_1_10_HamVietHoaChuCaiDauMoiTuTrongChuoi {
    static String ChuanHoaChuoi(String str) {
        String name = "";
        str = str.toLowerCase().trim();
        while (str.contains("  ")) {
            str = str.replace("  ", " ");
        }
        String[] arrStr = str.split(" ");
        for (int i = 0; i < arrStr.length; i++) {
            name += arrStr[i].substring(0, 1).toUpperCase() + arrStr[i].substring(1) + " ";
        }
        return name;
    }

    public static void main(String[] args) {
        String name = "Nguyen van    toan   ";
        name = ChuanHoaChuoi(name);
        System.out.println("Ten sau khi chuan hoa: " + name);
    }
}
