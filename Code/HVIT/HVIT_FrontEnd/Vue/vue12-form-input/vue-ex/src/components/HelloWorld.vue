<template>
  <div>
    <h5>* v-model</h5>
    <h1>My-app</h1>
    <input v-model="name" placeholder="Điền tên học viên..." />
    <br />
    <!-- v-model vừa là biến để lưu trữ giá trị, nó thay luôn cho cả v-bind và v-on. Nó luôn lắng nghe và thay đổi
    dữ liệu theo biến ràng buộc, nó thực hiện cùng lúc 2 công việc bên dưới: lắng nghe sự kiện input để thay đổi giá trị name,
    sau đó tiếp tục bind value = name -->
    <!-- v-model: lắng nghe và thay đổi dữ liệu theo luôn -->
    <input @input="name = $event.target.value" :value="name" placeholder="Điền tên học viên..." />
    <h2>Họ tên: {{ name }}</h2>
    <hr />
    <!--  -->
    <h5>* Binding to input</h5>
    <label>Họ tên: </label>
    <input v-model="name" placeholder="Điền tên học viên..." />

    <br />
    <label>Địa chỉ: </label>
    <textarea rows="3" v-model="address" placeholder="Nhập địa chỉ..."></textarea>
    <br />
    <label>Quê quán: </label>
    <select v-model="queQuan">
      <!-- nếu ko có value thì mặc định lấy tên option là value -->
      <option :value="address1">Hà Nội</option>
      <option :value="address2">Hà Nam</option>
      <option :value="address3">Nam Định</option>
      <option :value="address4">Ninh Bình</option>
    </select>
    <br />
    <label>Giới tính: </label> Nam <input type="checkbox" v-model="gen" />

    <br />
    <label>Lịch học: </label>
    <label>Thứ 2: </label><input type="checkbox" value="thứ high" v-model="tkb" /> <label>Thứ 3: </label
    ><input type="checkbox" value="thứ bar" v-model="tkb" /> <label>Thứ 4: </label><input type="checkbox" value="thứ porn" v-model="tkb" />
    <label>Thứ 5: </label><input type="checkbox" value="thứ 5" v-model="tkb" /> <label>Thứ 6: </label
    ><input type="checkbox" value="thứ 6" v-model="tkb" /> <label>Thứ 7: </label><input type="checkbox" value="thứ 7" v-model="tkb" />
    <br />
    <label>Khóa học: </label> <br />
    <input type="radio" :value="k1" v-model="khoaHoc" /><label>Fullstack .Net</label> <br />
    <input type="radio" :value="k2" v-model="khoaHoc" /><label>Fullstack Java</label> <br />
    <input type="radio" :value="k3" v-model="khoaHoc" /><label>Fullstack Php</label> <br />
    <hr />
    <h5>Họ tên: {{ name }}</h5>
    <h5>Địa chỉ: {{ address }}</h5>
    <h5>Quê quán: {{ queQuan }}</h5>
    <h5>Giới tính: {{ gen == 0 ? "nữ" : "nam" }}</h5>
    <h5>Lịch học: {{ tkb }}</h5>
    <ul>
      <li v-for="(item, index) in tkb" :key="index">{{ item }}</li>
    </ul>
    <h5>Khóa học: {{ khoaHoc }}</h5>
  </div>
</template>
<script>
export default {
  name: "hello",
  data: function() {
    return {
      name: "Nguyen Van A",
      address: "",
      gen: 0,
      // 0 là nữ, 1 là nam
      tkb: [],
      khoaHoc: "Fullstack .Net",
      k1: "Fullstack .Net",
      k2: "Fullstack Java",
      k3: "Fullstack Php",
      queQuan: "",
      address1: "Hanoi",
      address2: "Hanam",
      address3: "Namdinh",
      address4: "Ninhbinh",
    };
  },
};
</script>
