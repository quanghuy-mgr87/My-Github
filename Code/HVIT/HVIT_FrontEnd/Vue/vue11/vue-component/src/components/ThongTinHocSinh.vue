<template>
    <div>
        <h1>Chi tiết học sinh:</h1>
        <h2>Họ tên: {{ name_pr }}</h2>
        <h2>Địa chỉ: {{ diaChi }}</h2>
        <button @click="changeName()">Đổi tên</button>
        <button @click="changePr()">
            Thay tên
            <!-- Thay đổi thông tin phía parent -->
        </button>
    </div>
</template>
<script>
import {EventBus} from "../main.js";
export default {
    name: "thongTinHocSinh",
    //props:['name_pr'],
    props: {
        name_pr: String,
        changeName: Function,
    },
    // props:{
    //     name_pr: {
    //         type: String,
    //         required: true,
    //         default: 'My'
    //     }
    // },

    data: function() {
        return {
            hoTen: "Nguyen Thi D",
            diaChi: "Ha Noi",
        };
    },
    methods: {
        changePr() {
            this.name_pr = "Bui Tra My (Changed by child1)";
            //this.$emit('nameChanged', this.name_pr);
            EventBus.$emit("nameChanged", this.name_pr);
        },
    },
};
</script>
<style scoped>
div {
    border: 1px double red !important;
}
</style>
