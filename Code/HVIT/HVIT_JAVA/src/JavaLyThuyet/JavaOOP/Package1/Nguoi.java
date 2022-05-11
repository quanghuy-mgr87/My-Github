package JavaLyThuyet.JavaOOP.Package1;

public class Nguoi {
//    private int Tt1; // chi su dung trong lop do
//    String Tt2; // goi duoc trong cung package
//    protected double Tt3; // goi duoc trong lop do va lop ke thua
//    public int Tt4; // truy cap o moi cho

    public int ID;
    public String Ten;

    public Nguoi() {
        ID = 0;
        Ten = "";
    }

    public Nguoi(int ID, String Ten) {
        this.ID = ID;
        this.Ten = Ten;
    }

    public void Hien() {
        System.out.println(String.format("%d co ten la %s", ID, Ten));
    }
}
