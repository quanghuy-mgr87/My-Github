package JavaLyThuyet.JavaBasic;

public class JA_03_String {
    public static void main(String[] args) {
        String a = "abb";
        String b = new String("abb");
        char c[] = {'a', 'b', 'b'};
        String d = new String(c);
        System.out.println(a);
        System.out.println(b);
        System.out.println(d);
        System.out.println(a + b + d);

        //so sanh 2 chuoi
        System.out.println(a.equals(b));

        String s1 = "hello";
        String s2 = "hello";
        String s3 = s1;
        String s4 = new String("hello");
        String s5 = new String("hello");

        // == so sánh địa chỉ vùng bộ nhớ lưu trữ của đối tượng
        System.out.println(s1 == s1);
        System.out.println(s1 == s2);
        System.out.println(s1 == s3);

        //con này trả về false
        System.out.println(s1 == s4);

        //Cong chuoi:
        String str1 = "ds";
        String str2 = "hs";
        System.out.println(str1.concat(str2));

        //CHuoi con:
        String str3= "Hello";
        System.out.println(str3.substring(2));
        System.out.println(str3.substring(0,2));

        //Format string
        String str4 = String.format("|%-10d|",101);
        //lấy ra 10 ô, sau đó in số 101 sang trái
        String str5 = String.format("|%10d|",101);
        //lấy ra 10 ô, sau đó in số 101 sang phải
        System.out.println(str4);
        System.out.println(str5);
    }
}
