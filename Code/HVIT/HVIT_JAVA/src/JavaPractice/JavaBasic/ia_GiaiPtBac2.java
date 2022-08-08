package JavaPractice.JavaBasic;

import java.util.Scanner;
import java.util.zip.DeflaterOutputStream;

public class ia_GiaiPtBac2 {
    //Nhap vao 1 ky tu: thuc hien kiem tra ky tu vua nhap la viet hoa hay viet thuong, ky tu la nguyen am hay phu am
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.printf("Nhap ky tu: ");
        char kyTu = sc.next().charAt(0);
        String nguyenAm = "aeiouAEIOU";

        //Kiem tra ky tu viet hoa hay viet thuong
        boolean checkUpperCase = Character.isUpperCase(kyTu);
        if (checkUpperCase == true) {
            System.out.println("Ky tu " + kyTu + " la chu hoa");
        } else {
            System.out.println("Ky tu " + kyTu + " la chu thuong");
        }
//        String chuoiVietHoa = "Ky tu " + kyTu + " la chu " + (checkUpperCase == true ? "hoa" : "thuong");
//        System.out.println(chuoiVietHoa);

        //Kiem tra nguyen am
        boolean checkNguyenAm = nguyenAm.contains(String.valueOf(kyTu));
        if (checkNguyenAm == true) {
            System.out.println("Ky tu " + kyTu + " la nguyem am");
        } else {
            System.out.println("Ky tu " + kyTu + " la phu am");
        }
    }
}
