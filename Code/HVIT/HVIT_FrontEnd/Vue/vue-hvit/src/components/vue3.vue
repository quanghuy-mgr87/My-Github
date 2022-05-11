<template>
    <div class="hello">
        <!-- 
            1. v-on: lắng nghe sự kiện 

            2. Phương thức xử lý sự kiện: truyền vào 1 hàm, xử lý hàm đó ở methods

            3. Event modifier: bổ trợ cho các hành động:
                có các hậu tố:
                1. .stop: dừng luôn sự kiện đó
                2. .prevent
                3. .capture
                4. .self
                5. .once: chỉ bắt sự kiện đúng 1 lần

            4. key modifier: lắng nghe sự kiên trên bàn phím:
                VD: chỉ gọi vm.submit() khi keycode là 13 (phím Enter)
                <input v-on:keyup.13 = "submit()">
                - Vue cung cấp thêm 1 số bí danh cho phím thông dụng:
                    .enter
                    .tab
                    .delete
                    .esc
                    .space
                    .up
                    .down
                    .left
                    .right
                - Có thể tự định nghĩa alias cho key modifier bằng object toàn cục config.ketCodes
                    VD: Vue.config.keyCodes.f1 = 112
            
            5. Using Javascript Expressions: ta có thể sử dụng code javascript trong cặp dấu {{}}, nhưng cần chú ý là 
            ta chỉ có thể sử dụng các scope đã được khai báo mặc định trong Javascript, còn các biến hay object, ...
            mà người dùng tự định nghĩa thì sẽ không thể sử dụng được.
                VD: {{number + 1}}
                    {{ok ? 'YES' : 'NO'}}
                    {{message.split('').reverse().join('')}}
                    <div v-bind:id = "'list-' + id"></div>
            - Các biểu thức trong cặp dấu {{}} sẽ được tính toán dưới dạng javascript trong scope của đối tượng Vue hiện hành.
            - Một hạn chế ở đây là mỗi ràng buộc chỉ có thể chứa một biểu thức đơn lẻ, vì thế các TH sau sẽ không hoạt động:
                {{ var a = 1 }}
                {{ if(ok) { return msg }}}
        -->

        <button v-on:click.once="demCuu(5)">Đếm cừu</button>
        {{counter}} con cừu
    <br>
    <!-- v-model: lấy giá trị trong ô select đang giữ ra để gán vào biến khoaHoc -->
        <select v-on:change="chonKhoaHoc()" v-model="khoaHoc">
            <option value="Fullstack .NET">Fullstack .NET</option>
            <option value="Fullstack Java">Fullstack Java</option>
            <option value="Fullstack PHP">Fullstack PHP</option>
        </select>
    <br>
        <input v-on:keyup.enter="submit()" value="submit">
        <hr>
        <p>{{ troiNang == true ? 'hôm nay trời nắng' : 'hôm nay trời mưa'}}</p>

        <p>{{str.split('.')[0]}}</p>

        <!-- <p>{{var a = 1}}</p> lỗi -->
    </div>
</template>

<script>
export default {
    name: "HelloWorld",
    props: {
        msg: String,
    },
    data(){
      return{
        counter: 1,
        khoaHoc: '',
        troiNang: false,
        str: 'hvit clan cung cấp cho các bạn nhiều sự lựa chọn về khóa học. Ví dụ: .NET, Java, PHP'
      };
    },
    methods: {
        demCuu(soNhan){
            this.counter *= soNhan;
        },

        chonKhoaHoc(){
            var msg = 'Bạn vừa chọn khóa học ' + this.khoaHoc;
            alert(msg);
        },

        submit(){
            alert('submit thành công!');
        }
    }
};
</script>

<style>
  
</style>
