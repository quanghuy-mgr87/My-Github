package JavaPractice.JavaOOPBasic.SoThuc;

public class Main {
    public static void main(String[] args) {
        SoThuc soThuc = new SoThuc(2.3);
        System.out.println(soThuc.isLaSoDuong());
        System.out.println("So lon nhat trong 3 so 2,3,4 la: " + SoThuc.TimMax(new SoThuc(2), new SoThuc(3), new SoThuc(4)).getGiaTri());
        System.out.println("Can bac 2 cua so 4 la: " + new SoThuc(4).TimCanBacN(2));
    }
}
