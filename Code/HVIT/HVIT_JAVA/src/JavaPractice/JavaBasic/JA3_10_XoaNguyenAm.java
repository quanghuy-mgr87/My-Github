package JavaPractice.JavaBasic;

public class JA3_10_XoaNguyenAm {
    public static void main(String[] args) {
        String str = "HVIT Clan";
        char nguyenAm[] = {'a', 'e', 'i', 'o', 'u'};
        for (char c : nguyenAm) {
            if (str.contains(String.valueOf(c))) {
                str = str.replace(String.valueOf(c), "");
            }
            if (str.contains(String.valueOf(c).toUpperCase())) {
                str = str.replace(String.valueOf(c).toUpperCase(), "");
            }
        }
        System.out.println(str);
    }
}
