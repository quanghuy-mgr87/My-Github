package JavaLyThuyet.JavaMath_Function;

public class ThamKhao_HamThuongDung {
    public static void main(String[] args) {
        String Ho = "Nguyen Ba";
        String Dem = "Quang";
        String Ten = "Huy";
        String chuoiTrang = "               ";

        // Tim ki tu theo vi tri
        System.out.println(Ho.charAt(2));

        // Ham noi chuoi
        System.out.println(Ho.concat(" " + Dem).concat(" " + Ten));

        // Kiem tra chuoi con
        System.out.println(Ho.contains("uyen"));

        // Kiem tra mo dau hay ket thuc co ki tu nao do hay ko
        System.out.println(Ho.startsWith("N"));
        System.out.println(Ho.endsWith("b"));

        // Kiem tra chuoi rong
        System.out.println(Ho.isEmpty());

        // Kiem tra chuoi trang
        System.out.println(chuoiTrang.isBlank());

        // Tim vi tri phan tu cuoi cung
        System.out.println(Ho.lastIndexOf('a'));

        // do dai chuoi: str.length()

        // Thay doi chuoi: str.replace

        // Cat chuoi thanh nhieu chuoi con: str.split(" ")

        // Xoa het khoang trang: str.trim()

        // Chuyen chu hoa, chu thuong: toLowerCase, toUpperCase
    }
}
