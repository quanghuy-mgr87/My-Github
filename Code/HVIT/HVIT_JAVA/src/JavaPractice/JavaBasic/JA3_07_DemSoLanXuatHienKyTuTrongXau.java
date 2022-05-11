package JavaPractice.JavaBasic;

public class JA3_07_DemSoLanXuatHienKyTuTrongXau {
    public static void main(String[] args) {
        String str = "Chao mung cac ban den voi Hvit Clan";
        Character c = 'a';
        int dem = 0;

        char[] arr = str.toCharArray();
        for (char c1 : arr) {
            if (c1 == c) {
                dem++;
            }
        }

        System.out.println("Chuoi \"" + str + "\" co " + dem + " ki tu a");
    }
}
