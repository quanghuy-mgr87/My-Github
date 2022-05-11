package JavaPractice.JavaBasic;

public class JA3_09_NhapSDT_InRaMaQG_Vung {
    public static void main(String[] args) {
        String PhoneNumber = "(+84) 039-6758080";
        String MaQG = "", MaVung = "", SDT = "";
        String ArrStr[] = PhoneNumber.split(" ");
        MaQG = ArrStr[0].substring(1, ArrStr[0].length() - 1);

        String ArrStr2[] = ArrStr[1].split("-");
        MaVung = ArrStr2[0];
        SDT = ArrStr2[1];

        System.out.println("mã Quốc gia (" + MaQG + "), mã vùng (" + MaVung + ") và số điện thoại (" + SDT + ")");
    }
}
