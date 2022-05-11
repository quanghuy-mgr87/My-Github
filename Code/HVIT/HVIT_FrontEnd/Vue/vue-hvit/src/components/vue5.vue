<template>
    <div class="hello">
        <!-- 
      1. Conditional rendering: reder có điều kiện
        - v-if > v-else-if > v-else
        - Dùng để tùy biến điều kiện xảy ra đối với các phần tử html

          <tag_name v-if="conditional_1"></tag_name>
          [
            <tag_name v-else-if="conditional_2"></tag_name>
            <tag_name v-else-if="conditional_3"></tag_name>
            ...
            <tag_name v-else-if="conditional_n"></tag_name>
            <tag_name v-else></tag_name>
          ]

            + Trong đó các conditional_x là các giá trị trả về true/false có thể là biến, biểu thức hàm,...
            + Các thẻ chứa v-else-if hoặc v-else là ko bắt buộc trong khối lệnh trên, nếu có, nó cần đi ngay sau v-if
            + Không thể có v-else-if hoặc v-else đứng một mình, nó chỉ tồn tại khi có v-if

          - v-show: Một sự lựa chọn nữa cho việc ẩn hoặc hiện một phần tử web theo điều kiện là directive v-show.
            Cách dùng v-show cũng tương tự với v-if:

              <tag_name v-show = "conditional"></tag_name>

            Điểm khác biệt giữa v-show và v-if là phần tử được đánh dấu với v-show sẽ luôn được render và chứa trong DOM, 
            v-show chỉ bật tắt thuộc tính display của phần tử này.

            "với v-show: phần tử vẫn luôn ở đó, chỉ là có hiển thị ra hay ko."
            "với v-if: phần tử có hiển thị ra hay ko."

            LƯU Ý: v-show KHÔNG HỖ TRỢ THẺ <template> VÀ CŨNG KHÔNG HOẠT ĐỘNG VỚI v-else

      2. List Rendering:
        - v-for đối với danh sách:
          Ta có thể dùng directive v-for để render một danh sách các item dựa trên một mảng. 
          Directive v-for đòi hỏi một cú pháp đặc biệt dưới dạng item in items, trong đó items là mảng dữ liệu nguồn và 
          item trỏ đến phần tử mảng đang được duyệt đến:

            <tag_name v-for = "(item, index) in items" :key="index">
              //Các thao tác với item
            </tag_name>

            Trong đó, index là chỉ số của item trong mảng items, thêm chỉ số này vào là ko bắt buộc trong cấu trúc v-for
        
        - v-for đối với object:

            <tag_name v-for="(key,value,index) in object" :key="index">
              //Các thao tác với dữ liệu
            </tag_name>

            Trong đó, key và value là cặp thuộc tính trong mỗi object, index là chỉ số của các cặp thuộc tính này

        - Một số phương thức biến đổi: 
          + Vue wrap các phương thức biến đổi của một mảng được quan sát để việc gọi phương thức này cũng sẽ kích hoạt thay đổi trên view.
            Các phương thức được wrap gồm:

              push()
              pop()
              shift()
              unshift()
              splice()
              sort()
              reserve()
          
          + Bạn có thể mở console và thử thay đổi mảng items trong các ví dụ trên bằng cách thức thi các phương thức biến đổi
     -->

        <!-- ------------------------------------------------------------------------------------------------------------ -->

        <p v-if="seen == true">Đã xem tin nhắn</p>
        <p v-else>Chưa xem tin nhắn</p>

        <input v-model="a" /><br />

        <p v-if="a == 1">a = 1</p>
        <p v-else-if="a == 2">a = 2</p>
        <p v-else-if="a == 3">a = 3</p>
        <p v-else-if="a == 4">a = 4</p>
        <p v-else>Không nhận giá trị từ 1 đến 4</p>

        <hr />
        <p v-if="seen == true">Đã xem tin nhắn</p>
        <!-- sau khi render, nếu seen = false thì ko render đoạn code trên -->
        <p>Belu</p>
        <p v-show="seen == true">Đã xem</p>
        <!-- sau khi render thì sẽ đc ntn với v-show -->
        <!-- <p style="display: none;">Đã xem</p> -->
        <p>Helu</p>

        <hr />
        <!-- v-for với danh sách -->
        <button @click="themHoaQua()">Thêm quả</button>
        <button @click="xoaHoaQua()">Xóa quả</button>
        <ul>
            <li v-for="(item, index) in dsHoaQua" :key="index">{{ index }} - {{ item.ten }} có màu {{ item.mauSac }}</li>
        </ul>

        <hr />
        <!-- v-for với đối tượng -->
        <ul>
            <li v-for="(key, value, index) in nguoi" :key="index">{{ index }} - {{ value }}: {{ key }}</li>
        </ul>
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    props: {
        msg: String,
    },
    data() {
        return {
            seen: false,
            a: 0,
            dsHoaQua: [
                { ten: "quả cam", mauSac: "cam" },
                { ten: "quả chanh", mauSac: "xanh" },
                { ten: "quả bưởi", mauSac: "vàng" },
                { ten: "quả mít", mauSac: "xanh" },
            ],
            nguoi: {
                ho: "Nguyễn",
                dem: "Bá Quang",
                ten: "Huy",
                tuoi: 23,
            }
        };
    },
    methods:{
      themHoaQua(){
        this.dsHoaQua.push(
          {ten: 'quả mới', mauSac: 'màu mới'}
        )
      },
      // Xóa phần tử cuối cùng
      xoaHoaQua(){
        this.dsHoaQua.pop()
      }
    }
};
</script>

<style></style>
