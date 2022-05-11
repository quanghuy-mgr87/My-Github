package JavaPractice.JavaBasic;

public class JA3_08_DemChuCai_So_TuTrongCau {
    public static void main(String[] args) {
        String str = "5 anh em trên 1 chiếc Xe Tăng";
        char arr[] = str.toCharArray();
        int DemChuCai = 0, DemSo = 0, DemTu = 0;
        for (char c : arr) {
            if (c == ' ') {
                DemTu++;
            }
            if (Character.isDigit(c)) {
                DemSo++;
            }
        }
        DemChuCai = arr.length - DemTu - DemSo;
        DemTu++;
        System.out.println("Chuoi: \"" + str + "\" co " + DemChuCai + " chu cai, " + DemSo + " so, " + DemTu + " tu.");
    }
}
