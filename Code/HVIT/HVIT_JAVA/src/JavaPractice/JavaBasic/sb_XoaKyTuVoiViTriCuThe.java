package JavaPractice.JavaBasic;

public class sb_XoaKyTuVoiViTriCuThe {
    public static void main(String[] args) {

        //Co 2 cach xoa ki tu
        //Cach 1: dung substring
        String str = "asdf";
        System.out.println(str.substring(0, 2) + str.substring(3));

        //Cach 2: dung StringBuilder
        StringBuilder str2 = new StringBuilder("asdf");
        str2 = str2.deleteCharAt(2);
        System.out.println(str2);
    }
}
