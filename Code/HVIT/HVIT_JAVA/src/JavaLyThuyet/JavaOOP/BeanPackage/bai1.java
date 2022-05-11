package JavaLyThuyet.JavaOOP.BeanPackage;

import JavaLyThuyet.JavaOOP.Package1.*; // .* la lay moi lop trong package1
//import JavaLyThuyet.JavaOOP.Package1.Nguoi; // .* la lay lop Nguoi trong package1

public class bai1 {
    public static void main(String[] args) {
        Nguoi anhA = new Nguoi();
//        anhA.ID = 1;
//        anhA.Ten = "Nguyen Van A";
        anhA.Hien();

        Nguoi anhB = new Nguoi(2, "Tran Van B");
//        anhB.ID = 2;
//        anhB.Ten = "Nguyen Van B";
        anhB.Hien();

    }
}
