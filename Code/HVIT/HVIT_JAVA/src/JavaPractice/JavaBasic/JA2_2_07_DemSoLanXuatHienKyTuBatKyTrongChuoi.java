package JavaPractice.JavaBasic;

public class JA2_2_07_DemSoLanXuatHienKyTuBatKyTrongChuoi {
    public static void main(String[] args) {
        String str = "Hvit Clan number one";
        char ch = 'e';
        int dem = 0;
        char[] arrCh = str.toCharArray();
        for (char c : arrCh) {
            if (c == ch)
                dem++;
        }
        System.out.println("Ky tu " + ch + " xuat hien " + dem + " lan");
    }
}
